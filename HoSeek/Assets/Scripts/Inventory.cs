using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[System.Serializable]
class Items{
    public Item[] ItemList;
}

[System.Serializable]
class Item{
    public int id;
    public string name;
    public string type;
    public string etc;
}

public class Inventory : MonoBehaviour,IPointerClickHandler
{
    public static Inventory imanager;
    [SerializeField] Image invenSlot;
    [SerializeField] Image itemImg;
    [SerializeField] TextMeshProUGUI itemString;
    public Sprite emptySprite;
    public Sprite filledSprite;
    public Sprite SelectedSprite;

    bool isSelected = false;
    bool isEmpty = true;
    int itemId = -1;

    Item[] items;

    void Awake(){
        imanager = this;
    }
    void Start(){
        InitItemList();
        ClearSlot();
    }
    void InitItemList(){
        Items itemList = JsonUtility.FromJson<Items>(Resources.Load<TextAsset>("ItemList").text);
        items = itemList.ItemList;
    }

    public void SetItem(int id){
        if(!isEmpty){
            return;
        }
        isEmpty = false;
        itemId = id;
        invenSlot.sprite = filledSprite;
        itemImg.gameObject.SetActive(true);
        itemImg.sprite = Resources.Load<Sprite>(Const.ITEMSP_PATH_BASE+itemId.ToString());
        itemString.text = items[itemId].name;
    }
    public void OnPointerClick(PointerEventData eventData){
        if(isSelected||isEmpty){
            return;
        }
        isSelected = true;
        invenSlot.sprite = SelectedSprite;
    }

    public void UseItem(){
        if(!isSelected||isEmpty){
            return;
        }
        ClearSlot();
    }
    void ClearSlot(){
        isSelected = false;
        isEmpty = true;
        itemId = -1;
        invenSlot.sprite = emptySprite;
        itemImg.gameObject.SetActive(false);
        itemString.text = "";
    }

    public bool IsEmpty(){
        return isEmpty;
    }
    public int getId(){
        return itemId;
    }
    public string getItemType(){
        return items[itemId].type;
    }
    public string getEtc(){
        return items[itemId].etc;
    }
    public bool GetisSelected(){
        return isSelected;
    }
}
