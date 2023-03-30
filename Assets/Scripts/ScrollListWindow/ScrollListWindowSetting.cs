using System;
using UnityEngine;

namespace Gamesture.Assets.Scripts.ScrollListWindow
{
    [Serializable]
    public class ScrollListWindowSetting<T> where T : Component, IScrollListElementView
    {
        [SerializeField]
        private T _scrollListElementPrefab;
        [SerializeField]
        private PooledScrollListSettings _pooledScrollListSettings;

        public Component ScrollListElementView => _scrollListElementPrefab;
        public PooledScrollListSettings PooledScrollListSettings => _pooledScrollListSettings;
    }
}