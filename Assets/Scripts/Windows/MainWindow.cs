using Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class MainWindow : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button restartButton;
        [SerializeField] private Button settingsButton;
        
        [Space(10)]
        [Header("Windows")]
        [SerializeField] private SettingsWindow settingsWindow;

        private void OnEnable()
        {
            settingsButton.onClick.AddListener(OpenSettings);
            restartButton.onClick.AddListener(RestartGame);
        }
        
        private void RestartGame()
        {
            SceneLoader.LoadMainScene();
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