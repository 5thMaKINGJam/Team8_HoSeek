using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    public int int_stat { get; private set; } = 0;
    public int str_stat { get; private set; } = 0;
    public int wis_stat { get; private set; } = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetStat(int intel, int str, int wisdom)
    {
        int_stat = intel;
        str_stat = str;
        wis_stat = wisdom;
    }
}
