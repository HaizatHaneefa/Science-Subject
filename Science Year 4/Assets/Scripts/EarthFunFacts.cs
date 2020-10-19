﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthFunFacts : MonoBehaviour
{
    [SerializeField] private string[] explanationDialogueText;

    [SerializeField] private TextMeshProUGUI explanationtext;

    [SerializeField] private Button nextButton, prevButton;

    [SerializeField] private Image exampleImage;

    [SerializeField] private Sprite[] exampleSprites;
    [SerializeField] private GameObject[] buttons;

    int point;

    [SerializeField] private Sprite[] buttonSprite;
    void Start()
    {
        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        exampleImage.enabled = false;
    }

    public void _EarthRotation()
    {
        explanationtext.text = explanationDialogueText[0].ToString();

        nextButton.gameObject.SetActive(true);
        prevButton.gameObject.SetActive(true);

        exampleImage.enabled = true;
        exampleImage.sprite = exampleSprites[0];

        point = 1;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[0].GetComponent<Image>().sprite = buttonSprite[1];
        }
    }

    public void _EarthPath()
    {
        explanationtext.text = explanationDialogueText[2].ToString();

        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        exampleImage.enabled = true;
        exampleImage.sprite = exampleSprites[1];

        point = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[1].GetComponent<Image>().sprite = buttonSprite[1];
        }
    }

    public void _LeapYear()
    {
        explanationtext.text = explanationDialogueText[3].ToString();

        nextButton.gameObject.SetActive(true);
        prevButton.gameObject.SetActive(true);

        exampleImage.enabled = true;
        exampleImage.sprite = exampleSprites[2];

        point = 2;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[2].GetComponent<Image>().sprite = buttonSprite[1];
        }
    }

    public void _Prev()
    {
        if (point == 0)
        {
            return;
        }

        if (point == 1)
        {
            explanationtext.text = explanationDialogueText[0].ToString();
        }
        else if (point == 2)
        {
            explanationtext.text = explanationDialogueText[3].ToString();
        }
    }

    public void _Next()
    {
        if (point == 0)
        {
            return;
        }

        if (point == 1)
        {
            explanationtext.text = explanationDialogueText[1].ToString();
        }
        else if (point == 2)
        {
            explanationtext.text = explanationDialogueText[4].ToString();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
