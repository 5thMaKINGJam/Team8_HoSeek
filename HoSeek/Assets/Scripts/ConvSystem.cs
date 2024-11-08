using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConvSystem : MonoBehaviour
{
    [SerializeField] GameObject convWin;
    [SerializeField] Image illustObj;
    [SerializeField] TextMeshProUGUI convText;
    [SerializeField] GameObject choiceWin;
    [SerializeField] Button[] buttons = new Button[4];
    

    private int storyMax = 0;
    private StoryObject storyObject;
    private Dictionary<int,ChoiceScript> choiceScripts = new Dictionary<int, ChoiceScript>();
    private int currIdx;
    private SingleScript currScript;

    // Text Effect 관련 변수
    private bool is_texteff = false;
    private int effect_cnt;
    private string completeDialogue;


    public void NextButton(){
        if(currScript.GetScriptType() != ScriptType.CHOICE && currScript.GetNextGoto() >= 0){
            currIdx = currScript.GetNextGoto();
        }
        else{
            currIdx++;
        }
        if(currIdx<storyObject.GetScriptLen()){
            SetConv(currIdx);
        }
        else{
            Debug.Log("EOF: Json end");
        }
        
    }

    public void ChoiceButton(int choiceIdx){    // 외부에서 call 할 때도 이 함수 사용
        currIdx = choiceScripts[currIdx].GetChoiceGoto(choiceIdx);
        SetConv(currIdx);   
    }
    
    void SetConv(int n){
        convWin.SetActive(true);

        choiceWin.SetActive(false);
        illustObj.gameObject.SetActive(false);
        convText.gameObject.SetActive(true);

        ScriptType prevType = (currScript==null)?ScriptType.NARR:currScript.GetScriptType();

        currScript = storyObject.GetScript(n);
        
            switch(currScript.GetScriptType()){
                case ScriptType.NARR:
                    Debug.Log(":: SetNarr() Call");
                    SetNarr();
                    break;
                case ScriptType.CHOICE:
                    Debug.Log(":: SetChoice() Call");
                    SetChoice();
                    break;
                case ScriptType.ILLUST_FULL:
                    SetFullIllust();
                    break;
                case ScriptType.END_CONV:
                    EndConv();
                    break;
                default:
                    Debug.Log("TYPE ERROR: "+n+"th script");
                    break;
            }
    }

    void SetNarr(){
        Debug.Log(currScript.GetContent());
        TextEffectStart(currScript.GetContent());
    }

    void SetChoice(){
        choiceWin.SetActive(true);
        for(int i =0; i<choiceScripts[currIdx].GetChoiceMax(); i++){
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = choiceScripts[currIdx].GetChoice(i);
        }
        for(int j = choiceScripts[currIdx].GetChoiceMax(); j < 4; j++){
            buttons[j].gameObject.SetActive(false);
        }
        SetNarr();
    }

    void SetFullIllust(){
        convWin.SetActive(false);
        convText.gameObject.SetActive(true);
        //illustObj.sprite = Resources.Load<Sprite>(Const.ILLUST_PATH_BASE +currScript.GetIllustNum().ToString());
    }

    void EndConv(){
        gameObject.SetActive(false);
    }

    // Text Effect 관련 코드
    void TextEffectStart(string dialogue){
        completeDialogue = dialogue;
        convText.text = "";
        effect_cnt=0;
        is_texteff = true;
        //Invoke("TextEffecting",1/Const.TEXT_EFF_SPEED);
    }
    void TextEffecting(){
        if(convText.text==completeDialogue){
            TextEffectEnd();
            return;
        }
        while(effect_cnt<completeDialogue.Length){
            convText.text += completeDialogue[effect_cnt];
            if(completeDialogue[effect_cnt]==' ' || completeDialogue[effect_cnt]=='\n'){
                effect_cnt++;
                break;
            }
            effect_cnt++;
        }
        Debug.Log("End Effecting");
        Invoke("TextEffecting",1/Const.TEXT_EFF_SPEED);
    }
    void TextEffectEnd(){
        is_texteff = false;
        convText.text = completeDialogue;
    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(is_texteff){
                CancelInvoke();
                TextEffectEnd();
            }

            else if(currScript.GetScriptType()!=ScriptType.CHOICE) {
                NextButton();
            }
        }
    }
}
