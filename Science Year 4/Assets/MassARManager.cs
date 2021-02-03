using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MassARManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scenes, button, subtopic;
    [SerializeField] private GameObject nextbtn, prevbtn;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private Sprite[] buttonSprite;

    int cur;

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

        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(false);
        }

        for (int i = 0; i < subtopic.Length; i++)
        {
            subtopic[i].SetActive(false);
            subtopic[0].SetActive(true);
        }
    }

    public void _Next()
    {
        PressSFX();

        if (cur == 0)
        {
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
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
            }

            for (int i = 0; i < subtopic.Length; i++)
            {
                subtopic[i].SetActive(false);
                subtopic[1].SetActive(true);
            }

            prevbtn.SetActive(true);
        }
        else if (cur == 1)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[2].SetActive(true);
                scenes[2].transform.GetChild(0).gameObject.SetActive(false);
                scenes[2].transform.GetChild(1).gameObject.SetActive(false);
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].SetActive(false);
                button[3].SetActive(true);
                button[2].SetActive(true);
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
            }

            nextbtn.SetActive(false);
        }

        cur += 1;
    }

    public void _Previous()
    {
        BackSFX();

        if (cur == 2)
        {
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
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
            }

            nextbtn.SetActive(true);

        }
        else if (cur == 1)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                scenes[i].SetActive(false);
                scenes[0].SetActive(true);
            }

            for (int i = 0; i < button.Length; i++)
            {
                button[i].SetActive(false);
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
            }

            for (int i = 0; i < subtopic.Length; i++)
            {
                subtopic[i].SetActive(false);
                subtopic[0].SetActive(true);
            }

            prevbtn.SetActive(false);
        }

        cur -= 1;
    }

    public void _Button(int index)
    {
        PressSFX();

        if (index == 0)
        {
            scenes[1].transform.GetChild(0).gameObject.SetActive(true);
            scenes[1].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");

            scenes[1].transform.GetChild(1).gameObject.SetActive(false);

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
                button[0].GetComponent<Image>().sprite = buttonSprite[1];
            }
        }
        else if (index == 1)
        {
            scenes[1].transform.GetChild(0).gameObject.SetActive(false);
            scenes[1].transform.GetChild(1).gameObject.SetActive(true);
            scenes[1].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
                button[1].GetComponent<Image>().sprite = buttonSprite[1];
            }
        }
        else if (index == 2)
        {
            scenes[2].transform.GetChild(0).gameObject.SetActive(false);
            scenes[2].transform.GetChild(1).gameObject.SetActive(true);
            scenes[2].transform.GetChild(1).GetComponent<Animation>().Play("GameOverPop");

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
                button[2].GetComponent<Image>().sprite = buttonSprite[1];
            }
        }
        else if (index == 3)
        {
            scenes[2].transform.GetChild(0).gameObject.SetActive(true);
            scenes[2].transform.GetChild(0).GetComponent<Animation>().Play("GameOverPop");
            scenes[2].transform.GetChild(1).gameObject.SetActive(false);

            for (int i = 0; i < button.Length; i++)
            {
                button[i].GetComponent<Image>().sprite = buttonSprite[0];
                button[3].GetComponent<Image>().sprite = buttonSprite[1];
            }
        }
    }

    public void _BackToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    // ------------------- //
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
