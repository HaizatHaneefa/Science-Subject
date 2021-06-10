﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SpeedARManager : MonoBehaviour
{
    [SerializeField] string[] dialogue;
    [SerializeField] Sprite[] buttonSprite;
    [SerializeField] GameObject[] buttons, prevNextButton, models;
    [SerializeField] GameObject go, startButton, imageSlider, hideSliderButton;
    [SerializeField] TextMeshProUGUI descriptionText, definitionText;

    int cur;
    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        prevNextButton[0].SetActive(false);
        prevNextButton[1].SetActive(true);

        aSource = GetComponent<AudioSource>();
        go.SetActive(false);
        imageSlider.SetActive(false);
        hideSliderButton.SetActive(false);
        descriptionText.transform.parent.gameObject.SetActive(false);
        definitionText.transform.parent.gameObject.SetActive(false);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }
    }

    public void StartAR()
    {
        PressSFX();
        descriptionText.transform.parent.gameObject.SetActive(true);
        definitionText.transform.parent.gameObject.SetActive(true);

        buttons[0].SetActive(true);
        buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Unit of Speed";
        buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 18;

        startButton.SetActive(false);
        go.SetActive(true);

        descriptionText.text = dialogue[0].ToString();
        definitionText.text = "Definition of Speed";
        definitionText.fontSize = 24f;

        imageSlider.SetActive(true);
    }

    public void HideSlider()
    {
        BackSFX();
        StartCoroutine(HideButton());
    }

    public void ShowSlider()
    {
        PressSFX();
        StartCoroutine(ShowButton());
    }

    public void NextButton()
    {
        PressSFX();

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }

        if (cur == 0)
        {
            go.SetActive(false);

            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Relationship between speed, distance and time";
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13;

            buttons[3].SetActive(true);
            imageSlider.SetActive(false);
             
            definitionText.text = "Unit of Speed";
            definitionText.fontSize = 24f;
            cur += 1;

            prevNextButton[0].SetActive(true);
        }
        else if (cur == 1)
        {
            buttons[1].SetActive(true);
            buttons[2].SetActive(true);
            buttons[3].SetActive(false);

            definitionText.text = "Relationship between speed, distance and time";
            definitionText.fontSize = 16f;

            imageSlider.SetActive(true);
            descriptionText.text = "";
            cur += 1;

            prevNextButton[1].SetActive(false);
        }
    }

    public void PrevButton()
    {
        BackSFX();

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }

        if (cur == 2)
        {
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Relationship between speed, distance and time";
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13;

            buttons[1].SetActive(false);
            buttons[2].SetActive(false);
            buttons[3].SetActive(true);

            buttons[1].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[2].GetComponent<Image>().sprite = buttonSprite[0];

            imageSlider.SetActive(false);

            cur -= 1;

            definitionText.text = "Unit of Speed";
            definitionText.fontSize = 24f;

            prevNextButton[1].SetActive(true);

          
        }
        else if (cur == 1)
        {
            descriptionText.transform.parent.gameObject.SetActive(true);
            definitionText.transform.parent.gameObject.SetActive(true);

            buttons[0].SetActive(true);
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Unit of Speed";
            buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 18;

            buttons[3].SetActive(false);

            startButton.SetActive(false);
            go.SetActive(true);

            descriptionText.text = dialogue[0].ToString();
            definitionText.text = "Definition of Speed";
            definitionText.fontSize = 24f;

            imageSlider.SetActive(true);

            prevNextButton[0].SetActive(false);

            cur -= 1;
        }
    }

    public void _centi()
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
            models[0].SetActive(true);
            models[0].transform.GetChild(0).GetComponent<Animation>().Play("kura-berjalan");
        }
    }

    public void _metre()
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
            models[1].SetActive(true);
            models[1].transform.GetChild(0).GetComponent<Animation>().Play("tupai");
        }
    }

    public void _kilo()
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
            models[2].SetActive(true);
            models[2].transform.GetChild(0).GetComponent<Animation>().Play("old-horse");
            models[2].transform.GetChild(1).GetComponent<Animation>().Play("young-horse");
        }
    }

    public void TimeIsSet()
    {
        PressSFX();
        descriptionText.text = dialogue[1].ToString();
        descriptionText.fontSize = 15;

        buttons[1].GetComponent<Image>().sprite = buttonSprite[1];
        buttons[2].GetComponent<Image>().sprite = buttonSprite[0];

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }
    }

    public void DistanceIsSet()
    {
        PressSFX();
        descriptionText.text = dialogue[2].ToString();
        descriptionText.fontSize = 15;

        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
            models[3].SetActive(true);
            models[3].GetComponent<Animation>().Play("atlet-lari");
            models[4].SetActive(true);
            models[4].GetComponent<Animation>().Play("orangbiasa-lari");
        }

        buttons[1].GetComponent<Image>().sprite = buttonSprite[0];
        buttons[2].GetComponent<Image>().sprite = buttonSprite[1];
    }

    public void ToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void ToQuiz()
    {
        PressSFX();
        SceneManager.LoadScene("Y6 - Speed Quiz"); // to quiz
    }

    IEnumerator HideButton()
    {
        imageSlider.GetComponent<Animation>().Play("HideSlide Anim");

        yield return new WaitForSeconds(0.5f);

        hideSliderButton.SetActive(true);
    }

    IEnumerator ShowButton()
    {
        hideSliderButton.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        imageSlider.GetComponent<Animation>().Play("ShowSlide Anim");
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
