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
    public Image image;
    private bool checkbool = false;


    void Start()
    {
        targetPositionY = creditImage.anchoredPosition.y + 2160f;
        StartCoroutine(EnableClick());
    }

    void Update()
    {
        if (creditImage.anchoredPosition.y < targetPositionY)
        {
            creditImage.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        }
        else
        {
            StartCoroutine(Out());
            StartCoroutine(LoadMainScene());
        }
        if(checkbool){
            Color color = image.color;
            color.a -= Time.deltaTime * 0.8f;
            image.color = color;
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
        image.color  = new Color(image.color.r, image.color.g, image.color.b,1.0f);
        yield return new WaitForSeconds(1f);
        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime/3f;
            image.color = color;
        }
    }
}

