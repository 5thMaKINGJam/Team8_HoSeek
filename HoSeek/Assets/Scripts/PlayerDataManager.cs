using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    int int_stat = 0;
    int str_stat = 0;
    int wis_stat = 0;

    void SetStat(int intel, int str, int wisdom){
        int_stat = intel;
        str_stat = str;
        wis_stat = wisdom;
    }
    int GetIntStat(){
        return int_stat;
    }
    int GetStrStat(){
        return str_stat;
    }
    int GetWisStat(){
        return wis_stat;
    }
}
