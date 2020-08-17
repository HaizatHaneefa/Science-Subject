using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlantGravityManager : MonoBehaviour
{
    public GameObject exampleImage;

    public GameObject[] questions;

    public TextMeshProUGUI questionText;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sound;
    int cur;

    void Start()
    {
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
        StartCoroutine(transition());

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

    IEnumerator ShowPhototropism()
    {
        questions[2].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        yield return new WaitForSeconds(1f);

        exampleImage.SetActive(true);
        questionText.enabled = false;

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    IEnumerator transition()
    {
        if (cur == 0)
        {
            questions[0].GetComponent<Animation>().Play("Q1-Plants-Light-2");

        }
        else if (cur == 1)
        {
            questions[1].GetComponent<Animation>().Play("Q1-Plants-Light-2");
        }

        yield return new WaitForSeconds(1f);

        if (cur == 0)
        {
            questions[0].SetActive(false);
            questions[1].SetActive(true);

            cur = 1;
        }
        else if (cur == 1)
        {
            questions[0].SetActive(false);
            questions[2].SetActive(true);
        }
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Plants-AR");
    }
}
