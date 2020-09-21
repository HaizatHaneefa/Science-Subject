using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class YearFiveC4AR : MonoBehaviour
{
    [SerializeField] private GameObject signBoard;
    [SerializeField] private string[] explanation;
    [SerializeField] private GameObject[] canvas;

    [SerializeField] private TextMeshProUGUI explainText;

    //int pageInt;

    bool isPage;

    [SerializeField] private Button[] buttons;

    [SerializeField] private Sprite[] buttonSprite;
    void Start()
    {
        signBoard.SetActive(false);

        explainText.text = explanation[0].ToString();

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        buttons[3].gameObject.SetActive(false);
        buttons[4].gameObject.SetActive(false);
        buttons[5].gameObject.SetActive(false);
    }

    public void Next()
    {
        signBoard.SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cold Weather";
            buttons[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hot Weather";
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[0].GetComponent<Image>().sprite = buttonSprite[1];
            buttons[1].GetComponent<Image>().sprite = buttonSprite[1];
        }

        //if (pageInt == 1)
        //{
        //    return;
        //}

        //if (pageInt == 0)
        //{
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        explainText.text = explanation[1].ToString();

        isPage = true;
        //}

        //pageInt += 1;
        buttons[2].gameObject.SetActive(false);
        buttons[3].gameObject.SetActive(true);
        buttons[4].gameObject.SetActive(true);
        buttons[5].gameObject.SetActive(true);
    }

    public void Prev()
    {
        signBoard.SetActive(false);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Characteristics";
            buttons[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Behaviours";
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[0].GetComponent<Image>().sprite = buttonSprite[1];
            buttons[1].GetComponent<Image>().sprite = buttonSprite[1];
        }

        //if (pageInt == 0)
        //{
        //    return;
        //}

        //if (pageInt == 1)
        //{
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        explainText.text = explanation[0].ToString();

        isPage = false;
        //}

        //pageInt -= 1;

        buttons[2].gameObject.SetActive(true);
        buttons[3].gameObject.SetActive(false);
        buttons[4].gameObject.SetActive(false);
        buttons[5].gameObject.SetActive(false);
    }

    public void Characteristics()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[1].GetComponent<Image>().sprite = buttonSprite[1];
            buttons[0].GetComponent<Image>().sprite = buttonSprite[0];
        }

        if (isPage)
        {
            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].SetActive(false);
                canvas[2].SetActive(true);
            }

            canvas[2].GetComponent<Animation>().Play("Y5 - Animal AR");
        }
        else if (!isPage)
        {
            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].SetActive(false);
                canvas[0].SetActive(true);
            }

            canvas[0].GetComponent<Animation>().Play("Y5 - Animal AR");
        }
    }

    public void Behaviours()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[0].GetComponent<Image>().sprite = buttonSprite[1];
            buttons[1].GetComponent<Image>().sprite = buttonSprite[0];
        }

        if (isPage)
        {
            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].SetActive(false);
                canvas[3].SetActive(true);
            }

            canvas[3].GetComponent<Animation>().Play("Y5 - Animal AR");
        }
        else if (!isPage)
        {
            for (int i = 0; i < canvas.Length; i++)
            {
                canvas[i].SetActive(false);
                canvas[1].SetActive(true);
            }

            canvas[1].GetComponent<Animation>().Play("Y5 - Animal AR");
        }
    }

    public void Game()
    {
        SceneManager.LoadScene("Y5 - C4 Game");
    }

    public void Quiz()
    {
        SceneManager.LoadScene("Y5 - C4 Quiz");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
