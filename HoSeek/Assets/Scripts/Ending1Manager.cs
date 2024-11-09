using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Ending1Manager : MonoBehaviour
{
    GameObject Panel;
    Image image;
    private bool checkbool = false;

    void Awake()
    {
        Panel = this.gameObject;
        image = Panel.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !checkbool)
        {
            StartCoroutine(Out());
        }
    }

    public IEnumerator Out()
    {
        Color color = image.color;
        while (color.a < 1.0f)
        {
            color.a += Time.deltaTime * 0.8f;
            image.color = color;

            if (color.a >= 1.0f)
            {
                color.a = 1.0f;
                image.color = color;
                checkbool = true;
                SceneManager.LoadScene("EndingCredit");
                yield break;
            }
            yield return null;
        }
    }
}
