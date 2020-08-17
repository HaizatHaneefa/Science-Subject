using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlantsWaterManager : MonoBehaviour
{
    public GameObject exampleImage;

    public GameObject[] questions;

    public TextMeshProUGUI questionText;
    public GameObject congratsText;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sound;
    int cur;

    void Start()
    {
        congratsText.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        exampleImage.SetActive(false);

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
        StartCoroutine(ShowGeotropism());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    public void _Q3Y()
    {
        StartCoroutine(End());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    public void _QN()
    {
        audioSource.clip = sound[1];
        audioSource.Play();
    }

    IEnumerator ShowGeotropism()
    {
        questions[1].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        questionText.enabled = false;

        exampleImage.SetActive(true);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    IEnumerator End()
    {
        questions[2].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        questionText.enabled = false;
        congratsText.SetActive(true);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    IEnumerator transition()
    {
        questions[0].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        questions[0].SetActive(false);
        questions[1].SetActive(true);
    }

    public void NextQuestion()
    {
        StartCoroutine(TWistedTransister());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    IEnumerator TWistedTransister()
    {
        exampleImage.GetComponent<Animation>().Play("Q1-Plants-Photosynthesis");

        yield return new WaitForSeconds(1f);

        questionText.enabled = true;

        exampleImage.SetActive(false);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[2].SetActive(true);
        }
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Plants-AR");
    }
}
