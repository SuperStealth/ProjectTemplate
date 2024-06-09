using DG.Tweening;
using System;
using UnityEngine;

namespace Game.Views.Utils
{
    [RequireComponent(typeof(RectTransform))]
    public class WindowAnimator : MonoBehaviour
    {
        [SerializeField] private float animationSpeed = 1f;

        private RectTransform _rectTransform;

        public Action OnWindowHidden;
        public Action OnWindowShown;

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
            _sequence.Append(_rectTransform.DOAnchorPosY(0, animationSpeed));
            _sequence.onComplete = UpdateWindowShown;
        }

        public void Hide()
        {
            if (_sequence == null)
            {
                _sequence = DOTween.Sequence();
            }
            _sequence.Append(_rectTransform.DOAnchorPosY(-_rectTransform.rect.size.y, animationSpeed));
            _sequence.onComplete = DisableWindow;
        }

        private void UpdateWindowShown()
        {
            OnWindowShown?.Invoke();
            _sequence = null;
        }

        private void DisableWindow()
        {
            OnWindowHidden?.Invoke();
            _sequence = null;
        }
    }
}