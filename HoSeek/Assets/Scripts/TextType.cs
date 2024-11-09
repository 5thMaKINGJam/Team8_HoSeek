using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextType : MonoBehaviour
{
    public TMP_Text introText;
    string intro;

    void Start()
    {
        intro = "���� ��ҿ��� ���� ����.\r\n�� �ӿ��� ���� ���� ���µ� ���� ������?";
        StartCoroutine(Typing(intro));
    }
    void Update()
    {

    }

    IEnumerator Typing(string talk)
    {
        yield return new WaitForSeconds(1.2f);
        introText.text = null;
        for (int i = 0; i < intro.Length; i++)
        {
            introText.text += talk[i];
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene");
    }
}
