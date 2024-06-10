using UnityEngine;

namespace Game.Core
{
    public class BackgroundMusicHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundMusic;

        private SettingsContainer _settingsContainer;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _settingsContainer = GameContainer.SettingsContainer;
        }

        private void OnEnable()
        {
            _backgroundMusic.Play();
            _settingsContainer.OnMusicStateChanged += UpdateMusicState;
            UpdateMusicState(_settingsContainer.MusicOn);
        }

        private void UpdateMusicState(bool state)
        {
            if (state)
            {
                _backgroundMusic.Play();
            }
            else
            {
                _backgroundMusic.Stop();
            }
        }

        private void OnDisable()
        {
            _settingsContainer.OnMusicStateChanged -= UpdateMusicState;
            _backgroundMusic.Stop();
        }
    }
}