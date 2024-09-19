using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip mine;
    public AudioClip footstep;
    public AudioClip rocketBuilt;
    
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


}
