using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PWLock : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] pwText = new TextMeshProUGUI[3];
    [SerializeField] ObjFunc target;
    [SerializeField] GameObject activateObj;

    const string pwAnswer = "724";
    string currAnswer = "";
    int[] pwInt = {0,0,0};

    void OnDisable(){
        currAnswer = "";
        for(int i = 0; i<pwInt.Length; i++){
            pwInt[i] = 0;
            pwText[i].text = pwInt[i].ToString();
        }
    }

    public void ButtonUP(int idx){
        pwInt[idx]++;
        pwInt[idx]%=10;
        pwText[idx].text = pwInt[idx].ToString();
        CheckAnswer();
    }

    public void ButtonDOWN(int idx){
        pwInt[idx]--;
        if(pwInt[idx]<0){
            pwInt[idx] = 9;
        }
        pwInt[idx]%=10;
        pwText[idx].text = pwInt[idx].ToString();
        CheckAnswer();
    }

    void CheckAnswer(){
        currAnswer = "";
        for(int i = 0; i<pwInt.Length; i++){
            currAnswer+=pwInt[i].ToString();
        }
        if(currAnswer==pwAnswer){
            Debug.Log("Correct Answer: "+currAnswer.ToString());
            target.unabled = false;
            target.MainObj = activateObj;
            gameObject.SetActive(false);
        }
        else{
            Debug.Log("PW Wrong: "+currAnswer.ToString());
        }
    }
}
