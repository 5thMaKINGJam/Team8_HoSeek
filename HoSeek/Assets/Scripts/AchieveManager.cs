using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : MonoBehaviour
{
    public static AchieveManager achvManager;
    public string[] achieveTitle = {"고호속도로","죽음","생존1","생존2","산중호걸","당황","동족상잔","학습능력없음"};
    public Dictionary<string,int> achVals = new Dictionary<string,int>();
    public string[] achieveDetail = {
        "빠른 탈출, 빠른 호랑이.",
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
    public bool isNewAchv = false;
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
            achVals.Add(achieveTitle[i],PlayerPrefs.GetInt(achieveTitle[i]));
        }
        PlayerPrefs.Save();
    }
    public void AppendNewAchieve(){
        isNewAchv = false;
        if(newlyAchive!=""){
            isNewAchv = true;
        }
        string[] ach = newlyAchive.Split('_');
        newlyAchive = "";
        for(int i = 1; i<ach.Length; i++){
            achVals[ach[i]]=-1;
        }
        for(int j = 0; j<8; j++){
            PlayerPrefs.SetInt(achieveTitle[j],achVals[achieveTitle[j]]);
        }
        PlayerPrefs.Save();
    }

    public void NewEnding(int edType, int edNum){
        string ending = "";
        switch(edType*10+edNum){
            case 1:
                ending = achieveTitle[4];
                break;
            case 11:
                ending = achieveTitle[2];
                break;
            case 12:
                ending = achieveTitle[3];
                break;
            case 21:
                ending = achieveTitle[1];
                break;
            default:
                break;
        }
        if(ending!="" && achVals[ending]!=-1){
            newlyAchive+="_"+ending;
        }
        if(achVals[achieveTitle[0]]!=-1&&currTime<60f){
            newlyAchive+="_"+achieveTitle[0];
        }
    }

    public void EnterHardMode(){
        if(achVals[achieveTitle[5]]!=-1){
            newlyAchive += "_"+achieveTitle[5];
        }
    }

    public void EatMeat(){
        if(achVals[achieveTitle[6]]!=-1){
            achVals[achieveTitle[6]]++;
        }
        if(achVals[achieveTitle[6]]>=5){
            newlyAchive += "_"+achieveTitle[6];
        }
    }

    public void GetHurt(){
        if(achVals[achieveTitle[7]]!=-1){
            achVals[achieveTitle[7]]++;
        }
        if(achVals[achieveTitle[7]]>=5){
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
        Debug.Log("Time: "+currTime+"sec");
    }
}
