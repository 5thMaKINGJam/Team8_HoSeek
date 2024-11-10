using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource Click;
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

    private int Str = 0;
    private int Int = 0;
    private int Wis = 0;

    void Start()
    {
        PlayerDataManager.pdata.PrintStat();
        StatsSum = 10;
        AchieveManager.achvManager.SetTimer();
        Str = PlayerDataManager.pdata.str_stat;
        Int = PlayerDataManager.pdata.int_stat;
        Wis = PlayerDataManager.pdata.wis_stat;


        // StrUpButton.onClick.AddListener(StrUp);
        // StrDownButton.onClick.AddListener(StrDown);
        // IntUpButton.onClick.AddListener(IntUp);
        // IntDownButton.onClick.AddListener(IntDown);
        // WisUpButton.onClick.AddListener(WisUp);
        // WisDownButton.onClick.AddListener(WisDown);
        // StartButton.onClick.AddListener(OnStartButton);

        UpdateUI();
    }

    void UpdateUI()
    {
        StrText.text = "근력: " + Str;
        IntText.text = "지력: " + Int;
        WisText.text = "지혜: " + Wis;
        SumText.text = "합계 " + StatsSum + " 점";

        StrUpButton.interactable = StatsSum > 0;
        IntUpButton.interactable = StatsSum > 0;
        WisUpButton.interactable = StatsSum > 0;

        StrDownButton.interactable = Str > 0;
        IntDownButton.interactable = Int > 0;
        WisDownButton.interactable = Wis > 0;
    }

    public void StrUp()
    {
        if (StatsSum > 0)
        {
            Str += 1;
            StatsSum -= 1;
            SaveStats();
            UpdateUI();
        }
    }

    public void StrDown()
    {
        if (Str > 0)
        {
            Str -= 1;
            StatsSum += 1;
            SaveStats();
            UpdateUI();
        }
    }

    public void IntUp()
    {
        if (StatsSum > 0)
        {
            Int += 1;
            StatsSum -= 1;
            SaveStats();
            UpdateUI();
        }
    }

    public void IntDown()
    {
        if (Int > 0)
        {
            Int -= 1;
            StatsSum += 1;
            SaveStats();
            UpdateUI();
        }
    }

    public void WisUp()
    {
        if (StatsSum > 0)
        {
            Wis += 1;
            StatsSum -= 1;
            SaveStats();
            UpdateUI();
        }
    }

    public void WisDown()
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
        PlayerDataManager.pdata.PrintStat();
    }

    public void OnStartButton()
    {
        //AudioSource ButtonSound = GetComponent<AudioSource>();
        //ButtonSound.Play();
        SaveStats();
        Invoke("NextScene", 1f);
    }
    void NextScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    
}
