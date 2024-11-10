using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class CreditMove : MonoBehaviour
{
    public RectTransform creditImage;
    public float scrollSpeed = 100f;
    private float targetPositionY;
    private float clickDelay = 2f;
    private bool canClick = false;
    public GameObject image;
    private bool checkbool = false;
    bool crtFlag = false;


    void Start()
    {
        targetPositionY = creditImage.anchoredPosition.y + 2160f;
        StartCoroutine(EnableClick());
        image.SetActive(false);
    }

    void Update()
    {
        if (creditImage.anchoredPosition.y < targetPositionY)
        {
            creditImage.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        }
        else if(!crtFlag)
        {
            crtFlag=true;
            StartCoroutine(Out());
            StartCoroutine(LoadMainScene());
        }
        if (canClick && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("InitialScene");
        }
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("InitialScene");
    }

    IEnumerator EnableClick()
    {
        yield return new WaitForSeconds(clickDelay);
        canClick = true;
    }

    public IEnumerator Out()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Image>().color  = new Color(0,0,0,1.0f);
        image.SetActive(true);
        Color color = image.GetComponent<Image>().color;
        image.GetComponent<Image>().color  = new Color(color.r, color.g, color.b,1.0f);
        yield return new WaitForSeconds(1f);
        color = image.GetComponent<Image>().color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime/3f;
            image.GetComponent<Image>().color = color;
        }
    }
}

