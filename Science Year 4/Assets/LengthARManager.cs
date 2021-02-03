using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LengthARManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scenes, subtopic, button;
    [SerializeField] private GameObject nextbtn, prevbtn;

    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        prevbtn.SetActive(false);

        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].SetActive(false);
            scenes[0].SetActive(true);
            scenes[0].GetComponent<Animation>().Play("GameOverPop");
        }

        for (int i = 0; i < subtopic.Length; i++)
        {
            subtopic[i].SetActive(false);
            subtopic[0].SetActive(true);
        }

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(false);
        }
    }

    public void _ConversionButton(int index)
    {
        PressSFX();

        if (index == 0)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
                scenes[1].transform.GetChild(0).gameObject.SetActive(true);
                scenes[1].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

                scenes[1].transform.GetChild(1).gameObject.SetActive(false);
                scenes[1].transform.GetChild(2).gameObject.SetActive(false);
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
                button[0].GetComponent<Image>().sprite = buttonSprite[1];
            }
        }
        else if (index == 1)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
                scenes[1].transform.GetChild(0).gameObject.SetActive(false);
                scenes[1].transform.GetChild(1).gameObject.SetActive(true);
                scenes[1].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

                scenes[1].transform.GetChild(2).gameObject.SetActive(false);
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
                button[1].GetComponent<Image>().sprite = buttonSprite[1];
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);
                scenes[1].transform.GetChild(0).gameObject.SetActive(false);
                scenes[1].transform.GetChild(1).gameObject.SetActive(false);
                scenes[1].transform.GetChild(2).gameObject.SetActive(true);
                scenes[1].transform.GetChild(2).GetComponent<Animation>().Play("GameOverPop");
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
                button[2].GetComponent<Image>().sprite = buttonSprite[1];
            }
        }
    }

    public void _Navigation(int index)
    {
        if (index == 0)
        {
            PressSFX();
            // go next
            for (int i = 0; i < button.Length; i++)
            {
                button[i].SetActive(true);
            }

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[1].SetActive(true);

                scenes[1].transform.GetChild(0).gameObject.SetActive(false);
                scenes[1].transform.GetChild(1).gameObject.SetActive(false);
                scenes[1].transform.GetChild(2).gameObject.SetActive(false);
            }

            for (int i = 0; i < subtopic.Length; i++)
            {
                subtopic[i].SetActive(false);
                subtopic[1].SetActive(true);
            }

            prevbtn.SetActive(true);
            nextbtn.SetActive(false);
        }
        else if (index == 1)
        {
            BackSFX();
            // go back
            for (int i = 0; i < button.Length; i++)
            {
                button[i].SetActive(false);
            }

            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[0].SetActive(true);
                scenes[0].GetComponent<Animation>().Play("GameOverPop");
            }

            for (int i = 0; i < subtopic.Length; i++)
            {
                subtopic[i].SetActive(false);
                subtopic[0].SetActive(true);
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
            }

            prevbtn.SetActive(false);
            nextbtn.SetActive(true);
        }
    }

    public void _BackToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    // ------------------------ //
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
