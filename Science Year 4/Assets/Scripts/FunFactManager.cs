using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunFactManager : MonoBehaviour
{
    [SerializeField] private GameObject[] example;

    [SerializeField] private GameObject[] explanation;

    void Start()
    {
        for (int i = 0; i < example.Length; i++)
        {
            example[i].SetActive(false);
        }

        for (int i = 0; i < explanation.Length; i++)
        {
            explanation[i].SetActive(false);
        }
    }

    public void _Spiders()
    {
        for (int i = 0; i < example.Length; i++)
        {
            example[i].SetActive(false);
            example[1].SetActive(true);
        }

        for (int i = 0; i < explanation.Length; i++)
        {
            explanation[i].SetActive(false);
            explanation[0].SetActive(true);
        }
    }

    public void _Scorpion()
    {
        for (int i = 0; i < example.Length; i++)
        {
            example[i].SetActive(false);
            example[0].SetActive(true);
        }

        for (int i = 0; i < explanation.Length; i++)
        {
            explanation[i].SetActive(false);
            explanation[0].SetActive(true);
        }
    }

    public void _BookLungs()
    {
        for (int i = 0; i < example.Length; i++)
        {
            example[i].SetActive(false);
            example[2].SetActive(true);
        }

        for (int i = 0; i < explanation.Length; i++)
        {
            explanation[i].SetActive(false);
            explanation[1].SetActive(true);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
