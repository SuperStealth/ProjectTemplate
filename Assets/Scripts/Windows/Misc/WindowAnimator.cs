using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views.Utils
{
    [RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
    public class WindowAnimator : MonoBehaviour
    {
        [SerializeField] private float animationSpeed = 1f;

        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        public Action OnWindowHidden;
        public Action OnWindowShown;

        private Sequence _sequence;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            if (_sequence != null)
            {
                _sequence.Kill();
            }
            _sequence = DOTween.Sequence();
            _sequence.Append(_rectTransform.DOAnchorPosY(_rectTransform.rect.size.y, 0));
            _sequence.Append(_canvasGroup.DOFade(0, 0));
            _sequence.Append(_rectTransform.DOAnchorPosY(0, animationSpeed));
            _sequence.Join(_canvasGroup.DOFade(1, animationSpeed));
            _sequence.onComplete = UpdateWindowShown;
        }

        public void Hide()
        {
            if (_sequence != null)
            {
                _sequence.Kill();
            }
            _sequence = DOTween.Sequence();
            _sequence.Append(_canvasGroup.DOFade(1, 0));
            _sequence.Append(_rectTransform.DOAnchorPosY(-_rectTransform.rect.size.y, animationSpeed));
            _sequence.Join(_canvasGroup.DOFade(0, animationSpeed));
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