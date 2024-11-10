using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending3Text : MonoBehaviour
{
    public TMP_Text ending3Text;
    string Ending3;

    void Start()
    {
        Ending3 = "인간은 기다란 칼을 가지고 있었고 나는 다쳤다.\n\n\n복수를 다짐하며 반대쪽으로 뛰어내려 산 속으로 도망쳤다.\n\n\n다시는 같은 실수를 하지 않으리라.";
        StartCoroutine(Typing(Ending3));
    }
    void Update()
    {

    }

    IEnumerator Typing(string talk)
    {
        yield return new WaitForSeconds(1.2f);
        ending3Text.text = null;
        for (int i = 0; i <Ending3.Length; i++)
        {
            ending3Text.text += talk[i];
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("InitialScene");
    }
}
