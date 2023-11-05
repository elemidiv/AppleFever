using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    [SerializeField] private AudioClip[] _soundtracks;
    private AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = _soundtracks[Random.Range(0, _soundtracks.Length)];
        AudioSource.Play();
    }

    void Update()
    {
        
    }
}
