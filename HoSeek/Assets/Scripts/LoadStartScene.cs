using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartScene : MonoBehaviour
{
    [SerializeField] AudioSource audio;

    public void StartButton()
    {
        audio.Play();
        Invoke("LoadStrat",0.5f );
    }
    public void LoadStrat(){

        SceneManager.LoadScene("StatScene");
    }
}
