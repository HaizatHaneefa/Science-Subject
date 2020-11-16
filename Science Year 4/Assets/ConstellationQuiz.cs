using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationQuiz : MonoBehaviour
{
    //[SerializeField] private GameObject[] questionA;
    [SerializeField] public bool[] secondBool;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] public Sprite[] rightWrongSprite;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        secondBool = new bool[7];
        secondBool[0] = true;

        //for (int i = 0; i < questionA.Length; i++)
        //{
        //    questionA[i].SetActive(false);
        //    questionA[0].SetActive(true);
        //}
    }

    void Update()
    {
        
    }

    // ---------------- button functions ---------------- //

    // ---------------- SFX ---------------- //
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
