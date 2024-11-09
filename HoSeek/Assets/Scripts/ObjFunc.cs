using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjFunc : MonoBehaviour,IPointerClickHandler
{
    public int id;
    public string[] interType = {"Default"};
    public string etc = "";

    public bool dontDeactivate = false;

    [SerializeField] GameObject MainObj;
    [SerializeField] ConvSystem StoryObj;

    int spriteIdx = 0;
    int maxIdx = 0;

    void Start(){
        if(interType[0]=="ChangeForm"){
            maxIdx = transform.childCount;
            for(int i = 0; i< maxIdx; i++){
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.GetChild(spriteIdx).gameObject.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        for(int i = 0; i<interType.Length; i++){
            Debug.Log(interType[i]);
            Invoke(interType[i],0f);
        }
    }

    void Default(){
        return;
    }
    
    void ObtainItem(){
        if(!Inventory.imanager.IsEmpty()){
            return;
        }
        Inventory.imanager.SetItem(int.Parse(etc));
        DeactivateSelf();
    }

    void CombineWithItem(){
        int target = int.Parse(etc.Split('_')[0]);
        int result = int.Parse(etc.Split('_')[1]);

        if(Inventory.imanager.IsEmpty()||!Inventory.imanager.GetisSelected()){
            return;
        }

        int invenItem = Inventory.imanager.getId();

        if(invenItem<0 || Inventory.imanager.getItemType() != "ADDWITH_MAP"){
            return;
        }
        string[] invenEtc = Inventory.imanager.getEtc().Split('_');
        if( invenItem == target && int.Parse(invenEtc[0]) == id){
            Inventory.imanager.UseItem();
            Inventory.imanager.SetItem(result);
            DeactivateSelf();
        }
    }

    void ActionWithItem(){
        string[] thisEtc = etc.Split('_');
        int target = int.Parse(thisEtc[0]);
        string action = thisEtc[1];

        if(Inventory.imanager.IsEmpty()||!Inventory.imanager.GetisSelected()){
            return;
        }

        int invenItem = Inventory.imanager.getId();
        if(invenItem<0 || Inventory.imanager.getItemType() != "ADDWITH_MAP"){
            return;
        }
        string[] invenEtc = Inventory.imanager.getEtc().Split('_');
        if( invenItem == target && int.Parse(invenEtc[0]) == id){
            Inventory.imanager.UseItem();
            etc = "";
            for(int i = 2; i<thisEtc.Length; i++){
                etc+=thisEtc[i];
                if(i!=thisEtc.Length-1){
                    etc+="_";
                }
            }
            Invoke(action,0f);
        }
    }

    void ChangeForm(){
        transform.GetChild(spriteIdx).gameObject.SetActive(false);
        spriteIdx++;
        spriteIdx%=maxIdx;
        transform.GetChild(spriteIdx).gameObject.SetActive(true);
    }

    void DeactivateSelf(){
        if(dontDeactivate){
            return;
        }
        gameObject.SetActive(false);
    }

    void ActivateObj(){
        MainObj.transform.GetChild(int.Parse(etc)).gameObject.SetActive(true);
    }

    void SetConv(){
        // etc 형식: initScriptID_defaultScriptID_isDefault
        string[] thisEtc = etc.Split('_');
        int scrptId = 0;
        if(thisEtc[2]=="1"){
            scrptId = int.Parse(thisEtc[1]);
        }
        else{
            scrptId = int.Parse(thisEtc[0]);
            etc = thisEtc[0]+"_"+thisEtc[1]+"_1";
        }
        StoryObj.gameObject.SetActive(true);
        StoryObj.SetConv(scrptId);
    }
}
