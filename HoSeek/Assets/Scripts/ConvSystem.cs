using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class Script{
    public int id;
    public int illustNum;
    public int choiceId;
    public string scriptType;
    public string script;
    public int nextGoto;
}

[System.Serializable]
class Scripts{
    public Script[] scripts;
}

[System.Serializable]
class Choices{
    public ChoiceScript[] choices;
}

[System.Serializable]
class ChoiceScript{
    public int choiceMax;
    public string[] choice = new string[4];
    public int[] choiceGoto = new int[4];
}

public class ConvSystem : MonoBehaviour
{
    [SerializeField] GameObject convWin;
    [SerializeField] Image illustObj;
    [SerializeField] TextMeshProUGUI convText;
    [SerializeField] GameObject choiceWin;
    [SerializeField] Button[] buttons = new Button[4];
    [SerializeField] BreakObject breakObject;
    [SerializeField] TimeAttack timeAttack;
    public ChooseEnding chooseEnding;
    private ChoiceScript[] choiceScripts;
    private Dictionary<int,Script> scriptList = new Dictionary<int, Script>();
    private int currIdx;
    private int choiceIdx;
    private Script currScript;


    // Text Effect 관련 변수
    private bool is_texteff = false;
    private int effect_cnt;
    private string completeDialogue;

    private void Start(){
        InitConv();
        gameObject.SetActive(false);
    }
    public void InitConv(){
        Scripts scripts = JsonUtility.FromJson<Scripts>(Resources.Load<TextAsset>("ScriptData").text);
        for(int i = 0; i<scripts.scripts.Length; i++){
            Script tmp = scripts.scripts[i];
            scriptList.Add(scripts.scripts[i].id,tmp);
            Debug.Log(scripts.scripts[i].id+" : "+scriptList[scripts.scripts[i].id].script);
        }
        Choices choices = JsonUtility.FromJson<Choices>(Resources.Load<TextAsset>("ChoiceData").text);
        choiceScripts = choices.choices;
    }

    public void NextButton(){
        if(currScript.scriptType != "CHOICE" && currScript.nextGoto >= 0){
            currIdx = currScript.nextGoto;
        }
        else{
            currIdx++;
        }
        Debug.Log("Next Script IDX: "+currIdx);
        SetConv(currIdx);
    }

    public void ChoiceButton(int num){
        if((currIdx==7001||currIdx==7004)&&num==0){
            breakObject.gameObject.SetActive(true);
            breakObject.BreakDrawer();
        }
        else if(currIdx == 5002){
            if(num == 0){
                currIdx = PlayerDataManager.pdata.isInt()?5004:5005;
                Debug.Log("Int: "+PlayerDataManager.pdata.isInt());
                if(PlayerDataManager.pdata.isHardMode){
                    timeAttack.Penalty();
                }
                SetConv(currIdx);
                return;
            }
        }
        else if((currIdx==8001 || currIdx==8002)&&num==0){
            chooseEnding.SwapItem();
        }
        currIdx = choiceScripts[choiceIdx].choiceGoto[num];
        SetConv(currIdx);   
    }
    
    public void SetConv(int n){
        currIdx = n;
        convWin.SetActive(true);

        choiceWin.SetActive(false);
        illustObj.gameObject.SetActive(false);
        convText.gameObject.SetActive(true);

        currScript = scriptList[n];
        
        switch(currScript.scriptType){
            case "NARR":
                Debug.Log(":: SetNarr() Call");
                SetNarr();
                break;
            case "CHOICE":
                Debug.Log(":: SetChoice() Call");
                SetChoice(currScript.choiceId);
                break;
            case "ILLUST_FULL":
                SetFullIllust();
                break;
            case "LITERATE":
                SetLiterate();
                break;
            case "END_CONV":
                EndConv();
                break;
            default:
                Debug.Log("TYPE ERROR: "+n+"th script");
                break;
        }
    }

    void SetLiterate(){
        if(!PlayerDataManager.pdata.isInt()){
            SetConv(2);
            return;
        }
        SetNarr();
    }

    void SetNarr(){
        Debug.Log(currScript.script);
        TextEffectStart(currScript.script);
    }

    void SetChoice(int idx){
        choiceIdx = idx;
        choiceWin.SetActive(true);
        for(int i =0; i<choiceScripts[idx].choiceMax; i++){
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = choiceScripts[idx].choice[i];
        }
        for(int j = choiceScripts[idx].choiceMax; j < 4; j++){
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
        Invoke("TextEffecting",1/Const.TEXT_EFF_SPEED);
    }
    void TextEffecting(){
        if(convText.text==completeDialogue){
            TextEffectEnd();
            return;
        }
        convText.text += completeDialogue[effect_cnt];
        effect_cnt++;
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

            else if(currScript.scriptType!="CHOICE") {
                NextButton();
            }
        }
    }
}
