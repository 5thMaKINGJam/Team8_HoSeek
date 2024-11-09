using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
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
        StartCoroutine(In());
    }



    public IEnumerator In()
    {
        Color color = image.color;
        while (color.a > 0)
        {
            color.a -= Time.deltaTime * 0.5f;
            image.color = color;

            if (color.a <= 0)
            {
                color.a = 0;
                image.color = color;
                checkbool = true;
                yield break;
            }

            yield return null;
        }
    }

   
}
