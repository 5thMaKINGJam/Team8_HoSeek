using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PWLock : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] pwText = new TextMeshProUGUI[3];

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

    public void ButtonDOWN(int idx){
        pwInt[idx]--;
        if(pwInt[idx]<0){
            pwInt[idx] = 9;
        }
        pwInt[idx]%=10;
        pwText[idx].text = pwInt[idx].ToString();
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
