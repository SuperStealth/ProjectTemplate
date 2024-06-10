using Game.Core;
using Game.Utils;
using UnityEngine;

namespace Game.Views
{
    public class HelloWindow : MonoBehaviour
    {
        [SerializeField] private SoundButton nextButton;
        [SerializeField] private GameContainer gameContainer;
        [SerializeField] private AudioSource buttonSound;

        private void OnEnable()
        {
            nextButton.onClick.AddListener(OpenMainScreen);
            nextButton.SetSound(buttonSound);
        }

        private void OpenMainScreen()
        {
            var loadingWindow = GameContainer.LoadingWindow;
            loadingWindow.OnWindowShown = () => SceneLoader.LoadMainScene(loadingWindow.UpdateSceneLoaded);
            loadingWindow.Show();
        }

        private void OnDisable()
        {
            nextButton.onClick.RemoveListener(OpenMainScreen);
        }
    }
}