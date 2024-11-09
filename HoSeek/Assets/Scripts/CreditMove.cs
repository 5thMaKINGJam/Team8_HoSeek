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
    GameObject Panel;
    Image image;
    private bool checkbool = false;

    void Awake()
    {
        Panel = this.gameObject;
        image = Panel.GetComponent<Image>();
    }

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

        if (canClick && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator EnableClick()
    {
        yield return new WaitForSeconds(clickDelay);
        canClick = true;
    }

    public IEnumerator Out()
    {
        yield return new WaitForSeconds(1f);
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
                yield break;

            }

            yield return null;
        }
    }



}

