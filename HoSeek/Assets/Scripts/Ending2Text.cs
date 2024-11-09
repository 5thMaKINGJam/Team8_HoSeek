using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending2Text : MonoBehaviour
{
    public TMP_Text ending2Text;
    string Ending2;

    void Start()
    {
        Ending2 = "무사히 집을 나와 산 속으로 도망쳤다.\n\n\n다시는 같은 실수를 하지 않으리라.";
        StartCoroutine(Typing(Ending2));
    }
    void Update()
    {

    }

    IEnumerator Typing(string talk)
    {
        yield return new WaitForSeconds(1.2f);
        ending2Text.text = null;
        for (int i = 0; i <Ending2.Length; i++)
        {
            ending2Text.text += talk[i];
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainScene");
    }
}
