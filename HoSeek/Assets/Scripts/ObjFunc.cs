using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjFunc : MonoBehaviour,IPointerClickHandler
{
    public int id;
    public string[] interType = {"Default"};
    public string unableAction = "";
    public string action = "";
    public int target;
    public string etc = "";
    public string unableEtc="";
    
    public string constraint="";
    public string constraintAction="";
    public string constraintEtc = "";

    public bool dontDeactivate = false;

    public GameObject MainObj;
    [SerializeField] ConvSystem StoryObj;

    int spriteIdx = 0;
    int maxIdx = 0;

    public bool unabled = false;
    private bool unabledFlag = false;
    private bool constraintFlag = false;

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
        if(unabled){
            Debug.Log("Unabled Click");
            Invoke(unableAction,0f);
            return;
        }
        for(int i = 0; i<interType.Length; i++){
            Debug.Log(interType[i]);
            Invoke(interType[i],0f);
        }
    }

    void Default(){
        return;
    }

    void DeactivateParent(){
        transform.parent.gameObject.SetActive(false);
    }

    void ModifyEtc(){
        etc = constraintEtc;
    }
    
    void ObtainItem(){
        if(!Inventory.imanager.IsEmpty()){
            return;
        }
        Inventory.imanager.SetItem(int.Parse(etc));
        DeactivateSelf();
    }

    void CombineWithItem(){
        int result = int.Parse(etc);

        if(Inventory.imanager.IsEmpty()||!Inventory.imanager.GetisSelected()){
            Unabled();
            return;
        }

        int invenItem = Inventory.imanager.getId();

        if(invenItem<0 || Inventory.imanager.getItemType() != "ADDWITH_MAP"){
            Unabled();
            return;
        }
        string invenEtc = Inventory.imanager.getEtc();
        if( invenItem == target && int.Parse(invenEtc) == id){
            Inventory.imanager.UseItem();
            Inventory.imanager.SetItem(result);
            interType[0] = "SetConv";
            etc = "4_4_1";
        }
    }

    void ActionWithItem(){
        // etc 형식 타겟아이템_action

        if(Inventory.imanager.IsEmpty()||!Inventory.imanager.GetisSelected()){
            Unabled();
            return;
        }

        int invenItem = Inventory.imanager.getId();
        if(Inventory.imanager.getItemType() != "ADDWITH_MAP"){
            Debug.Log("item type: "+Inventory.imanager.getItemType());
            Unabled();
            return;
        }
        int invenEtc = int.Parse(Inventory.imanager.getEtc());
        if( invenItem == target && invenEtc == id){
            Inventory.imanager.UseItem();
            string[] actions = action.Split('_');
            for(int i = 0; i<actions.Length; i++){
                Invoke(actions[i],0f);
            }
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
        MainObj.gameObject.SetActive(true);
    }

    void SetConv(){
        // etc 형식: initScriptID_defaultScriptID_isDefault
        string[] thisEtc = etc.Split('_');
        if(constraintFlag){
            thisEtc = constraintEtc.Split('_');
            constraintFlag = false;
            unabledFlag = false;
        }
        else if(unabledFlag){
            thisEtc = unableEtc.Split('_');
            unabledFlag = false;
        }
        else if(constraint!=""){
            switch(constraint){
                case "str":
                    if(PlayerDataManager.pdata.isStr()){
                        thisEtc = constraintEtc.Split();
                    }
                    break;
                case "int":
                    if(PlayerDataManager.pdata.isInt()){
                        thisEtc = constraintEtc.Split();
                    }
                    break;
                default:
                    break;
            }
        }
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

    void Unabled(){
        unabledFlag = true;
        if(constraint=="str"&&PlayerDataManager.pdata.isStr()){
            constraintFlag = true;
            Invoke(constraintAction,0f);
            return;
        }
        Invoke(unableAction,0f);
    }
}
