using System;
using UnityEngine;

namespace Gamesture.Assets.Scripts
{
    public class SpriteFileModel : IGuiModel
    {
        public string FileName;
        public TimeSpan TimeSinceCreation;
        public Sprite Sprite;

        public SpriteFileModel(string fileName, TimeSpan timeSinceCreation, Sprite sprite)
        {
            FileName = fileName;
            TimeSinceCreation = timeSinceCreation;
            Sprite = sprite;
        }
    }
}
