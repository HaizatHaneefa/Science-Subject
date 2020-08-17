using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlantLightManager : MonoBehaviour
{
    [SerializeField] private GameObject[] exampleImages;
    [SerializeField] private GameObject questionText;

    [SerializeField] private GameObject[] questions;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < exampleImages.Length; i++)
        {
            exampleImages[i].SetActive(false);
        }

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[0].SetActive(true);
        }

        questions[0].GetComponent<Animation>().Play("Q1-Plants-Light");
    }

    public void _Q1Y()
    {
        StartCoroutine(transition());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    public void _Q2Y()
    {
        StartCoroutine(ShowPhotosynthesis());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    public void _Q3Y()
    {
        StartCoroutine(ShowPhototropism());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    public void _QN()
    {
        audioSource.clip = sound[1];
        audioSource.Play();
    }

    IEnumerator ShowPhotosynthesis()
    {
        questions[1].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < exampleImages.Length; i++)
        {
            exampleImages[i].SetActive(false);
            exampleImages[0].SetActive(true);
        }

        questionText.SetActive(false);
    }

    public void NextQuestion()
    {
        StartCoroutine(Next());


        audioSource.clip = sound[0];
        audioSource.Play();
    }

    IEnumerator Next()
    {
        exampleImages[0].GetComponent<Animation>().Play("Q1-Plants-Photosynthesis");

        yield return new WaitForSeconds(1f);

        questionText.SetActive(true);

        for (int i = 0; i < exampleImages.Length; i++)
        {
            exampleImages[i].SetActive(false);
        }

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[2].SetActive(true);
        }
    }

    IEnumerator ShowPhototropism()
    {
        questions[2].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < exampleImages.Length; i++)
        {
            exampleImages[i].SetActive(false);
            exampleImages[1].SetActive(true);
            exampleImages[2].SetActive(true);
        }

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }

        questionText.SetActive(false);
    }

    IEnumerator transition()
    {
        questions[0].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        questions[0].SetActive(false);
        questions[1].SetActive(true);
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Plants-AR");
    }
}
