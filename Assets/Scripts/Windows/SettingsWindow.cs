using Game.Views.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle soundsToggle;

        [SerializeField] private WindowAnimator animator;

        private void OnEnable()
        {
            musicToggle.onValueChanged.AddListener(ToggleMusic);
            soundsToggle.onValueChanged.AddListener(ToggleSounds);
            closeButton.onClick.AddListener(Close);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            animator.Show();
        }



        private void ToggleMusic(bool isOn)
        {

        }

        private void ToggleSounds(bool isOn)
        {

        }

        private void Close()
        {
            animator.Hide();
            animator.OnWindowHidden += CloseAfterAnimationEnded;
        }

        private void CloseAfterAnimationEnded()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            musicToggle.onValueChanged.RemoveListener(ToggleMusic);
            soundsToggle.onValueChanged.RemoveListener(ToggleSounds);
            closeButton.onClick.RemoveListener(Close);
        }
    }
}