using System;
using UnityEngine;

namespace Game.Core
{
    public class SettingsContainer : MonoBehaviour
    {
        private const string MusicOnPrefsKey = "music_on";
        private const string SoundOnPrefsKey = "sound_on";

        public Action<bool> OnMusicStateChanged;
        public Action<bool> OnSoundStateChanged;

        public bool MusicOn
        {
            get => PlayerPrefs.GetInt(MusicOnPrefsKey, 0) == 1;
            set
            {
                PlayerPrefs.SetInt(MusicOnPrefsKey, value ? 1 : 0);
                OnMusicStateChanged?.Invoke(value);
            }
        }

        public bool SoundOn
        {
            get => PlayerPrefs.GetInt(SoundOnPrefsKey, 0) == 1;
            set
            {
                PlayerPrefs.SetInt(SoundOnPrefsKey, value ? 1 : 0);
                OnSoundStateChanged?.Invoke(value);
            }
        }
    }
}