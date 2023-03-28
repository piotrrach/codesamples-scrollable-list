using System;
using UnityEngine;

namespace Gamesture.Assets.Scripts.ScrollListWindow
{
    [Serializable]
    public class ScrollListWindowSetting<T> : IScrollListWindowSettings where T : Component, IScrollListElementView
    {
        public T _scrollListElementPrefab;
        public PooledScrolList.Settings _scrollListSettings;

        public Component ScrollListElementView => _scrollListElementPrefab;
        public PooledScrolList.Settings ScrollListSettings => _scrollListSettings;
    }
}