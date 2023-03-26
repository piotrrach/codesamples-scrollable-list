using Gamesture.Assets.Scripts.Extensions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gamesture.Assets.Scripts
{
    public class SpriteFilesWindowController : IInitializable
    {
        private ProjectSettings _projectSettings;
        private SpriteFilesWindowView _view;

        private PNGToSpriteFileModelLoader _pNGToSpriteFileDataLoader;

        public SpriteFilesWindowController(ProjectSettings projectSettings, SpriteFilesWindowView spriteFilesExplorerView)
        {
            _projectSettings = projectSettings;
            _view = spriteFilesExplorerView;
        }
         
        public void Initialize()
        {
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

