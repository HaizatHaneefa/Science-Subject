using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Year5PlantsAR : MonoBehaviour
{
    [SerializeField] private GameObject[] canvas;
    [SerializeField] private GameObject[] plants;
    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private Image[] imageButtons;
    [SerializeField] private GameObject[] weatherButtons;

    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        for (int i = 0; i < weatherButtons.Length; i++)
        {
            weatherButtons[i].SetActive(false);
        }

        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].SetActive(false);
        }
    }

    public void _ProtectionEnemies()
    {
        PressSFX();

        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].SetActive(false);
        }

        imageButtons[0].sprite = buttonSprite[0];
        imageButtons[1].sprite = buttonSprite[1];

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
            canvas[0].SetActive(true);
            canvas[0].GetComponent<Animation>().Play("Y5 - Animal AR");
        }

        for (int i = 0; i < weatherButtons.Length; i++)
        {
            weatherButtons[i].SetActive(false);
        }

        weatherButtons[1].GetComponent<Image>().sprite = buttonSprite[1];
        weatherButtons[0].GetComponent<Image>().sprite = buttonSprite[1];
    }

    public void _ProtectionWeather()
    {
        PressSFX();

        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].SetActive(false);
        }

        imageButtons[1].sprite = buttonSprite[0];
        imageButtons[0].sprite = buttonSprite[1];

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        for (int i = 0; i < weatherButtons.Length; i++)
        {
            weatherButtons[i].SetActive(true);
        }
    }

    public void _DryRegion()
    {
        PressSFX();
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
            canvas[1].SetActive(true);
            canvas[1].GetComponent<Animation>().Play("Y5 - Animal AR");
        }

        weatherButtons[0].GetComponent<Image>().sprite = buttonSprite[0];
        weatherButtons[1].GetComponent<Image>().sprite = buttonSprite[1];
    }

    public void _StrongWindRegion()
    {
        PressSFX();
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
            canvas[2].SetActive(true);
            canvas[2].GetComponent<Animation>().Play("Y5 - Animal AR");
        }

        weatherButtons[1].GetComponent<Image>().sprite = buttonSprite[0];
        weatherButtons[0].GetComponent<Image>().sprite = buttonSprite[1];
    }

    public void Quiz()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - C5 Quiz");
    }

    public void BackToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _ShowPlants(int index)
    {
        PressSFX();

        if (index == 0) // jagung
        {
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i].SetActive(false);
                plants[0].SetActive(true);
                plants[0].GetComponent<Animation>().Play("Jagung_JagungAction");
            }
        }
        else if (index == 1) // akar cactus
        {
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i].SetActive(false);
                plants[1].SetActive(true);
            }
        }
        else if (index == 2) // cactus
        {
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i].SetActive(false);
                plants[2].SetActive(true);
            }
        }
        else if (index == 3) // bamboo
        {
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i].SetActive(false);
                plants[3].SetActive(true);
            }
        }
        else if (index == 4) // pokok getah
        {
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i].SetActive(false);
                plants[4].SetActive(true);
                plants[4].GetComponent<Animation>().Play("pokok-gugur");
            }
        }
        else if (index == 5) // pokok getah
        {
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i].SetActive(false);
                plants[5].SetActive(true);
                //plants[4].GetComponent<Animation>().Play("pokok-gugur");
            }
        }
        else if (index == 6) // mushroom
        {
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i].SetActive(false);
                plants[6].SetActive(true);
                plants[6].GetComponent<Animation>().Play("ss");
                plants[6].transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            }
        }
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
