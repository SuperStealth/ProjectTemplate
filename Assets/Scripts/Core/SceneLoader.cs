using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game.Core
{
    public class SceneLoader : MonoBehaviour
    {
        private const int MainSceneId = 1;

        private static SceneLoader instance;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }

        public static void LoadMainScene(UnityAction<Scene, LoadSceneMode> onSceneLoaded)
        {
            SceneManager.LoadSceneAsync(MainSceneId);
            SceneManager.sceneLoaded += onSceneLoaded;
        }
    }
}