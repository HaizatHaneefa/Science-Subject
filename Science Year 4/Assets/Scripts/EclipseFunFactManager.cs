using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EclipseFunFactManager : MonoBehaviour
{
    [SerializeField] private GameObject[] order;
    [SerializeField] private GameObject nextBut, prevBut;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;
   
    int cur;

    bool isShowing;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < order.Length; i++)
        {
            order[i].SetActive(false);
            order[0].SetActive(true);
        }
    }

    private void Update()
    {
        if (!isShowing)
        {
            for (int i = 0; i < order.Length; i++)
            {
                order[i].SetActive(false);
                order[cur].SetActive(true);
            }

            if (cur == 0)
            {
                prevBut.SetActive(false);
                nextBut.SetActive(true);
            }
            else if (cur == 9)
            {
                prevBut.SetActive(true);
                nextBut.SetActive(false);
            }
            else if (cur != 0 && cur != 10)
            {
                prevBut.SetActive(true);
                nextBut.SetActive(true);
            }
        }
        else if (isShowing)
        {
            prevBut.SetActive(false);
            nextBut.SetActive(false);
        }

        if (cur <= 0)
        {
            cur = 0;
        }
        else if (cur >= 9)
        {
            cur = 9;
        }
    }

    public void _Navigation(int index)
    {
        if (index == 0)
        {
            PressSFX();
            cur -= 1;
        }
        else if (index == 1)
        {
            BackSFX();
            cur += 1;
        }
    }


    public void _ShowImage()
    {
        PressSFX();
        isShowing = true;
        for (int i = 0; i < order.Length; i++)
        {
            order[i].SetActive(false);
            order[10].SetActive(true);
        }
    }

    public void _ReturnFromImage()
    {
        BackSFX();
        isShowing = false;
        for (int i = 0; i < order.Length; i++)
        {
            order[i].SetActive(false);
            order[5].SetActive(true);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

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
