using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeARManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scene3, BackNextBut, explanationImage;
    [SerializeField] private GameObject scene1, scene2, answerButton, quizButton;

    [SerializeField] private GameObject[] scenes, infoImage, answerImages;

    [SerializeField] private string[] stringQuestions;

    int cur;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        quizButton.SetActive(false);
        scene1.SetActive(true);
        scene2.SetActive(false);

        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            scenes[0].SetActive(true);
        }

        for (int i = 0; i < infoImage.Length; i++)
        {
            infoImage[i].SetActive(false);
            infoImage[0].SetActive(true);
        }

        for (int i = 0; i < answerImages.Length; i++)
        {
            answerImages[i].SetActive(false);
        }


        for (int i = 0; i < explanationImage.Length; i++)
        {
            explanationImage[i].SetActive(false);
            explanationImage[cur].SetActive(true);
        }

        BackNextBut[1].SetActive(false);
        answerButton.SetActive(false);
    }

    public void _NextButton()
    {
        for (int i = 0; i < answerImages.Length; i++)
        {
            answerImages[i].SetActive(false);
        }

        answerButton.GetComponent<Button>().interactable = true;
        PressSFX();

        if (cur == 0)
        {
            for (int i = 0; i < infoImage.Length; i++)
            {
                infoImage[i].SetActive(false);
                infoImage[1].SetActive(true);
            }

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
            }

            BackNextBut[1].SetActive(true);
        }
        else if (cur == 1)
        {
            answerButton.SetActive(true);

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[2].SetActive(true);
            }

            for (int i = 0; i < infoImage.Length; i++)
            {
                infoImage[i].SetActive(false);
            }
        }
        else if (cur == 2)
        {
            answerButton.SetActive(true);

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[3].SetActive(true);
            }

        }
        else if (cur == 3)
        {
            answerButton.SetActive(true);

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[4].SetActive(true);
            }
        }
        else if (cur == 4)
        {
            answerButton.SetActive(true);

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[5].SetActive(true);
            }

            BackNextBut[0].SetActive(false);
        }

        cur += 1;
    }

    public void _BackButton()
    {
        for (int i = 0; i < answerImages.Length; i++)
        {
            answerImages[i].SetActive(false);
        }

        answerButton.GetComponent<Button>().interactable = true;
        BackSFX();

        if (cur == 5)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[4].SetActive(true);
            }

            BackNextBut[0].SetActive(true);
        }
        else if (cur == 4)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[3].SetActive(true);
            }
        }
        else if (cur == 3)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[2].SetActive(true);
            }
        }
        else if (cur == 2)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
            }

            for (int i = 0; i < infoImage.Length; i++)
            {
                infoImage[i].SetActive(false);
                infoImage[1].SetActive(true);
            }

            answerButton.SetActive(false);
        }
        else if (cur == 1)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[0].SetActive(true);
            }

            for (int i = 0; i < infoImage.Length; i++)
            {
                infoImage[i].SetActive(false);
                infoImage[0].SetActive(true);
            }

            BackNextBut[1].SetActive(false);
        }

        cur -= 1;
    }

    public void _Answer()
    {
        RightSFX();

        Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        button.interactable = false;

        if (cur == 2)
        {
            for (int i = 0; i < answerImages.Length; i++)
            {
                answerImages[i].SetActive(false);
                answerImages[0].SetActive(true);
                answerImages[0].GetComponent<Animation>().Play("SuccessPop");
            }
        }
        else if (cur == 3)
        {
            for (int i = 0; i < answerImages.Length; i++)
            {
                answerImages[i].SetActive(false);
                answerImages[1].SetActive(true);
                answerImages[1].GetComponent<Animation>().Play("SuccessPop");
            }
        }
        else if (cur == 4)
        {
            for (int i = 0; i < answerImages.Length; i++)
            {
                answerImages[i].SetActive(false);
                answerImages[2].SetActive(true);
                answerImages[2].GetComponent<Animation>().Play("SuccessPop");
            }
        }
        else if (cur == 5)
        {
            for (int i = 0; i < answerImages.Length; i++)
            {
                answerImages[i].SetActive(false);
                answerImages[3].SetActive(true);
                answerImages[3].GetComponent<Animation>().Play("SuccessPop");
            }
        }
    }

    public void ToQuiz()
    {
        SceneManager.LoadScene("Y4 - Time Quiz"); // to quiz time
    }

    public void BackToMenu()
    {
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
