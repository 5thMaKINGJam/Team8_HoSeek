using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseEnding : MonoBehaviour, IPointerClickHandler
{
    public int thisId;
    public int otherId;
    public int tempId;
    public int getConvId;
    public int soundId;

    [SerializeField] ConvSystem convSystem;
    [SerializeField] GameObject otherObj;
    public void OnPointerClick(PointerEventData eventData)
    {
       

        if(!Inventory.imanager.IsEmpty()){
            convSystem.gameObject.SetActive(true);
            convSystem.chooseEnding = this;
            int convId = otherId==Inventory.imanager.getId()?8002:8001;
            convSystem.SetConv(convId);
        }
        else{
            Inventory.imanager.SetItem(thisId);
            convSystem.gameObject.SetActive(true);;
            convSystem.SetConv(getConvId);
            PlayObjectSound();
            gameObject.SetActive(false);
        }

    }

    void PlayObjectSound()
    {
        switch (soundId)
        {
            case 1:
                SoundManager.instance.PlaySoundPickBoard();
                Debug.Log("sound call 1");
                break;
            case 2:
                SoundManager.instance.PlaySoundPickKey();
                Debug.Log("sound call 2");
                break;
            default:
                break;
        }
    }


    public void SwapItem(){
        PlayObjectSound();
        if(otherId==Inventory.imanager.getId()){
            otherObj.SetActive(true);
        }
        Inventory.imanager.ClearSlot();
        Inventory.imanager.SetItem(thisId);
        gameObject.SetActive(false);
    }
}
