using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartScene : MonoBehaviour
{
    [SerializeField] GameObject notice;
    [SerializeField] AudioSource audio;
    void Start(){
        if(AchieveManager.achvManager.isNewAchv){
            notice.SetActive(true);
        }
    }
    

    public void StartButton()
    {
        audio.Play();
        Invoke("LoadStrat",0.5f );
    }
    public void LoadStrat(){

        SceneManager.LoadScene("StatScene");
    }
}
