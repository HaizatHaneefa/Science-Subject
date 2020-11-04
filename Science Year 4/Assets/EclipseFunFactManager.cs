using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EclipseFunFactManager : MonoBehaviour
{
    [SerializeField] private GameObject[] order;
    [SerializeField] private GameObject nextBut, prevBut;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int cur;

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
        else if (cur == 10)
        {
            prevBut.SetActive(true);
            nextBut.SetActive(false);
        }
        else if (cur != 0 && cur != 10)
        {
            prevBut.SetActive(true);
            nextBut.SetActive(true);
        }

        if (cur <= 0)
        {
            cur = 0;
        }
        else if (cur >= 10)
        {
            cur = 10;
        }
    }

    public void _Navigation(int index)
    {
        if (index == 0)
        {
            cur -= 1;
        }
        else if (index == 1)
        {
            cur += 1;
        }
    }


    public void _ShowImage()
    { 
    // show iamge of the eclpise
    }

    public void _ReturnFromImage()
    { 
    // go back from elcipse
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
