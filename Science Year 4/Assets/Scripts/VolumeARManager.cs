using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeARManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scenes, button, subtopic;
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private GameObject nextbtn, prevbtn;
    [SerializeField] private Sprite[] buttonSrite;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        prevbtn.SetActive(false);

        subtopic[0].SetActive(true);
        subtopic[1].SetActive(false);

        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            scenes[0].SetActive(true);
            scenes[0].GetComponent<Animation>().Play("GameOverPop");
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(false);
        }
    }

    public void _Navigation(int index)
    {
        if (index == 0)
        {
            PressSFX();
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
                scenes[1].transform.GetChild(0).gameObject.SetActive(false);
                scenes[1].transform.GetChild(1).gameObject.SetActive(false);
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].SetActive(true);
            }

            prevbtn.SetActive(true);
            nextbtn.SetActive(false);

            button[0].GetComponent<Image>().sprite = buttonSrite[0];
            button[1].GetComponent<Image>().sprite = buttonSrite[0];

            subtopic[0].SetActive(false);
            subtopic[1].SetActive(true);
        }
        else if (index == 1)
        {
            BackSFX();
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[0].SetActive(true);
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].SetActive(false);
            }

            prevbtn.SetActive(false);
            nextbtn.SetActive(true);

            subtopic[0].SetActive(true);
            subtopic[1].SetActive(false);
        }
    }

    public void _Conversion(int index)
    {
        PressSFX();
        if (index == 0)
        {
            for(int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
                scenes[1].transform.GetChild(0).gameObject.SetActive(true);
                scenes[1].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");
                scenes[1].transform.GetChild(1).gameObject.SetActive(false);
            }

            button[0].GetComponent<Image>().sprite = buttonSrite[1];
            button[1].GetComponent<Image>().sprite = buttonSrite[0];
        }
        else if (index == 1)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
                scenes[1].transform.GetChild(1).gameObject.SetActive(true);
                scenes[1].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");
                scenes[1].transform.GetChild(0).gameObject.SetActive(false);
            }

            button[0].GetComponent<Image>().sprite = buttonSrite[0];
            button[1].GetComponent<Image>().sprite = buttonSrite[1];
        }
    }

    public void _BackToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _ToQuiz()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Volume of Liquid Quiz");
    }

    // ---------------------- //
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
