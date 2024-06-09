using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
