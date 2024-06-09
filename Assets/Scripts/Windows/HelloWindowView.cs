using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
namespace Game.Views
{
    public class HelloWindowView : MonoBehaviour
    {
        [SerializeField] private Button nextButton;

        private void OnEnable()
        {
            nextButton.onClick.AddListener(OpenMainScreen);
        }

        private void OpenMainScreen()
        {
            SceneLoader.LoadMainScene();
        }

        private void OnDisable()
        {
            nextButton.onClick.RemoveListener(OpenMainScreen);
        }
    }
}