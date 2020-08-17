using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LungsAndMoistSkinManager : MonoBehaviour
{
    [SerializeField] private GameObject[] questions;
    [SerializeField] private GameObject example;
    [SerializeField] private GameObject[] reference;
    [SerializeField] private GameObject questiontext;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip[] sound;

    int number;

    void Start()
    {
        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[0].SetActive(true);
        }

        example.SetActive(false);

        questions[0].GetComponent<Animation>().Play("FirstQuestion-LungsAndMoistSkin");
    }

    void Update()
    {
        for (int i = 0; i < reference.Length; i++)
        {
            reference[i].SetActive(false);
            reference[number].SetActive(true);
        }
    }

    public void NextReference()
    {
        if (number >= 2)
        {
            return;
        }

        number += 1;
    }

    public void PrevReference()
    {
        if (number <= 0)
        {
            return;
        }

        number -= 1;
    }

    #region first question
    public void _Wrong()
    {
        audioSource.clip = sound[1];
        audioSource.Play();
    }

    public void _RightQ1()
    {
        StartCoroutine(_RightAnswer());

        questions[0].transform.GetChild(1).GetComponent<Image>().color = Color.green;
    }
    #endregion

    #region second question
    public void _RightQ2()
    {
        StartCoroutine(_RightAnswerQ2());

        questions[1].transform.GetChild(2).GetComponent<Image>().color = Color.green;
    }
    #endregion

    IEnumerator _RightAnswer()
    {
        audioSource.clip = sound[0];
        audioSource.Play();

        yield return new WaitForSeconds(1f);

        questions[0].SetActive(false);
        questions[1].SetActive(true);

        questions[1].GetComponent<Animation>().Play("FirstQuestion-LungsAndMoistSkin");
    }

    IEnumerator _RightAnswerQ2()
    {
        audioSource.clip = sound[0];
        audioSource.Play();

        yield return new WaitForSeconds(1f);

        questiontext.SetActive(false);

        questions[1].SetActive(false);
        example.SetActive(true);

        example.GetComponent<Animation>().Play("Example_LAMS");
    }

    public void ReturnToAR()
    {
        SceneManager.LoadScene("AR-Aspect");
    }
}
