using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeQuizManager : MonoBehaviour
{
    public bool[] secondBool;

    public Sprite[] rightWrongSprite;

    AudioSource aSource;
    public AudioClip[] clip;

    [SerializeField] private GameObject[] questions;
    [SerializeField] private GameObject[] questionSection;

    [SerializeField] private string[] questionDialogue;

    [SerializeField] private TextMeshProUGUI instructionText;

    int cur;

    void Start()
    {
        questionDialogue = new string[3];
        questionDialogue[0] = "Choose the best answer";
        questionDialogue[1] = "Choose the correct answer based on the information from the table";
        questionDialogue[2] = "Drag and drop the correct way for the unit conversion";

        instructionText.text = questionDialogue[0].ToString();

        secondBool = new bool[5];
        secondBool[0] = true;

        aSource = GetComponent<AudioSource>();

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[cur].SetActive(true);
            questions[cur].GetComponent<Animation>().Play("GameOverPop");
        }

        for (int i = 0; i < questionSection.Length; i++)
        {
            questionSection[i].SetActive(false);
            //questionSection[cur].SetActive(true);
        }
    }

    public void NextQuestion()
    {
        cur += 1;

        if (cur < 7)
        {
            RightSFX();
        }

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[cur].SetActive(true);
            questions[cur].GetComponent<Animation>().Play("GameOverPop");
        }

        if (cur == 5)
        {
            for (int i = 0; i < questionSection.Length; i++)
            {
                questionSection[i].SetActive(false);
                questionSection[0].SetActive(true);
                questionSection[0].GetComponent<Animation>().Play("GameOverPop");
            }
        }

        if (cur == 8)
        {
            for (int i = 0; i < questionSection.Length; i++)
            {
                questionSection[i].SetActive(false);
                questionSection[1].SetActive(true);
                questionSection[1].GetComponent<Animation>().Play("GameOverPop");
            }
        }
    }


    void ChangeColor()
    {
        //Image img = EventSystem.current.currentgameObject. 
    }

    public void WrongAnswer()
    {
        Debug.Log("you done goof");
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
