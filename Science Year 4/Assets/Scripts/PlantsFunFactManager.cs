using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlantsFunFactManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI explainText;

    [SerializeField] private string[] explain;
    [SerializeField] private string[] dialogue;

    [SerializeField] private GameObject[] image;
    [SerializeField] private GameObject[] buttons, plantButtons;

    int num;

    [SerializeField] private Sprite[] sprite;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private GameObject buttonPrev, buttonNext;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        explainText.enabled = false;

        for (int i = 0; i < image.Length; i++)
        {
            image[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (num == 0)
        {
            buttonPrev.SetActive(false);
            buttonNext.SetActive(true);

        }
        else if (num == 1)
        {
            buttonPrev.SetActive(true);
            buttonNext.SetActive(false);
        }
    }

    public void PlantsResponse()
    {
        PressSFX();
        explainText.enabled = true;

        explainText.text = explain[0].ToString();

        for (int i = 0; i < image.Length; i++)
        {
            image[i].SetActive(false);
            image[0].SetActive(true);
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        num = 0;
        
        plantButtons[0].GetComponent<Image>().sprite = sprite[1];
        plantButtons[1].GetComponent<Image>().sprite = sprite[0];
    }

    public void PlantsTropism()
    {
        PressSFX();
        explainText.enabled = true;

        for (int i = 0; i < image.Length; i++)
        {
            image[i].SetActive(false);
            image[1].SetActive(true);
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }

        if (num == 0)
        {
            explainText.text = dialogue[0].ToString();
        }

        plantButtons[1].GetComponent<Image>().sprite = sprite[1];
        plantButtons[0].GetComponent<Image>().sprite = sprite[0];
    }

    public void Back()
    {
        BackSFX();
        explainText.enabled = false;

        explainText.text = "";
    }

    public void Home()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void NextDialogue()
    {
        if (num == 1)
        {
            return;
        }
        if (num == 0)
        {
            PressSFX();
            explainText.text = dialogue[1].ToString();
            num = 1;
        }
    }

    public void PrevDialogue()
    {
        if (num == 0)
        {
            return;
        }
        else if (num == 1)
        {
            PressSFX();
            explainText.text = dialogue[0].ToString();
            num = 0;
        }
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
