using UnityEngine;

namespace Game.Core
{
    public class BackgroundMusicHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundMusic;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            _backgroundMusic.Play();
        }

        private void OnDisable()
        {
            _backgroundMusic.Stop();
        }
    }
}