using UnityEngine;
using Zenject;
using Gamesture.Assets.Scripts.ScrollListWindow;

namespace Gamesture.Assets.Scripts
{
    public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
    {
        [SerializeField]
        private Transform _canvasPrefab;
        [SerializeField]
        private GameObject _scrollListWindowView;
        [SerializeField]
        private ProjectSettings _projectSettings;
        [SerializeField]
        private PooledScrolList.Settings _scrolListSettings;

        [SerializeField]
        private ScrollListWindowSetting<SpriteFileView> _spriteFilesWindowSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle();

            Container.BindInstance(_projectSettings).IfNotBound();
            Container.Bind<IScrollListWindowSettings>().FromInstance(_spriteFilesWindowSettings).IfNotBound();

            Container.BindFactory<SpriteFileModel, SpriteFileView, SpriteFileView.Factory>()
                .FromPoolableMemoryPool<SpriteFileModel, SpriteFileView, SpriteFileViewPool>(poolbinder => poolbinder
                .WithInitialSize(8)
                .FromComponentInNewPrefab(_spriteFilesWindowSettings.ScrollListElementView));

            var _mainCanvas = Instantiate(_canvasPrefab);

            Container.BindFactory<ScrollListWindowView, ScrollListWindowView.Factory>()
                .FromComponentInNewPrefab(_scrollListWindowView)
                .UnderTransform(_mainCanvas);
        }

        class SpriteFileViewPool : MonoPoolableMemoryPool<SpriteFileModel, IMemoryPool, SpriteFileView> { }
    }
}