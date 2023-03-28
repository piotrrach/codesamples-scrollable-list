using Gamesture.Assets.Scripts.ScrollListWindow;
using Zenject;

namespace Gamesture.Assets.Scripts
{
    public class Bootstrap : IInitializable
    {
        private ScrollListWindowView.Factory _scrollListWindowViewFactory;
        private ProjectSettings _projetSettings;

        public Bootstrap(ScrollListWindowView.Factory scrollListWindowViewFactory, ProjectSettings projectSettings)
        {
            _scrollListWindowViewFactory = scrollListWindowViewFactory;
            _projetSettings = projectSettings;
        }

        public void Initialize()
        {
            var windowView = _scrollListWindowViewFactory.Create();
            new SpriteFilesWindowController(_projetSettings, windowView);
        }
    }
}
