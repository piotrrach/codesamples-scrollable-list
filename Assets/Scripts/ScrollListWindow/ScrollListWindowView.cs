using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gamesture.Assets.Scripts.ScrollListWindow
{
    public class ScrollListWindowView : MonoBehaviour
    {
        [SerializeField]
        private Button _refershButton;
        [SerializeField]
        private ScrollRect _scrollRect;
        [SerializeField]
        private RectTransform _viewport;
        [SerializeField]
        private RectTransform _content;

        private PooledScrolList _pooledScrolList;

        public Action OnRefreshButtonPress { get; set; }

        [Inject]
        public void Construct(SpriteFileView.Factory _spriteFileViewFactory, IScrollListWindowSettings scrollListWindowsettings)
        {
            _refershButton.onClick.AddListener(() => { OnRefreshButtonPress.Invoke(); });

            _pooledScrolList = new PooledScrolList(scrollListWindowsettings.ScrollListSettings,
                                                    _viewport,
                                                    _content,
                                                    _scrollRect,
                                                     (model) => { return _spriteFileViewFactory.Create((SpriteFileModel)model); });
        }

        public void RefreshContent(SpriteFileModel[] spriteFileModels)
        {
            _pooledScrolList.SetDataList(spriteFileModels);
        }

        public class Factory : PlaceholderFactory<ScrollListWindowView> { }
    }
}