using UnityEngine;

namespace Gamesture.Assets.Scripts
{
    public interface IGuiElement
    {
        RectTransform RectTransform { get; }

        void Despawn();
    }
}


