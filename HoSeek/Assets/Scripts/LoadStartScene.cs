using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartScene : MonoBehaviour
{
    [SerializeField] GameObject notice;
    void Start(){
        if(AchieveManager.achvManager.isNewAchv){
            notice.SetActive(true);
        }
    }
    public void LoadStrat(){
        SceneManager.LoadScene("StatScene");
    }
}
