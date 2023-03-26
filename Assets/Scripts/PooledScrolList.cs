using Gamesture.Assets.Scripts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Gamesture.Assets.Scripts
{
    public partial class PooledScrolList
    {
        private Settings _settings;
        private RectTransform _viewport;
        private RectTransform _content;
        private ScrollRect _scrollRect;
        private Func<IGuiModel, IGuiElement> createMethod;

        private IGuiModel[] _models;
        private List<IGuiElement> _views;

        int _topIndex;
        int _bottomIndex;
        int _minimalElementsForPooling;
        
        public PooledScrolList(Settings settings, RectTransform viewport, RectTransform content, ScrollRect scrollRect, Func<IGuiModel, IGuiElement> createMethod)
        {
            _settings = settings;
            _viewport = viewport;
            _content = content;
            _scrollRect = scrollRect;
            this.createMethod = createMethod;

            _views = new List<IGuiElement>();

            _scrollRect.onValueChanged.AddListener(OnScrollMove);
        }

        public void SetDataList(IGuiModel[] models)
        {
            _models = models;
            _topIndex = 0;

            _minimalElementsForPooling = CalculateMinimalElementsForPooling();
            _bottomIndex = CalculateInitialBottomIndex();
            ResetScrollPosition();
            SetContentSize();
            Clear();
            SpawnList();
        }

        private int CalculateMinimalElementsForPooling()
        {
            return Mathf.CeilToInt(_viewport.rect.height / (_settings.ElementHeight + _settings.Offset));
        }

        private int CalculateInitialBottomIndex()
        {
            if (_settings.ElementHeight * _models.Length < _viewport.rect.height)
            {
                return _models.Length - 1;
            }

            return (int)(_viewport.rect.height / _settings.ElementHeight) - 1;
        }

        private void ResetScrollPosition()
        {
            _scrollRect.verticalNormalizedPosition = 1;
        }

        private void SetContentSize()
        {
            _content.sizeDelta = new Vector2(_content.sizeDelta.x, (_settings.ElementHeight + _settings.Offset) * _models.Length - _settings.Offset);
        }

        private void Clear()
        {
            foreach (var spriteFileView in _views)
            {
                spriteFileView.Despawn();
            }
            _views.Clear();
        }

        private void SpawnList()
        {
            for (int i = 0; i <= _bottomIndex; i++)
            {
                var elementView = createMethod.Invoke(_models[i]);
                elementView.RectTransform.SetParent(_content, false);
                elementView.RectTransform.sizeDelta = new Vector2(elementView.RectTransform.sizeDelta.x, _settings.ElementHeight);
                elementView.RectTransform.anchoredPosition = new Vector2(0, -(_settings.ElementHeight + _settings.Offset) * i);
                _views.Add(elementView);
            }
        }

        private void OnScrollMove(Vector2 v)
        {
            if (_models.Length < _minimalElementsForPooling)
            {
                return;
            }

            float edgeTop = _viewport.GetEdgeHeightTop();
            float edgeBottom = _viewport.GetEdgeHeightBottom();

            IGuiElement first = _views.First();
            IGuiElement last = _views.Last();

            if (last.RectTransform.GetEdgeHeightBottom() > edgeBottom)
            {
                //Spawn On Bot
                if (_bottomIndex < _models.Length - 1)
                {
                    _bottomIndex++;
                    var elementView = createMethod.Invoke(_models[_bottomIndex]);
                    elementView.RectTransform.SetParent(_content, false);
                    elementView.RectTransform.sizeDelta = new Vector2(elementView.RectTransform.sizeDelta.x, _settings.ElementHeight);
                    elementView.RectTransform.anchoredPosition = last.RectTransform.localPosition - Vector3.up * (_settings.ElementHeight + _settings.Offset);

                    _views.Add(elementView);
                }
            }
            else if (last.RectTransform.GetEdgeHeightTop() < edgeBottom)
            {
                //Despawn On Bot
                _bottomIndex--;
                _views.Remove(last);
                last.Despawn();
            }

            if (first.RectTransform.GetEdgeHeightTop() < edgeTop)
            {
                //Spawn On Top
                if (_topIndex > 0)
                {
                    _topIndex--;
                    var elementView = createMethod.Invoke(_models[_topIndex]);
                    elementView.RectTransform.sizeDelta = new Vector2(elementView.RectTransform.sizeDelta.x, _settings.ElementHeight);
                    elementView.RectTransform.SetParent(_content, false);
                    elementView.RectTransform.anchoredPosition = first.RectTransform.localPosition + Vector3.up * (_settings.ElementHeight + _settings.Offset);

                    _views.Insert(0, elementView);
                }
            }
            else if (first.RectTransform.GetEdgeHeightBottom() > edgeTop)
            {
                //Despawn On Top
                _topIndex++;
                _views.Remove(first);
                first.Despawn();
            }
        }
    }
}
