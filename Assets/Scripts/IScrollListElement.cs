using UnityEngine;

namespace Gamesture.Assets.Scripts
{
    public interface IScrollListElement
    {
        RectTransform RectTransform { get; }

        void Despawn();
    }
}


