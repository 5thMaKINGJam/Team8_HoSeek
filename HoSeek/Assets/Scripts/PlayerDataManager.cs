using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{

    public static PlayerDataManager pdata;

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
