using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunFactManager : MonoBehaviour
{
    [SerializeField] private GameObject[] example;

    [SerializeField] private GameObject[] explanation, buttons;
    [SerializeField] private Sprite[] spriteButtons;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

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
        PressSFX();
        buttons[0].GetComponent<Image>().sprite = spriteButtons[1];
        buttons[1].GetComponent<Image>().sprite = spriteButtons[0];
        buttons[2].GetComponent<Image>().sprite = spriteButtons[0];

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
        PressSFX();
        buttons[0].GetComponent<Image>().sprite = spriteButtons[0];
        buttons[1].GetComponent<Image>().sprite = spriteButtons[1];
        buttons[2].GetComponent<Image>().sprite = spriteButtons[0];

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
        PressSFX();
        buttons[0].GetComponent<Image>().sprite = spriteButtons[0];
        buttons[1].GetComponent<Image>().sprite = spriteButtons[0];
        buttons[2].GetComponent<Image>().sprite = spriteButtons[1];

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
        BackSFX();
        SceneManager.LoadScene("Menu");
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
