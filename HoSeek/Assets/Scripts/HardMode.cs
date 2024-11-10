using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HardMode : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] Image[] imagePannel = new Image[2];
    public TimeAttack timeAttack;

    int cnt = 0;

    void Start(){
        timeAttack.gameObject.SetActive(false);
        if(!PlayerDataManager.pdata.isWis()){
            gameObject.SetActive(false);
        }
        cnt = 0;
    }
    public void ShowIllust(){
        imagePannel[cnt].gameObject.SetActive(true);
        if(cnt == 0){
            cnt++;
        }
        else{
            Invoke("IllustOff",3f);
        }
    }
    void IllustOff(){
        AchieveManager.achvManager.EnterHardMode();
        imagePannel[cnt].gameObject.SetActive(false);
        timeAttack.gameObject.SetActive(true);
        timeAttack.SetTime();
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ShowIllust();
    }
}
