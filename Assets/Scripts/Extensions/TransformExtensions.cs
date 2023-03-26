using UnityEngine;

namespace Gamesture.Assets.Scripts.Extensions
{
    public static class TransformExtensions
    {
        public static Transform GetLastChild(this Transform transform)
        {
            return transform.childCount > 0 ? transform.GetChild(transform.childCount - 1) : null;
        }
    }
}
