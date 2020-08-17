using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlantsTouchManager : MonoBehaviour
{
    public GameObject exampleImage;

    public GameObject[] questions;

    public TextMeshProUGUI questionText;
    public GameObject congratsText;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sound;

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
        StartCoroutine(End());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    public void _QN()
    {
        audioSource.clip = sound[1];
        audioSource.Play();
    }

    IEnumerator End()
    {
        questions[1].GetComponent<Animation>().Play("Q1-Plants-Light-2");

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

        exampleImage.SetActive(true);
        questionText.enabled = false;
    }

    public void Next()
    {
        StartCoroutine(NextQuestion());

        audioSource.clip = sound[0];
        audioSource.Play();
    }

    IEnumerator NextQuestion()
    {
        exampleImage.GetComponent<Animation>().Play("Q1-Plants-Photosynthesis");

        yield return new WaitForSeconds(1f);

        exampleImage.SetActive(false);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[1].SetActive(true);
        }

        questionText.enabled = true;
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Plants-AR");
    }

}
