using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource;
    private AudioSource bgmAudioSource;

    public AudioClip bgmClip;
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

        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource.loop = true;
        bgmAudioSource.volume = 0.5f;
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (bgmClip != null)
        {
            bgmAudioSource.clip = bgmClip;
            bgmAudioSource.Play();
        }
    }

    public void StopBGM()
    {
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Stop();
        }
    }

    public void PlaySound(int id)
    {
        audioSource.clip = null;

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
            default:
                return;
        }

        PlaySound();
    }


void PlaySound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        if (audioSource.clip == null)
        {
            return;
        }

        audioSource.Play();
    }

    public void PlaySoundChop()
    {
        audioSource.clip = audioChop;
        audioSource.Play();
    }

    public void PlaySoundJumpScare()
    {
        audioSource.clip = audioJumpScare;
        audioSource.Play();
    }

    public void PlaySoundOpenCloset()
    {
        audioSource.clip = audioOpenCloset;
        audioSource.Play();
    }

    public void PlaySoundPickBoard()
    {
        Debug.Log("PlaySoundPickBoard()");
        audioSource.clip = audioPickBoard;
        audioSource.Play();
        Debug.Log(audioSource.isPlaying);
    }

    public void PlaySoundPickKey()
    {
        Debug.Log("PlaySoundPickKey()");
        audioSource.clip = audioPickKey;
        audioSource.Play();
        Debug.Log(audioSource.isPlaying);
    }

    public void PlaySoundPlaceBoard()
    {
        audioSource.clip = audioPlaceBoard;
        audioSource.Play();
    }

    public void PlaySoundOpenDrawer()
    {
        audioSource.clip = audioOpenDrawer;
        audioSource.Play();
    }

    public void PlaySoundClick()
    {
        if (audioClick != null)
        {
            audioSource.PlayOneShot(audioClick);
        }
    }
}

