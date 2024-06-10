using Game.Core;
using Game.Utils;
using Game.Views.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private SoundButton closeButton;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle soundsToggle;

        [SerializeField] private WindowAnimator animator;

        private SettingsContainer _settingsContainer;

        private void Awake()
        {
            _settingsContainer = GameContainer.SettingsContainer;
        }

        private void OnEnable()
        {
            UpdateWindow();
            closeButton.SetSound("ClickSound");
            musicToggle.onValueChanged.AddListener(ToggleMusic);
            soundsToggle.onValueChanged.AddListener(ToggleSounds);
            closeButton.onClick.AddListener(Close);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            animator.Show();
        }

        private void UpdateWindow()
        {
            musicToggle.isOn = _settingsContainer.MusicOn;
            soundsToggle.isOn = _settingsContainer.SoundOn;
        }

        private void ToggleMusic(bool isOn)
        {
            _settingsContainer.MusicOn = isOn;
        }

        private void ToggleSounds(bool isOn)
        {
            _settingsContainer.SoundOn = isOn;
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