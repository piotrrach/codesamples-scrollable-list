using UnityEngine;

namespace Gamesture.Assets.Scripts.Extensions
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Returns Y position of top edge of the rect transform
        /// </summary>
        public static float GetEdgeHeightTop(this RectTransform rectTransform)
        {
            return rectTransform.TransformPoint(rectTransform.rect.center + Vector2.up * rectTransform.rect.size.y / 2).y;
        }

        /// <summary>
        /// Returns Y position of bottom edge of the rect transform
        /// </summary>
        public static float GetEdgeHeightBottom(this RectTransform rectTransform)
        {
            return rectTransform.TransformPoint(rectTransform.rect.center + Vector2.down * rectTransform.rect.height / 2).y;
        }

    }
}
