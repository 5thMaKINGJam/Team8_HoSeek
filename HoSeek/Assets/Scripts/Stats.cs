using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public static int StatsSum = 10;

    public Text StrText;
    public Text IntText;
    public Text WisText;
    public Text SumText;

    public Button StrUpButton;
    public Button StrDownButton;
    public Button IntUpButton;
    public Button IntDownButton;
    public Button WisUpButton;
    public Button WisDownButton;
    public Button StartButton;

    private int Str;
    private int Int;
    private int Wis;

    void Start()
    {
        Str = PlayerDataManager.pdata.str_stat;
        Int = PlayerDataManager.pdata.int_stat;
        Wis = PlayerDataManager.pdata.wis_stat;

        StrUpButton.onClick.AddListener(StrUp);
        StrDownButton.onClick.AddListener(StrDown);
        IntUpButton.onClick.AddListener(IntUp);
        IntDownButton.onClick.AddListener(IntDown);
        WisUpButton.onClick.AddListener(WisUp);
        WisDownButton.onClick.AddListener(WisDown);
        StartButton.onClick.AddListener(OnStartButton);

        UpdateUI();
    }

    void UpdateUI()
    {
        StrText.text = "�ٷ�: " + Str;
        IntText.text = "����: " + Int;
        WisText.text = "����: " + Wis;
        SumText.text = "�հ� " + StatsSum + " ��";

        StrUpButton.interactable = StatsSum > 0;
        IntUpButton.interactable = StatsSum > 0;
        WisUpButton.interactable = StatsSum > 0;

        StrDownButton.interactable = Str > 0;
        IntDownButton.interactable = Int > 0;
        WisDownButton.interactable = Wis > 0;
    }

    void StrUp()
    {
        if (StatsSum > 0)
        {
            Str += 1;
            StatsSum -= 1;
            SaveStats();
            UpdateUI();
        }
    }

    void StrDown()
    {
        if (Str > 0)
        {
            Str -= 1;
            StatsSum += 1;
            SaveStats();
            UpdateUI();
        }
    }

    void IntUp()
    {
        if (StatsSum > 0)
        {
            Int += 1;
            StatsSum -= 1;
            SaveStats();
            UpdateUI();
        }
    }

    void IntDown()
    {
        if (Int > 0)
        {
            Int -= 1;
            StatsSum += 1;
            SaveStats();
            UpdateUI();
        }
    }

    void WisUp()
    {
        if (StatsSum > 0)
        {
            Wis += 1;
            StatsSum -= 1;
            SaveStats();
            UpdateUI();
        }
    }

    void WisDown()
    {
        if (Wis > 0)
        {
            Wis -= 1;
            StatsSum += 1;
            SaveStats();
            UpdateUI();
        }
    }

    void SaveStats()
    {
        PlayerDataManager.pdata.SetStat(Int, Str, Wis);
    }

    void OnStartButton()
    {
        SaveStats();
        SceneManager.LoadScene("Sample");
    }
}
