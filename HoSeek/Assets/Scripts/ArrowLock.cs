using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrowLock : MonoBehaviour
{
    [SerializeField] Button[] arrowButton = new Button[4];
    // 0:up, 1:down, 2:left, 3:right
    [SerializeField] ConvSystem convSystem;

    [SerializeField] ObjFunc target;

    const string pwAnswer = "3021";
    string currAnswer = "";
    int[] pwInt = {0,0,0,0};

    void OnDisable(){
        currAnswer = "";
        for(int i = 0; i<pwInt.Length; i++){
            pwInt[i] = 0;
            arrowButton[i].GetComponentInChildren<TextMeshProUGUI>().text = pwInt[i].ToString("00");
        }
    }

    public void ClickButton(int idx){
        pwInt[idx]++;
        arrowButton[idx].GetComponentInChildren<TextMeshProUGUI>().text = pwInt[idx].ToString("00");
        currAnswer = "";
        for(int i = 0; i<pwInt.Length; i++){
            currAnswer+=pwInt[i].ToString();
        }
        if(currAnswer==pwAnswer){
            convSystem.gameObject.SetActive(true);
            if(!Inventory.imanager.IsEmpty()){
                convSystem.SetConv(3);
                gameObject.SetActive(false);
                return;
            }
            convSystem.SetConv(2004);
            Inventory.imanager.SetItem(0);
            target.unabled = false;
            gameObject.SetActive(false);

        }
        else{
            Debug.Log("PW Wrong: "+currAnswer.ToString());
        }
        
    }
}
