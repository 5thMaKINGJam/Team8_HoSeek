using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{

    public static PlayerDataManager pdata;

    int int_stat = 0;
    int str_stat = 0;
    int wis_stat = 0;

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
    void SetStat(int intel, int str, int wisdom){
        int_stat = intel;
        str_stat = str;
        wis_stat = wisdom;
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
}
