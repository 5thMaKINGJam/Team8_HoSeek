using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] ToEnding toEnding;
    bool setTime = false;
    int min = 0;
    int sec = 0;

    float currTime = 0;

    bool isRed = false;
    float redTime = 0;

    void Start(){
        timerText.text = "";
    }
    public void SetTime(){
        if(setTime){
            return;
        }
        currTime = 180f;
        setTime = true;
        PlayerDataManager.pdata.isHardMode = true;
        SetTimeText(currTime);
    }

    void Update(){
        if(!setTime){
            return;
        }
        if(currTime>0){
            currTime -= Time.deltaTime;
            SetTimeText(currTime);
            if(isRed){
                redTime -=Time.deltaTime;
                if(redTime < 0){
                    isRed = false;
                    redTime = 0;
                }
            }
        }
        else{
            currTime = 0;
            SetTimeText(currTime);
            toEnding.TimeoutEinding();
        }
    }

    void SetTimeText(float time){
        min = (int)currTime/60;
        sec = (int)currTime%60;
        timerText.text = min.ToString("00")+" : "+sec.ToString("00");
        if(isRed){
            timerText.text = "<color=\"red\">"+timerText.text +"</color>";
        }
    }

    public void Penalty(){
        currTime-=30f;
        isRed = true;
        redTime = 1f;
    }
}
