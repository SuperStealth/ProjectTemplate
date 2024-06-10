using Game.Views;
using UnityEngine;

namespace Game.Core
{
    public class AssetsContainer : MonoBehaviour
    {
        [SerializeField] private LoadingWindow loadingWindow;
        [SerializeField] private SoundsContainer soundsContainer;
        [SerializeField] private SettingsContainer settingsContainer;

        public static AssetsContainer Instance {get; private set;}

        public SettingsContainer SettingsContainer { get => settingsContainer; }
        public SoundsContainer SoundsContainer { get => soundsContainer; }

        public LoadingWindow LoadingWindow { get => loadingWindow; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}