using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class SoundsContainer : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> gameSounds;

        public AudioSource GetAudioSourceByClipName(string name)
        {
            return gameSounds.Find(x => x.name == name);
        }
    }
}