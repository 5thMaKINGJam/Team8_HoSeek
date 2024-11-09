using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : MonoBehaviour
{
    public static AchieveManager achvManager;
    public string[] achieveTitle = {"고호속도로","죽음","생존1","생존2","산중호걸","당황","동족상잔","학습능력없음"};
    public string[] achieveDetail = {
        "갇힌지 1분 안에 탈출한 적이 있다.",
        "Bad Ending: 살아남지 못했다.",
        "Normal Ending 1: 탈출에 성공하였다.",
        "Normal Ending 2: 복수를 다짐했다.",
        "True Ending: 배부른 식사를 하였다.",
        "누군가와 눈이 마주쳤다.",
        "정말 맛없고 질긴 고기였어...",
        "어떤 멍청한 놈이 이불 안에 그런 걸 둔 건지."};
    string newlyAchive="";
    bool setTimer = false;
    float currTime = 0f;
    void Awake(){
        //PlayerPrefs.DeleteAll();
        if(achvManager == null){
            achvManager = this;
            DontDestroyOnLoad(achvManager);
        }
        else if(achvManager!=this){
            Destroy(this);
            return;
        }
        for(int i = 0; i<achieveTitle.Length; i++){
            if(!PlayerPrefs.HasKey(achieveTitle[i])){
                PlayerPrefs.SetInt(achieveTitle[i],0);
            }
        }
        PlayerPrefs.Save();
    }
    public void AppendNewAchieve(){
        string[] ach = newlyAchive.Split('_');
        newlyAchive = "";
        for(int i = 1; i<ach.Length; i++){
            PlayerPrefs.SetInt(ach[i],-1);
        }
        PlayerPrefs.Save();
    }

    public void NewEnding(int edType, int edNum){
        string ending = "";
        switch(edType*10+edNum){
            case 1:
                ending += achieveTitle[4];
                break;
            case 11:
                ending += achieveTitle[2];
                break;
            case 12:
                ending += achieveTitle[3];
                break;
            case 21:
                ending += achieveTitle[1];
                break;
            default:
                break;
        }
        if(ending!="" && PlayerPrefs.GetInt(ending)!=-1){
            newlyAchive+="_"+ending;
        }
        if(PlayerPrefs.GetInt(achieveTitle[0])!=-1&&currTime<60f){
            newlyAchive+="_"+achieveTitle[0];
        }
    }

    public void EnterHardMode(){
        newlyAchive += "_"+achieveTitle[5];
    }

    public void EatMeat(){
        if(PlayerPrefs.GetInt(achieveTitle[6])!=-1){
            PlayerPrefs.SetInt(achieveTitle[6],PlayerPrefs.GetInt(achieveTitle[6])+1);
        }
        if(PlayerPrefs.GetInt(achieveTitle[6])>=5){
            newlyAchive += "_"+achieveTitle[6];
        }
    }

    public void GetHurt(){
        if(PlayerPrefs.GetInt(achieveTitle[7])!=-1){
            PlayerPrefs.SetInt(achieveTitle[7],PlayerPrefs.GetInt(achieveTitle[6])+1);
        }
        if(PlayerPrefs.GetInt(achieveTitle[7])>=5){
            newlyAchive += "_"+achieveTitle[7];
        }
    }

    public void SetTimer(){
        setTimer = true;
    }

    void Update(){
        if(setTimer){
            currTime+=Time.deltaTime;
        }
    }
    public void StopTimer(){
        setTimer = false;
    }
}
