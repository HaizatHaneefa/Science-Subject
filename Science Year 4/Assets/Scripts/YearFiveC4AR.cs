using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class YearFiveC4AR : MonoBehaviour
{
    [SerializeField] private GameObject signBoard, dummyObject;

    [SerializeField] private string[] explanation;

    [SerializeField] private GameObject[] canvas, animals;

    [SerializeField] private TextMeshProUGUI explainText;

    bool isPage;

    [SerializeField] private Button[] buttons;

    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        dummyObject.SetActive(false);
        signBoard.SetActive(false);

        explainText.text = explanation[0].ToString();

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(false);
        }

        buttons[3].gameObject.SetActive(false);
        buttons[4].gameObject.SetActive(false);
        buttons[5].gameObject.SetActive(false);
    }

    public void Next()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(false);
        }

        PressSFX();
        dummyObject.SetActive(false);
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

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        explainText.text = explanation[1].ToString();

        isPage = true;

        buttons[2].gameObject.SetActive(false);
        buttons[3].gameObject.SetActive(true);
    }

    public void Prev()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(false);
        }

        BackSFX();
        dummyObject.SetActive(false);
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

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        explainText.text = explanation[0].ToString();

        isPage = false;

        buttons[2].gameObject.SetActive(true);
        buttons[3].gameObject.SetActive(false);
        //buttons[4].gameObject.SetActive(false);
        //buttons[5].gameObject.SetActive(false);
    }

    public void Characteristics()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(false);
        }

        PressSFX();
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
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(false);
        }

        PressSFX();
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

    public void ShowAnimal(int index)
    {
        PressSFX();
        if (index == 0)
        {
            // show bat
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[0].SetActive(true);
                animals[0].GetComponent<Animation>().Play("bat-hibernate");
            }
        }
        else if (index == 1)
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[1].SetActive(true);
                animals[1].GetComponent<Animation>().Play("lizard-buang-ekor");
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[2].SetActive(true);
                animals[2].GetComponent<Animation>().Play("turtle-hiding-shell");
            }
        }
        else if (index == 3)
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[3].SetActive(true);
                animals[4].SetActive(true);

                animals[4].GetComponent<Animation>().Play("harimau anim");
                animals[3].GetComponent<Animation>().Play("lebah-sengat anim");
            }
        }
        else if (index == 4)
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[5].SetActive(true);
                animals[5].GetComponent<Animation>().Play("tupai-anim");
            }
        }
        else if (index != 0 || index != 1 || index != 2)
        {
            dummyObject.SetActive(true);
        }
    }

    public void Game()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - C4 Game");
    }

    public void Quiz()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - C4 Quiz");
    }

    public void BackToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void PressSFX() // button press yes
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    public void WrongPressSFX() // button press no
    {
        aSource.clip = clip[4];
        aSource.Play();
    }

    public void BackSFX() // back button press
    {
        aSource.clip = clip[1];
        aSource.Play();
    }

    public void RightSFX() // right answer
    {
        aSource.clip = clip[2];
        aSource.Play();
    }

    public void WrongSFX() // wrong answer
    {
        aSource.clip = clip[3];
        aSource.Play();
    }
}
