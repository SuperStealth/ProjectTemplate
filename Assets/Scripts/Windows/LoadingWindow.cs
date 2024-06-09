using Game.Views.Utils;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Views
{
    public class LoadingWindow : MonoBehaviour
    {
        [SerializeField] private WindowAnimator animator;

        public Action OnWindowShown;

        private void Awake()
        {
            animator.OnWindowHidden += DisableWindow;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            animator.OnWindowShown += OnWindowShown;
            animator.Show();
        }

        public void UpdateSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            animator.Hide();
        }

        private void DisableWindow()
        {
            gameObject.SetActive(false);
        }
    }
}