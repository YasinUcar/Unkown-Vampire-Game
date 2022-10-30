using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource sfxSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        sfxSound = gameObject.AddComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlaySound(AudioClip clip)
    {
        if (sfxSound.isPlaying != true)
            sfxSound.PlayOneShot(clip);
    }
}
