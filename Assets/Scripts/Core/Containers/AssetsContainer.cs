using UnityEngine;

namespace Game.Core
{
    public class AssetsContainer : MonoBehaviour
    {
        public AssetsContainer Instance {get; private set;}

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}