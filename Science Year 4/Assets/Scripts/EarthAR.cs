using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthAR : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI topicText, descriptionText;
    [SerializeField] private Sprite[] sprite;

    [SerializeField] private Button[] button;

    [SerializeField] private GameObject[] infoGroup;
    [SerializeField] private GameObject nextButton, prevButton, quizButton, popInfo;

    [SerializeField] private string[] dialogue;
    bool isNext;

    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        popInfo.SetActive(false);

        aSource = GetComponent<AudioSource>();

        prevButton.SetActive(false);
        quizButton.SetActive(false);

        for (int i = 0; i < infoGroup.Length; i++)
        {
            infoGroup[i].SetActive(false);
        }

        topicText.text = "The Movement of the Earth";
    }

    void Update()
    {

    }

    public void _RotationEarth()
    {
        PressSFX();
        button[0].GetComponent<Image>().sprite = sprite[1];
        button[1].GetComponent<Image>().sprite = sprite[0];

        if (!isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[0].SetActive(true);
            }
        }
        else if (isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[2].SetActive(true);
            }
        }
    }

    public void _RevolutionGroup()
    {
        PressSFX();

        button[1].GetComponent<Image>().sprite = sprite[1];
        button[0].GetComponent<Image>().sprite = sprite[0];

        if (!isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[1].SetActive(true);
            }
        }
        else if (isNext)
        {
            for (int i = 0; i < infoGroup.Length; i++)
            {
                infoGroup[i].SetActive(false);
                infoGroup[3].SetActive(true);
            }
        }
    }

    public void NextPage()
    {
        PressSFX();
        isNext = true;

        button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "The Occurence of Day and Night";
        button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Position of the Sun & The Length of Shadow";

        button[0].GetComponent<Image>().sprite = sprite[0];
        button[1].GetComponent<Image>().sprite = sprite[0];

        for (int i = 0; i < infoGroup.Length; i++)
        {
            infoGroup[i].SetActive(false);
        }

        prevButton.SetActive(true);
        nextButton.SetActive(false);
        quizButton.SetActive(true);

        topicText.text = "Phenomenon of the Rotation of Earth";
    }

    public void PrevPage()
    {
        BackSFX();
        isNext = false;

        button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Rotation of the Earth";
        button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Revolution of the Earth";

        button[0].GetComponent<Image>().sprite = sprite[0];
        button[1].GetComponent<Image>().sprite = sprite[0];

        for (int i = 0; i < infoGroup.Length; i++)
        {
            infoGroup[i].SetActive(false);
        }

        prevButton.SetActive(false);
        nextButton.SetActive(true);
        quizButton.SetActive(false);

        topicText.text = "The Movement of the Earth";
    }

    public void ShowInfo(int index)
    {
        PressSFX();

        popInfo.SetActive(true);

        popInfo.transform.GetChild(0).GetComponent<Animation>().Play("country-info-pop");

        if (index == 0)
        {
            descriptionText.text = dialogue[0];
        }
        else if (index == 1)
        {
            descriptionText.text = dialogue[1];

        }
        else if (index == 2)
        {
            descriptionText.text = dialogue[2];
        }
        else if (index == 3)
        {
            descriptionText.text = dialogue[3];
        }
        else if (index == 4)
        {
            descriptionText.text = dialogue[4];
        }
        else if (index == 5)
        {
            descriptionText.text = dialogue[5];
        }
        else if (index == 6)
        {
            descriptionText.text = dialogue[6];
        }
        else if (index == 7)
        {
            descriptionText.text = dialogue[7];
        }
        else if (index == 8)
        {
            descriptionText.text = dialogue[8];
        }
        else if (index == 9)
        {
            descriptionText.text = dialogue[9];
        }
        else if (index == 10)
        {
            descriptionText.text = dialogue[10];
        }
    }

    public void CloseMoreInfo(int index)
    {
        BackSFX();
        popInfo.SetActive(false);
    }

    public void ToQuiz()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Earth Quiz"); // to quiz
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
