using Gamesture.Assets.Scripts.ScrollListWindow;
using Gamesture.Assets.Scripts.SpriteFilesWindow;
using Zenject;

namespace Gamesture.Assets.Scripts
{
    public class Bootstrap : IInitializable
    {
        private SpriteFilesWindowView.Factory _spriteFilesWindowViewFactory;
        private ProjectSettings _projetSettings;

        public Bootstrap(SpriteFilesWindowView.Factory spriteFilesWindowViewFactory, ProjectSettings projectSettings)
        {
            _spriteFilesWindowViewFactory = spriteFilesWindowViewFactory;
            _projetSettings = projectSettings;
        }

        public void Initialize()
        {
            var windowView = _spriteFilesWindowViewFactory.Create();
            new SpriteFilesWindowController(_projetSettings, windowView);
        }
    }
}