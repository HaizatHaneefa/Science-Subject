using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthFunFacts : MonoBehaviour
{
    [SerializeField] private string[] explanationDialogueText;

    [SerializeField] private TextMeshProUGUI explanationtext;

    [SerializeField] private Button nextButton, prevButton;

    [SerializeField] private Image exampleImage;

    [SerializeField] private Sprite[] exampleSprites;
    [SerializeField] private GameObject[] buttons;

    int point;

    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        exampleImage.enabled = false;
    }

    private void Update()
    {
        if (point == 0)
        {

        }
    }

    public void _EarthRotation()
    {
        PressSFX();
        explanationtext.text = explanationDialogueText[0].ToString();

        nextButton.gameObject.SetActive(true);
        prevButton.gameObject.SetActive(true);

        exampleImage.enabled = true;
        exampleImage.sprite = exampleSprites[0];

        point = 1;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[0].GetComponent<Image>().sprite = buttonSprite[1];
        }

        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
    }

    public void _EarthPath()
    {
        PressSFX();
        explanationtext.text = explanationDialogueText[2].ToString();

        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        exampleImage.enabled = true;
        exampleImage.sprite = exampleSprites[1];

        point = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[1].GetComponent<Image>().sprite = buttonSprite[1];
        }
    }

    public void _LeapYear()
    {
        PressSFX();
        explanationtext.text = explanationDialogueText[3].ToString();

        nextButton.gameObject.SetActive(true);
        prevButton.gameObject.SetActive(true);

        exampleImage.enabled = true;
        exampleImage.sprite = exampleSprites[2];

        point = 2;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().sprite = buttonSprite[0];
            buttons[2].GetComponent<Image>().sprite = buttonSprite[1];
        }
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
    }

    public void _Prev()
    {
        if (point == 0)
        {
            return;
        }

        PressSFX();
        if (point == 1)
        {
            explanationtext.text = explanationDialogueText[0].ToString();
            nextButton.gameObject.SetActive(true);
            prevButton.gameObject.SetActive(false);
        }
        else if (point == 2)
        {
            explanationtext.text = explanationDialogueText[3].ToString();
            nextButton.gameObject.SetActive(true);
            prevButton.gameObject.SetActive(false);
        }
    }

    public void _Next()
    {
        if (point == 0)
        {
            return;
        }

        PressSFX();
        if (point == 1)
        {
            explanationtext.text = explanationDialogueText[1].ToString();
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(true);
        }
        else if (point == 2)
        {
            explanationtext.text = explanationDialogueText[4].ToString();
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void ToMenu()
    {
        BackSFX();
        SceneManager.LoadScene("Menu"); // to menu
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
