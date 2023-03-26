using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gamesture.Assets.Scripts
{
    public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
    {
        [SerializeField]
        private GameObject _spriteFileViewPrefab;
        [SerializeField]
        private ProjectSettings _projectSettings;
        [SerializeField]
        private PooledScrolList.Settings _scrolListSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_projectSettings).IfNotBound();
            Container.BindInstance(_scrolListSettings).IfNotBound();

            Container.BindFactory<SpriteFileModel, SpriteFileView, SpriteFileView.Factory>()
                .FromPoolableMemoryPool<SpriteFileModel, SpriteFileView, SpriteFileViewPool>(poolbinder => poolbinder
                .WithInitialSize(8)
                .FromComponentInNewPrefab(_spriteFileViewPrefab));

            Container.Bind<SpriteFilesWindowView>()
                .FromInstance(FindObjectOfType<SpriteFilesWindowView>())
                .NonLazy();
            Container.BindInterfacesAndSelfTo<SpriteFilesWindowController>().AsSingle();
        }

        class SpriteFileViewPool : MonoPoolableMemoryPool<SpriteFileModel, IMemoryPool, SpriteFileView> { }
    }
}
