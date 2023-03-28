using UnityEngine;

namespace Gamesture.Assets.Scripts.ScrollListWindow
{
    public interface IScrollListElementView
    {
        RectTransform RectTransform { get; }

        void Despawn();
    }
}


