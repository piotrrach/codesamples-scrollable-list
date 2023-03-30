using Gamesture.Assets.Scripts.SpriteFilesWindow;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gamesture.Assets.Scripts.ScrollListWindow
{
    public class ScrollListWindowView<T1,T2> : MonoBehaviour where T1: IScrollListElementModel where T2: IScrollListElementView
    {
        [SerializeField]
        private Button _refershButton;
        [SerializeField]
        private ScrollRect _scrollRect;
        [SerializeField]
        private RectTransform _viewport;
        [SerializeField]
        private RectTransform _content;

        private PooledScrollList<T1,T2> _pooledScrolList;

        public Action OnRefreshButtonPress { get; set; }

        protected void Construct(Func<T1, T2> createElementMethod, PooledScrollListSettings pooledScrollListSettings)
        {
            _refershButton.onClick.AddListener(() => { OnRefreshButtonPress.Invoke(); });

            _pooledScrolList = new PooledScrollList<T1, T2>(pooledScrollListSettings,
                                                    _viewport,
                                                    _content,
                                                    _scrollRect,
                                                    createElementMethod);
        }

        public void RefreshContent(T1[] spriteFileModels)
        {
            _pooledScrolList.SetDataList(spriteFileModels);
        }        
    }
}