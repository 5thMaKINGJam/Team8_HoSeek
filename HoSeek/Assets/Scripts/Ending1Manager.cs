using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Ending1Manager : MonoBehaviour
{
    [SerializeField] Image endingIll;
    [SerializeField] Sprite img1;
    [SerializeField] Sprite img2;
    GameObject Panel;
    Image image;
    private bool checkbool = false;
    int cnt = 0;

    void Awake()
    {
        Panel = this.gameObject;
        image = Panel.GetComponent<Image>();
        endingIll.sprite = img1;
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
                if(cnt>0){
                    SceneManager.LoadScene("EndingCredit");
                    yield break;
                }
                else{
                    cnt++;
                    endingIll.sprite = img2;
                    color.a = 0f;
                    image.color = color;
                    yield return new WaitForSeconds(1f);
                }
                
            }
            yield return null;
        }
    }
}
