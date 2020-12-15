using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FractionQuizManager : MonoBehaviour
{
    [SerializeField] private GameObject[] questions;
    [SerializeField] private GameObject endpop;
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[0].SetActive(true);
        }

        endpop.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Yes(int index)
    {
        RightSFX();

        if (index == 0)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[1].SetActive(true);
            }
        }
        else if (index == 1)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[2].SetActive(true);
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[3].SetActive(true);
            }
        }
        else if (index == 3)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[4].SetActive(true);
            }
        }
        else if (index == 4)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[5].SetActive(true);
            }
        }
        else if (index == 5)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[6].SetActive(true);
            }
        }
        else if (index == 6)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[7].SetActive(true);
            }
        }
        else if (index == 7)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[8].SetActive(true);
            }
        }
        else if (index == 8)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[9].SetActive(true);
            }
        }
        else if (index == 9)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[10].SetActive(true);
            }
        }
        else if (index == 10)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[11].SetActive(true);
            }
        }
        else if (index == 11)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[12].SetActive(true);
            }
        }
        else if (index == 12)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].SetActive(false);
                questions[13].SetActive(true);
            }
        }
        else if (index == 13)
        {
            // end the game
            endpop.SetActive(true);
            endpop.GetComponent<Animation>().Play("EndGamePop-NEW");
        }
    }

    public void No()
    {
        WrongPressSFX();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Y4 - Fractions Quiz");
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
