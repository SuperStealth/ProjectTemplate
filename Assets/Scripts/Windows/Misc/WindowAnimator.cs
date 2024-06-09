using DG.Tweening;
using System;
using UnityEngine;

namespace Game.Views.Utils
{
    [RequireComponent(typeof(RectTransform))]
    public class WindowAnimator : MonoBehaviour
    {
        private RectTransform _rectTransform;

        public Action OnWindowHidden;

        private Sequence _sequence;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Show()
        {
            if (_sequence == null)
            {
                _sequence = DOTween.Sequence();
            }
            _sequence.Append(_rectTransform.DOAnchorPosY(_rectTransform.rect.size.y, 0));
            _sequence.Append(_rectTransform.DOAnchorPosY(0, 3));
        }

        public void Hide()
        {
            if (_sequence == null)
            {
                _sequence = DOTween.Sequence();
            }
            _sequence.Append(_rectTransform.DOAnchorPosY(-_rectTransform.rect.size.y, 3));
            _sequence.onComplete = DisableWindow;
        }

        private void DisableWindow()
        {
            OnWindowHidden?.Invoke();
            _sequence = null;
        }
    }
}