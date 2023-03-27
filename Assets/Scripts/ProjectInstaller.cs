using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gamesture.Assets.Scripts
{
    public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
    {
        [SerializeField]
        private Transform _canvasPrefab;
        [SerializeField]
        private GameObject _spriteFileViewPrefab;
        [SerializeField]
        private GameObject _scrollListWindowView;
        [SerializeField]
        private ProjectSettings _projectSettings;
        [SerializeField]
        private PooledScrolList.Settings _scrolListSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle();

            Container.BindInstance(_projectSettings).IfNotBound();
            Container.BindInstance(_scrolListSettings).IfNotBound();

            Container.BindFactory<SpriteFileModel, SpriteFileView, SpriteFileView.Factory>()
                .FromPoolableMemoryPool<SpriteFileModel, SpriteFileView, SpriteFileViewPool>(poolbinder => poolbinder
                .WithInitialSize(8)
                .FromComponentInNewPrefab(_spriteFileViewPrefab));

            var _mainCanvas = Instantiate(_canvasPrefab);

            Container.BindFactory<ScrollListWindowView, ScrollListWindowView.Factory>()
                .FromComponentInNewPrefab(_scrollListWindowView)
                .UnderTransform(_mainCanvas);
        }

        class SpriteFileViewPool : MonoPoolableMemoryPool<SpriteFileModel, IMemoryPool, SpriteFileView> { }
    }
}