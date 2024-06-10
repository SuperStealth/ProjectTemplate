using Game.Views;
using UnityEngine;

namespace Game.Core
{
    public class GameContainer : MonoBehaviour
    {
        [SerializeField] private LoadingWindow loadingWindow;
        [SerializeField] private SoundsContainer soundsContainer;
        [SerializeField] private SettingsContainer settingsContainer;

        public static GameContainer Instance { get; private set; }

        public static SettingsContainer SettingsContainer { get => Instance.settingsContainer; }
        public static SoundsContainer SoundsContainer { get => Instance.soundsContainer; }

        public static LoadingWindow LoadingWindow { get => Instance.loadingWindow; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}