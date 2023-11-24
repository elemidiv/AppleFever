using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    [SerializeField] private AudioClip[] _soundtracks;
    private AudioSource AudioSource;
    [SerializeField] private GameObject _mute;
    [SerializeField] private GameObject _unmute;

    void Start()
    {
        
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = _soundtracks[Random.Range(0, _soundtracks.Length)];
        AudioSource.Play();

        if (PlayerPrefs.GetInt("volume", 1) == 0)
        {
            _mute.SetActive(true);
            _unmute.SetActive(false);
            AudioListener.volume = 0;
        }
        else
        {
            _mute.SetActive(false);
            _unmute.SetActive(true);
            AudioListener.volume = 1;
        }
    }

    public void Unmute()
    {
        PlayerPrefs.SetInt("volume", 1);
        AudioListener.volume = 1;
    }

    public void Mute()
    {
        PlayerPrefs.SetInt("volume", 0);
        AudioListener.volume = 0;
    }
}
