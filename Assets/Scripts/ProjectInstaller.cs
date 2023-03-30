using UnityEngine;
using Zenject;
using Gamesture.Assets.Scripts.ScrollListWindow;
using Gamesture.Assets.Scripts.SpriteFilesWindow;
using System;

namespace Gamesture.Assets.Scripts
{
    public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
    {
        [SerializeField]
        private Transform _canvasPrefab;
        [SerializeField]
        private GameObject _spriteFilesWindowViewPrefab;
        [SerializeField]
        private ProjectSettings _projectSettings;

        [SerializeField]
        private ScrollListWindowSetting<SpriteFileView> _spriteFilesWindowSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle();

            Container.BindInstance(_projectSettings).IfNotBound();
            Container.Bind<ScrollListWindowSetting<SpriteFileView>>().FromInstance(_spriteFilesWindowSettings);
           // Container.Bind<IScrollListWindowSettings>().FromInstance(_spriteFilesWindowSettings).IfNotBound();

            Container.BindFactory<SpriteFileModel, SpriteFileView, SpriteFileView.Factory>()
            .FromPoolableMemoryPool<SpriteFileModel, SpriteFileView, SpriteFileViewPool>(poolbinder => poolbinder
            .WithInitialSize(8)
            .FromComponentInNewPrefab(_spriteFilesWindowSettings.ScrollListElementView));

            var _mainCanvas = Instantiate(_canvasPrefab);

            Container.BindFactory<SpriteFilesWindowView, SpriteFilesWindowView.Factory>()
                .FromComponentInNewPrefab(_spriteFilesWindowViewPrefab)
                .UnderTransform(_mainCanvas);
        }

        class SpriteFileViewPool : MonoPoolableMemoryPool<SpriteFileModel, IMemoryPool, SpriteFileView> { }

    }
}