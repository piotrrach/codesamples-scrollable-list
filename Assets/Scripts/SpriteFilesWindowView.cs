using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static Gamesture.Assets.Scripts.ProjectInstaller;

namespace Gamesture.Assets.Scripts
{
    public class SpriteFilesWindowView : MonoBehaviour
    {
        [SerializeField]
        private Button _refershButton;
        [SerializeField]
        private ScrollRect _scrollRect;
        [SerializeField]
        private RectTransform _viewport;
        [SerializeField]
        private RectTransform _content;

        public Action OnRefreshButtonPress { get; set; }

        private PooledScrolList _pooledScrolList;

        [Inject]
        public void Construct(SpriteFileView.Factory _spriteFileViewFactory, PooledScrolList.Settings scrollListSettings)
        {
            _refershButton.onClick.AddListener(() => { OnRefreshButtonPress.Invoke(); });

            _pooledScrolList = new PooledScrolList(scrollListSettings,
                                                    _viewport,
                                                    _content,
                                                    _scrollRect,
                                                     (model) => { return _spriteFileViewFactory.Create((SpriteFileModel)model); });
        }

        public void RefreshContent(SpriteFileModel[] spriteFileModels)
        {
            _pooledScrolList.SetDataList(spriteFileModels);
        }
    }
}
