using Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Utils
{
    public class SoundButton : Button
    {
        private AudioSource _sound;
        private SettingsContainer _settingsContainer;

        protected override void Start()
        {
            _settingsContainer = GameContainer.SettingsContainer;
            base.Start();
        }

        protected override void OnEnable()
        {
            onClick.AddListener(PlaySound);
            base.OnEnable();
        }

        public void SetSound(string soundName)
        {
            _sound = GameContainer.SoundsContainer.GetAudioSourceByClipName(soundName);
        }

        public void SetSound(AudioSource sound)
        {
            _sound = sound;
        }

        public void PlaySound()
        {
            if (_settingsContainer.SoundOn)
            {
                _sound?.Play();
            }
        }

        protected override void OnDisable()
        {
            onClick.RemoveListener(PlaySound);
            base.OnDisable();
        }
    }
}

