using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyQuizManager : MonoBehaviour
{
    [SerializeField] private GameObject[] stuff;

    [SerializeField] public int cur;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < stuff.Length; i++)
        {
            stuff[i].SetActive(false);
            stuff[cur].SetActive(true);
        }
    }

    void Update()
    {
        
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
