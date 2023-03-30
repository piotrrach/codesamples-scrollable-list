using System;
using UnityEngine;
using Gamesture.Assets.Scripts.ScrollListWindow;

namespace Gamesture.Assets.Scripts
{
    public class SpriteFileModel : IScrollListElementModel
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
