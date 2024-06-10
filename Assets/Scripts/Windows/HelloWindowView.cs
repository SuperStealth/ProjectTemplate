using Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class HelloWindowView : MonoBehaviour
    {
        [SerializeField] private Button nextButton;
        [SerializeField] private AssetsContainer assetsContainer;

        private void OnEnable()
        {
            nextButton.onClick.AddListener(OpenMainScreen);
        }

        private void OpenMainScreen()
        {
            var loadingWindow = AssetsContainer.Instance.LoadingWindow;
            loadingWindow.OnWindowShown = () => SceneLoader.LoadMainScene(loadingWindow.UpdateSceneLoaded);
            loadingWindow.Show();
        }

        private void OnDisable()
        {
            nextButton.onClick.RemoveListener(OpenMainScreen);
        }
    }
}