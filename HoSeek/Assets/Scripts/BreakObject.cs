using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BreakObject : MonoBehaviour, IPointerClickHandler
{
    public ConvSystem convSystem;
    public GameObject orgDrawer;
    public Sprite brokenSprite;

    bool isBroken = false;
    public void BreakDrawer(){
        isBroken = true;
        orgDrawer.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = brokenSprite;   
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        convSystem.gameObject.SetActive(true);
        if(isBroken && Inventory.imanager.getId()==0){
            Inventory.imanager.UseItem();
            convSystem.SetConv(7003);
        }
        else if(!isBroken&&PlayerDataManager.pdata.isStr()){
            convSystem.SetConv(7004);
        }
        else{
            convSystem.SetConv(4001);
        }
    }

    bool IsBroken(){
        return isBroken;
    }
}
