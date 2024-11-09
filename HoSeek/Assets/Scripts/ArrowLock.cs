using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrowLock : MonoBehaviour
{
    [SerializeField] Button[] arrowButton = new Button[4];
    // 0:up, 1:down, 2:left, 3:right

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
            Debug.Log("Answer Correct: "+pwAnswer.ToString());
        }
        else{
            Debug.Log("PW Wrong: "+currAnswer.ToString());
        }
        
    }
}
