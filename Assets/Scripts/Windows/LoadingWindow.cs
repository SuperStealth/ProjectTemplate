using Game.Views.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Views
{
    public class LoadingWindow : MonoBehaviour
    {
        [SerializeField] private WindowAnimator animator;

        private void Awake()
        {
            animator.OnWindowHidden += DisableWindow;
        }

        public void Show()
        {
            gameObject.SetActive(true);
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