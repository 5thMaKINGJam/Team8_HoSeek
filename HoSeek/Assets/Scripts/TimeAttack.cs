using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    bool setTime = false;
    int min = 0;
    int sec = 0;

    float currTime = 0;

    void Start(){
        timerText.text = "";
    }
    public void SetTime(){
        if(setTime){
            return;
        }
        currTime = 180f;
        setTime = true;
        SetTimeText(currTime);
    }

    void Update(){
        if(!setTime){
            return;
        }
        if(currTime>0){
            currTime -= Time.deltaTime;
            SetTimeText(currTime);
        }
        else{
            currTime = 0;
            SetTimeText(currTime);
            Debug.Log("Time Over");
        }
    }

    void SetTimeText(float time){
        min = (int)currTime/60;
        sec = (int)currTime%60;
        timerText.text = min.ToString("00")+" : "+sec.ToString("00");
    }
}
