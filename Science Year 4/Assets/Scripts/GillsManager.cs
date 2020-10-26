﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GillsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private Button answerButton;

    [SerializeField] private GameObject nextButton, prevButton, example;
    [SerializeField] private GameObject[] reference;

    public int number;

    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip[] clip;

    void Start()
    {
        answerText.enabled = false;
        example.SetActive(false);

        nextButton.SetActive(false);
        prevButton.SetActive(false);
    }

    void Update()
    {
        for (int i = 0; i < reference.Length; i++)
        {
            reference[i].SetActive(false);
            reference[number].SetActive(true);
        }

        if (number <= 0)
        {
            prevButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if (number >= 3)
        {
            nextButton.SetActive(false);
            prevButton.SetActive(true);

        }
        else if (number > 0 && number < 3)
        {
            nextButton.SetActive(true);
            prevButton.SetActive(true);
        }
    }

    public void Answer()
    {
        PressSFX();
        StartCoroutine(ShowTheRest());

        answerButton.GetComponent<Button>().interactable = false;
    }

    public void NextReference()
    {
        if (number >= 3)
        {
            return;
        }

        PressSFX();
        number += 1;
    }

    public void PrevReference()
    {
        if (number <= 0)
        {
            return;
        }

        BackSFX();
        number -= 1;
    }

    IEnumerator ShowTheRest()
    {
        answerText.enabled = true;
        answerText.GetComponent<Animation>().Play("FadeIn");

        yield return new WaitForSeconds(2);

        example.SetActive(true);

        nextButton.SetActive(true);
        prevButton.SetActive(true);
    }

    public void ReturnToAR()
    {
        BackSFX();
        SceneManager.LoadScene("AR-Aspect");
    }

    void PressSFX()
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    void BackSFX()
    {
        aSource.clip = clip[1];
        aSource.Play();
    }
}
