using Game.Views;
using UnityEngine;

namespace Game.Core
{
    public class AssetsContainer : MonoBehaviour
    {
        [SerializeField] private LoadingWindow loadingWindow;
        public static AssetsContainer Instance {get; private set;}

        public LoadingWindow LoadingWindow { get => loadingWindow; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}