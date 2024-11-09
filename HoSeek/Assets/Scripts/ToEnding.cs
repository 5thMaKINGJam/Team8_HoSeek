using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
enum EndingType{
    HAPPY,
    NORMAL,
    BAD
}
public class ToEnding : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ConvSystem convSystem;
    EndingType endingType = EndingType.NORMAL;
    int endingNum = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!Inventory.imanager.IsEmpty() && Inventory.imanager.GetisSelected()){
            switch(Inventory.imanager.getId()){
                case 2: // 판자
                    if(PlayerDataManager.pdata.isHurt){
                        endingType = EndingType.NORMAL;
                        endingNum = 2;
                    }
                    else{
                        endingType = EndingType.HAPPY;
                        endingNum = 1;
                    }
                    ToEndScene();
                    return;
                case 3: //보석
                    endingType = EndingType.NORMAL;
                    endingNum = 1;
                    ToEndScene();
                    return;
                default:
                    break;
            }
        }
        convSystem.gameObject.SetActive(true);
        convSystem.SetConv(1);

    }
    public void TimeoutEinding(){
        endingType = EndingType.BAD;
        endingNum = 1;
        ToEndScene();
    }

    void ToEndScene(){
        // 엔딩씬 연결 필요
        Debug.Log("Ending.");
    }
}
