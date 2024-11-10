using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource;

    public AudioClip audioEat;
    public AudioClip audioJumpScare;
    public AudioClip audioCantOpen;
    public AudioClip audioPickBook;
    public AudioClip audioPickKey;
    public AudioClip audioPickNote;
    public AudioClip audioBlanket;
    public AudioClip audioGetCut;
    public AudioClip audioPickBoard;
    public AudioClip audioBreak;
    public AudioClip audioPickGem;
    public AudioClip audioWind;
    public AudioClip audioPlaceBoard;
    public AudioClip audioOpenDrawer;
    public AudioClip audioOpenCloset;
    public AudioClip audioClick;
    public AudioClip audioChop;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int id)
    {
        switch (id)
        {
            case 1:
                audioSource.clip = audioCantOpen;
                break;
            case 4001:
                audioSource.clip = audioPickBook;
                break;
            case 1002:
                audioSource.clip = audioEat;
                break;
            case 2004:
                audioSource.clip = audioPickKey;
                break;
            case 3001:
            case 6002:
                audioSource.clip = audioPickNote;
                break;
            case 5001:
                audioSource.clip = audioBlanket;
                break;
            case 5004:
            case 5005:
                audioSource.clip = audioGetCut;
                break;
            case 7002:
                audioSource.clip = audioBreak;
                break;
            case 9001:
                audioSource.clip = audioPickGem;
                break;
        }

        PlaySound();
    }

    void PlaySound()
    {
        if (audioSource.isPlaying)
        {
            return;
            //audioSource.Stop();
        }
        audioSource.Play();
    }


    public void ObjectPlaySound(int objectId)
    {
            switch (objectId)
        {
            case 0: case 1:
                audioSource.clip = audioPickKey;
                break;

            case 2:
                audioSource.clip = audioPickBoard;
                break;

            case 3:
                audioSource.clip = audioOpenCloset;
                break;

            }
        PlaySound();
    }

}
