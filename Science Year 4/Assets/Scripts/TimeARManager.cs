using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeARManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scene3, objects, objects2, objects3, BackNextBut, explanationImage;
    [SerializeField] private GameObject scene1, scene2, answerButton, quizButton;

    [SerializeField] private GameObject[] scenes, infoImage;

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

        //for (int i = 0; i < scene3.Length; i++)
        //{
        //    scene3[i].SetActive(false);
        //}

        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            scenes[0].SetActive(true);
        }

        for (int i = 0; i < scenes.Length; i++)
        {
            infoImage[i].SetActive(false);
            infoImage[0].SetActive(true);
        }


        for (int i = 0; i < explanationImage.Length; i++)
        {
            explanationImage[i].SetActive(false);
            explanationImage[cur].SetActive(true);
        }

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
            objects[0].SetActive(true);
        }

        for (int i = 0; i < objects3.Length; i++)
        {
            objects3[i].SetActive(false);
        }

        BackNextBut[1].SetActive(false);
        answerButton.SetActive(false);
    }

    public void _NextButton()
    {
        PressSFX();

        if (cur == 0)
        {
            for (int i = 0; i < scenes.Length; i++)
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

            //scene1.SetActive(false);
            //scene2.SetActive(true);

            //for (int i = 0; i < objects.Length; i++)
            //{
            //    objects[i].SetActive(false);
            //    objects[1].SetActive(true);
            //}

            //BackNextBut[1].SetActive(true);
        }
        else if (cur == 1)
        {
            answerButton.SetActive(true);

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[2].SetActive(true);
            }

            //HideButton();

            //scene2.SetActive(false);

            //for (int i = 0; i < scene3.Length; i++)
            //{
            //    scene3[i].SetActive(true);
            //    scene3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stringQuestions[0].ToString();
            //}

            //for (int i = 0; i < objects.Length; i++)
            //{
            //    objects[i].SetActive(false);
            //}
        }
        else if (cur == 2)
        {
            HideButton();

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            scene3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stringQuestions[1].ToString();
        }
        else if (cur == 3)
        {
            HideButton();

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            scene3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stringQuestions[2].ToString();
        }
        else if (cur == 4)
        {
            HideButton();

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            scene3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stringQuestions[3].ToString();
        }

        cur += 1;
    }

    public void _BackButton()
    {
        BackSFX();

        if (cur == 5)
        {
            quizButton.SetActive(false);

            HideButton();

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            scene3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stringQuestions[2].ToString();
        }
        else if (cur == 4)
        {
            HideButton();

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            scene3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stringQuestions[1].ToString();
        }
        else if (cur == 3)
        {
            HideButton();

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            scene3[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stringQuestions[0].ToString();
        }
        else if (cur == 2)
        {
            scene2.SetActive(true); // ui

            for (int i = 0; i < scene3.Length; i++)
            {
                scene3[i].SetActive(false);
            }

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            for (int i = 0; i < objects.Length; i++) // model
            {
                objects[i].SetActive(false);
                objects[1].SetActive(true);
            }
        }
        else if (cur == 1)
        {
            scene1.SetActive(true);
            scene2.SetActive(false);

            for (int i = 0; i < objects2.Length; i++)
            {
                objects2[i].SetActive(false);
            }

            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
            }

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
                objects[0].SetActive(true);
            }

            BackNextBut[1].SetActive(false);
        }

        cur -= 1;
    }

    public void _Answer()
    {
        StartCoroutine(ShowAnswer());
    }

    IEnumerator ShowAnswer()
    {
        Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        button.interactable = false;

        RightSFX();

        // show model
        if (cur == 2)
        {
            // first model from objects 3
            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
                objects3[0].SetActive(true);
            }
        }
        else if (cur == 3)
        {
            for (int i = 0; i < objects3.Length; i++)
            {
                objects3[i].SetActive(false);
                objects3[1].SetActive(true);
            }
        }
        if (cur == 4)
        {
            for (int i = 0; i < scene3.Length; i++)
            {
                objects3[i].SetActive(false);
                objects3[2].SetActive(true);
            }
        }
        if (cur == 5)
        {
            for (int i = 0; i < scene3.Length; i++)
            {
                objects3[i].SetActive(false);
                objects3[3].SetActive(true);
            }
        }

        yield return new WaitForSeconds(1);

        button.interactable = true;

        if (cur == 5)
        {
            BackNextBut[1].SetActive(true);
            quizButton.SetActive(true);
        }
        else if (cur != 5)
        {
            for (int i = 0; i < BackNextBut.Length; i++)
            {
                BackNextBut[i].SetActive(true);
            }
        }
    }

    void HideButton()
    {
        for (int i = 0; i < BackNextBut.Length; i++)
        {
            BackNextBut[i].SetActive(false);
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
