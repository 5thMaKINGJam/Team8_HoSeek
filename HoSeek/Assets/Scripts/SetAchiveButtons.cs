using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetAchiveButtons : MonoBehaviour
{
    [SerializeField] Button[] buttons = new Button[8];
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI detailText;
    void OnEnable(){
        for(int i = 0; i<8; i++){
            Debug.Log(AchieveManager.achvManager.achieveTitle[i]+": "+PlayerPrefs.GetInt(AchieveManager.achvManager.achieveTitle[i]));
            if(PlayerPrefs.GetInt(AchieveManager.achvManager.achieveTitle[i])==-1){
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = AchieveManager.achvManager.achieveTitle[i];
            }
            else{
                buttons[i].interactable = false;
            }
        }
    }

    public void SetDetail(int idx){
        titleText.text = AchieveManager.achvManager.achieveTitle[idx];
        detailText.text = AchieveManager.achvManager.achieveDetail[idx];
    }
}
