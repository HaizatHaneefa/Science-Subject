using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuEarth : MonoBehaviour
{
    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

    }

    public void ToGameOne()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - C World Map"); // to game 1
    }

    public void ToGameTwo()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Shadow Game"); // to game 2
    }

    public void ToQuiz()
    {
        BackSFX();
        SceneManager.LoadScene("Y5 - Earth Quiz"); // to AR
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
