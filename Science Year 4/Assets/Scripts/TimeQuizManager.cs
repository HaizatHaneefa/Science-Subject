using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TimeQuizManager : MonoBehaviour
{
    public bool[] secondBool;

    public Sprite[] rightWrongSprite;

    [SerializeField] private GameObject[] questions;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject[] questionSection;

    [SerializeField] private string[] questionDialogue;

    [SerializeField] private TextMeshProUGUI instructionText;

    int cur;

    AudioSource aSource;
    public AudioClip[] clip;

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
        }

        buttons = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // ---------------------------- Functions ---------------------------- // 
    public void NextQuestion()
    {
        cur += 1;

        RightSFX();

        StartCoroutine(ChangeGreen());
    }

    public void _DragNextQuestion()
    {
        cur += 1;

        StartCoroutine(ChangeGreen());
    }

    public void WrongAnswer()
    {
        StartCoroutine(ChangeRed());
    }

    // ---------------------------- Scene Loaders ---------------------------- // 
    public void BackToAR() // time AR
    {
        BackSFX();
        SceneManager.LoadScene(""); // fill this when you actually made the damn scene
    }

    public void _BackToAR() // length AR
    {
        BackSFX();
        SceneManager.LoadScene("Menu"); // fill this when you actually made the damn scene
    }

    public void _BackToARMass() // mass AR
    {
        BackSFX();
        SceneManager.LoadScene("Menu"); // fill this when you actually made the damn scene
    }

    public void _BackToARVolume() // mass AR
    {
        BackSFX();
        SceneManager.LoadScene("Menu"); // fill this when you actually made the damn scene
    }

    public void Restart() // quiz time
    {
        PressSFX();
        SceneManager.LoadScene("Y4 - Time Quiz"); // fill this when you actually made the damn scene
    }

    public void _Restart() // quiz length
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Length Quiz"); // fill this when you actually made the damn scene
    }

    public void _RestartMass() // quiz mass
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Mass Quiz"); // fill this when you actually made the damn scene
    }

    public void _RestartVolume() // quiz length
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Volume of Liquid Quiz"); // fill this when you actually made the damn scene
    }

    // ---------------------------- Coroutines ---------------------------- // 
    IEnumerator ChangeGreen()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.green;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }

        yield return new WaitForSeconds(1f);

        img.color = Color.white;

        if (cur == 5)
        {
            for (int i = 0; i < questionSection.Length; i++)
            {
                questionSection[i].SetActive(false);
                questionSection[0].SetActive(true);
                questionSection[0].GetComponent<Animation>().Play("GameOverPop");
            }

            instructionText.text = questionDialogue[1].ToString();
        }

        if (cur == 8)
        {
            for (int i = 0; i < questionSection.Length; i++)
            {
                questionSection[i].SetActive(false);
                questionSection[1].SetActive(true);
                questionSection[1].GetComponent<Animation>().Play("GameOverPop");
            }

            instructionText.text = questionDialogue[2].ToString();
        }

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
            questions[cur].SetActive(true);
            questions[cur].GetComponent<Animation>().Play("GameOverPop");
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator ChangeRed()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.red;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }

        WrongPressSFX();

        yield return new WaitForSeconds(1f);

        img.color = Color.white;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }

    // ---------------------------- SFX ---------------------------- // 
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
