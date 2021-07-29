﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class YearFiveC4AR : MonoBehaviour
{
    [SerializeField] private GameObject signBoard;
    [SerializeField] private GameObject[] canvas, animals;

    [SerializeField] private string[] explanation;

    [SerializeField] private TextMeshProUGUI explainText;

    bool isPage;

    [SerializeField] private Button[] buttons;

    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
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
    }

    // ---------------------------- Functions ------------------------------ //
    public void Next()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(false);
        }

        PressSFX();

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
        PressSFX();

        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(false);
        }

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

        if (index == 0) // bat
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[0].SetActive(true);
                animals[0].GetComponent<Animation>().Play("bat-hibernate");
            }
        }
        else if (index == 1) // lizard
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[1].SetActive(true);
                animals[1].GetComponent<Animation>().Play("lizard-buang-ekor");
            }
        }
        else if (index == 2) // turtle
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[2].SetActive(true);
                animals[2].GetComponent<Animation>().Play("turtle-hiding-shell");
            }
        }
        else if (index == 3) // lebah dan harimau
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
        else if (index == 4) // tupai
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[5].SetActive(true);
                animals[5].GetComponent<Animation>().Play("tupai-anim");
            }
        }
        else if (index == 5) // harimau
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[6].SetActive(true);

                Animation anim = animals[6].GetComponent<Animation>();
                anim["harimau-lari anim"].speed = 2.0f;
                animals[6].GetComponent<Animation>().Play("harimau-lari anim");
            }
        }
        else if (index == 6) // group of penguins
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[7].SetActive(true);

                foreach (Transform o in animals[7].transform)
                {
                    o.GetComponent<Animation>().Play("penguin-taktahubuatapa anim");
                }
            }
        }
        else if (index == 7) // polar bear
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[8].SetActive(true);
                animals[8].transform.GetChild(0).GetComponent<Animation>().Play("polar bear walking");
            }
        }
        else if (index == 8) // buffalo
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[9].SetActive(true);
                animals[9].transform.GetChild(0).GetComponent<Animation>().Play("buffalo-playing-in-mud");
            }
        }
        else if (index == 9) // elephant
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[10].SetActive(true);
            }
        }
        else if (index == 10) // cockroach
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[11].SetActive(true);
                animals[11].transform.GetChild(0).GetComponent<Animation>().Play("lipas-jalan");
            }
        }
        else if (index == 11) // squid
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[12].SetActive(true);
                animals[12].transform.GetChild(0).GetComponent<Animation>().Play("squid-release-ink");

            }
        }
        else if (index == 12) // camel
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[13].SetActive(true);
            }
        }
        else if (index == 13) // deer
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[14].SetActive(true);
                animals[14].transform.GetChild(0).GetComponent<Animation>().Play("deer headbutt");
                animals[14].transform.GetChild(1).GetComponent<Animation>().Play("tiger scared af");
            }
        }
        else if (index == 14) // eagle
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[15].SetActive(true);
            }
        }
        else if (index == 15) // puffer fish
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[16].SetActive(true);
            }
        }
        else if (index == 16) // landak
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[17].SetActive(true);
                animals[17].GetComponent<Animation>().Play("landak-anim");
            }
        }
        else if (index == 17) // harimau cakar
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[18].SetActive(true);
                animals[18].GetComponent<Animation>().Play("harimau-cakar");
            }
        }
        else if (index == 18) // ulat gonggok
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[19].SetActive(true);
                animals[19].GetComponent<Animation>().Play("gonggok-jalan");
            }
        }
        else if (index == 19) // alligator
        {
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(false);
                animals[20].SetActive(true);
            }
        }
    }

    // ---------------------------- Scene Loaders ------------------------------ //
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

    // ---------------------------- SFX ------------------------------ //
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
