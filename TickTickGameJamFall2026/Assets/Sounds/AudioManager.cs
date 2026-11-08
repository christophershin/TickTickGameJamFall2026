using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public enum BananaSound
    {
        Throw,
        Hit,
        Return
    }
    
    [Header("References")]
    [SerializeField] private AudioSource audioSource;

    [System.Serializable]
    public struct BananaAudios
    {
        public AudioClip bananaThrow, bananaHit, bananaReturn;
    }

    private Dictionary<BananaSound, AudioClip> bananaClips;
    
    private void BuildBananaClips()
    {
        bananaClips = new Dictionary<BananaSound, AudioClip>
        {
            { BananaSound.Throw, bananaAudios.bananaThrow },
            { BananaSound.Hit, bananaAudios.bananaHit },
            { BananaSound.Return, bananaAudios.bananaReturn }
        };
    }

    [SerializeField] private BananaAudios bananaAudios;

    public void playBananaAudio(BananaSound sound)
    {
        if (bananaClips == null) BuildBananaClips();
        if (bananaClips.TryGetValue(sound, out AudioClip clip) && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}