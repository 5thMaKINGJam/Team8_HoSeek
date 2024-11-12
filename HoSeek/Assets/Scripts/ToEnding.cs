using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

enum EndingType{
    HAPPY,
    NORMAL,
    BAD
}
public class ToEnding : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ConvSystem convSystem;
    [SerializeField] GameObject hardModeObj;
    EndingType endingType = EndingType.NORMAL;
    int endingNum = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!Inventory.imanager.IsEmpty() && Inventory.imanager.GetisSelected()){
            switch(Inventory.imanager.getId()){
                case 2: // 판자
                    SoundManager.instance.PlaySoundPlaceBoard();
                    if (PlayerDataManager.pdata.isHurt){
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

    void ToEndScene()
    {
        AchieveManager.achvManager.StopTimer();
        AchieveManager.achvManager.NewEnding((int)endingType,endingNum);
        AchieveManager.achvManager.AppendNewAchieve();
        PlayerDataManager.pdata.ClearPlayerData();
        Inventory.imanager.ClearSlot();
        hardModeObj.SetActive(true);
        if (endingType == EndingType.NORMAL && endingNum == 2)
        {
            SceneManager.LoadScene("Ending3_Normal2");
        }
        else if (endingType == EndingType.HAPPY && endingNum == 1)
        {
            SceneManager.LoadScene("Ending1_Happy");
        }
        else if (endingType == EndingType.NORMAL && endingNum == 1)
        {
            SceneManager.LoadScene("Ending2_Normal1");
        }
        else if (endingType == EndingType.BAD)
        {
            SceneManager.LoadScene("Ending4_Bad");
        }
    }

}
