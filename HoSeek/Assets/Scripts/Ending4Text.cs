using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending4Text : MonoBehaviour
{
    public TMP_Text ending4Text;
    string Ending4;

    void Start()
    {
        Ending4 = "살아남지 못했다";
        StartCoroutine(Typing(Ending4));
    }
    void Update()
    {

    }

    IEnumerator Typing(string talk)
    {
        yield return new WaitForSeconds(1.2f);
        ending4Text.text = null;
        for (int i = 0; i <Ending4.Length; i++)
        {
            ending4Text.text += talk[i];
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("InitialScene");
    }
}
