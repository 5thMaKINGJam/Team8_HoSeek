using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{

    public static PlayerDataManager pdata;

    public bool isHurt = false;
    public bool isHardMode = false;

    void Awake(){
        if(pdata == null){
            pdata = this;
            DontDestroyOnLoad(pdata);
        }
        else if(pdata!=this){
            Destroy(this);
            return;
        }
    }

    public int int_stat { get; private set; } = 0;
    public int str_stat { get; private set; } = 0;
    public int wis_stat { get; private set; } = 0;

    public void SetStat(int Int,int Str,int Wis){
        int_stat = Int;
        str_stat = Str;
        wis_stat = Wis;
    }

    public void ClearPlayerData(){
        SetStat(0,0,0);
        isHurt = false;
        isHardMode = false;
    }

    public bool isInt(){
        if(int_stat>=5){
            return true;
        }
        return false;
    }
    public bool isStr(){
        if(str_stat>=5){
            return true;
        }
        return false;
    }
    public bool isWis(){
        if(wis_stat>=5){
            return true;
        }
        return false;
    }

    public void PrintStat(){
        Debug.Log("Stat: "+str_stat+" "+int_stat+" "+wis_stat);
    }
}
