using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FractionARManager : MonoBehaviour
{
    int cur;
    [SerializeField] private Sprite[] butSprite;
    [SerializeField] private GameObject[] buts, objectsinScene;
    void Start()
    {
        for (int i = 0; i < objectsinScene.Length; i++)
        {
            objectsinScene[i].SetActive(false);
        }
        
    }

    void Update()
    {
        
    }

    public void _Proper()
    {
        for (int i = 0; i < objectsinScene.Length; i++)
        {
            objectsinScene[i].SetActive(false);
            objectsinScene[0].SetActive(true);
        }

        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].GetComponent<Image>().sprite = butSprite[0];
            buts[0].GetComponent<Image>().sprite = butSprite[1];
        }
    }

    public void _Mixed()
    {
        for (int i = 0; i < objectsinScene.Length; i++)
        {
            objectsinScene[i].SetActive(false);
            objectsinScene[1].SetActive(true);
        }

        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].GetComponent<Image>().sprite = butSprite[0];
            buts[1].GetComponent<Image>().sprite = butSprite[1];
        }
    }

    public void _Improper()
    {
        for (int i = 0; i < objectsinScene.Length; i++)
        {
            objectsinScene[i].SetActive(false);
            objectsinScene[2].SetActive(true);
        }

        for (int i = 0; i < buts.Length; i++)
        {
            buts[i].GetComponent<Image>().sprite = butSprite[0];
            buts[2].GetComponent<Image>().sprite = butSprite[1];
        }
    }

    public void _Next()
    {
        if (cur == 0)
        {

        }

        //......
    }

    public void _BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
