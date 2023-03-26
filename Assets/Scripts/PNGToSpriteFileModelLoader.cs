using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Gamesture.Assets.Scripts
{
    public class PNGToSpriteFileModelLoader
    {
        private readonly string _workingDirectory;

        public PNGToSpriteFileModelLoader(string workingDirectory)
        {
            _workingDirectory = workingDirectory;
        }

        public SpriteFileModel[] Load()
        {
            var files = Directory.GetFiles(_workingDirectory).Where(p => Regex.IsMatch(p, @"\.png$"));
            SpriteFileModel[] result = new SpriteFileModel[files.Count()];

            for (int i = 0; i < files.Count(); i++)
            {
                FileInfo fileInfo = new FileInfo(files.ElementAt(i));
                result[i] = new SpriteFileModel(fileInfo.Name, DateTime.Now - fileInfo.CreationTime, LoadNewSprite(fileInfo.FullName));
            }

            return result;
        }

        private Sprite LoadNewSprite(string filePath, float pixelsPerUnit = 100.0f)
        {
            Texture2D spriteTexture = LoadTexture(filePath);
            Sprite newSprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0, 0), pixelsPerUnit);
            return newSprite;
        }

        private Texture2D LoadTexture(string filePath)
        {
            Texture2D texture2D;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);
                texture2D = new Texture2D(0, 0);
                if (texture2D.LoadImage(fileData))
                    return texture2D;
            }
            return null;
        }
    }
}
