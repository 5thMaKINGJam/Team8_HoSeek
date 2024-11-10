using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLogo : MonoBehaviour
{
    void Start (){
        string trueEndTitle = AchieveManager.achvManager.achieveTitle[4];
        if(AchieveManager.achvManager.achVals[trueEndTitle]!=-1){
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
        }
    }
}
