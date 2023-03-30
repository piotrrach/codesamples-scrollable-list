using Gamesture.Assets.Scripts.SpriteFilesWindow;

namespace Gamesture.Assets.Scripts
{
    public class SpriteFilesWindowController
    {
        private ProjectSettings _projectSettings;
        private SpriteFilesWindowView _view;
        private PNGToSpriteFileModelLoader _pNGToSpriteFileDataLoader;

        public SpriteFilesWindowController(ProjectSettings projectSettings, SpriteFilesWindowView scrollListWindowView)
        {
            _projectSettings = projectSettings;
            _view = scrollListWindowView;

            _pNGToSpriteFileDataLoader = new PNGToSpriteFileModelLoader(_projectSettings.PngFilesDirectoryPath);
            _view.OnRefreshButtonPress += RefreshSpriteFileList;

            RefreshSpriteFileList();
        }

        private void RefreshSpriteFileList()
        {
            _view.RefreshContent(_pNGToSpriteFileDataLoader.Load());
        }
    }
}

