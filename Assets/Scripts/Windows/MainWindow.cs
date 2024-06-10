using Game.Core;
using Game.Utils;
using UnityEngine;

namespace Game.Views
{
    public class MainWindow : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private SoundButton restartButton;
        [SerializeField] private SoundButton settingsButton;
        
        [Space(10)]
        [Header("Windows")]
        [SerializeField] private SettingsWindow settingsWindow;

        private LoadingWindow loadingWindow;

        private void Awake()
        {
            loadingWindow = GameContainer.LoadingWindow;
        }

        private void OnEnable()
        {
            restartButton.SetSound("ClickSound");
            settingsButton.SetSound("ClickSound");
            settingsButton.onClick.AddListener(OpenSettings);
            restartButton.onClick.AddListener(RestartGame);
        }
        
        private void RestartGame()
        {
            loadingWindow.OnWindowShown = () => SceneLoader.LoadMainScene(loadingWindow.UpdateSceneLoaded);
            loadingWindow.Show();
        }

        private void OpenSettings()
        {
            settingsWindow.Show();
        }

        private void OnDisable()
        {
            settingsButton.onClick.RemoveListener(OpenSettings);
            restartButton.onClick.RemoveListener(RestartGame);
        }
    }
}