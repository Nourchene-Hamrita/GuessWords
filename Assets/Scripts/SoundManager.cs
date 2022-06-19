using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{ 
    private bool _muteBackgroundMusic = false;
    private bool _muteSoundEffects = false;



    public static SoundManager instance;
    private AudioSource _audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    
    public void ToggleBackgroundMusic()
    {
        _muteBackgroundMusic =  ! _muteBackgroundMusic;
        if (_muteBackgroundMusic)
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.Play();
        }
    }
    public void ToggleSoundEffects()
    {
        _muteSoundEffects = !_muteSoundEffects;
        GameEvents.ToggleSoundEffectsMethod();
    }
    public bool IsBachgroundMusicMuted()
    {
        return _muteBackgroundMusic;
    }
    public bool IsSoundEffectsMuted()
    {
        return _muteSoundEffects;
    }
    public void SilenceBackgroundMusic(bool silence)
    {
        if (_muteBackgroundMusic == false)
        {
            if (silence)
            {
                _audioSource.volume = 0f;
            }
            else
            {
                _audioSource.volume = 1f;
            }
        }
    }
}
