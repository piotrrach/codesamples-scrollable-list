using System;
using UnityEngine;

namespace Gamesture.Assets.Scripts
{
    [Serializable]
    public class ProjectSettings
    {
        [SerializeField, Header("Path to directory with PNG files, like \"~/Assets/<Your PNG Files Directory>\"")]
        private string _pngFilesDirectory = "/PNGFiles~";

        public string PngFilesDirectoryPath => Application.dataPath + _pngFilesDirectory;
    }
} 