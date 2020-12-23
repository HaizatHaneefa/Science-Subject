using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Y5PlantQuiz : MonoBehaviour
{
    int cur;

    [SerializeField] public GameObject[] thirdAnswers;
    [SerializeField] private GameObject[] mcq;
    [SerializeField] private GameObject exampleImage, conButton, instructTextGO, introPop;
    [SerializeField] public GameObject continueButton, secondQuestion, thirdQuestion, signBoard;

    [SerializeField] public TextMeshProUGUI hint1, hint2;
    [SerializeField] public TextMeshProUGUI[] instructionText;

    [SerializeField] private Image ground;

    public bool[] secondBool;
    public bool[] thirdBool;

    [SerializeField] public Sprite[] rightWrongSprite;

    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        signBoard.SetActive(false);
        instructTextGO.SetActive(false);
        conButton.SetActive(false);
        ground.enabled = false;
        introPop.transform.GetChild(0).GetComponent<Animation>().Play("MoreInfoPop");

        instructionText[0].text = "";
        instructionText[1].text = "";

        secondBool = new bool[6];
        secondBool[0] = true;

        thirdBool = new bool[5];
        thirdBool[0] = true;

        for (int i = 0; i < thirdAnswers.Length; i++)
        {
            thirdAnswers[i].SetActive(false);
            thirdAnswers[0].SetActive(true);
        }

        for (int i = 0; i < mcq.Length; i++)
        {
            mcq[i].SetActive(false);
        }

        exampleImage.SetActive(false);
        secondQuestion.SetActive(false);
        thirdQuestion.SetActive(false);
        continueButton.SetActive(false);
    }

    // ---------------------------- Functions ------------------------------ //
    public void Continue()
    {
        PressSFX();
        exampleImage.SetActive(false);
        conButton.SetActive(false);

        for (int o = 0; o < mcq.Length; o++)
        {
            mcq[o].SetActive(false);
            mcq[1].SetActive(true);
        }

        mcq[1].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");

        instructionText[0].enabled = true;
    }

    public void ContinueSomeMore()
    {
        PressSFX();
        continueButton.SetActive(false);
        thirdQuestion.SetActive(true);
        instructTextGO.SetActive(false);

        instructionText[0].enabled = false;
        instructionText[1].text = "Place the correct plant that suits the characteristics and behaviours in the holder";

        thirdAnswers[0].GetComponent<Animation>().Play("Question-Year 5 Chap 4");
    }

    public void _MCQ()
    {
        RightSFX();

        StartCoroutine(ButtonChangeColor());
    }

    public void _NOMCQ()
    {
        WrongPressSFX();

        StartCoroutine(ChangeRedColor());
    }

    public void StartQuiz()
    {
        PressSFX();
        for (int i = 0; i < mcq.Length; i++)
        {
            mcq[i].SetActive(false);
            mcq[0].SetActive(true);
            mcq[0].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
        }

        introPop.SetActive(false);

        instructionText[0].text = "Choose the best answer.";

        for (int i = 0; i < mcq.Length; i++)
        {
            mcq[i].SetActive(false);
            mcq[0].SetActive(true);
            mcq[0].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
        }
    }

    // ---------------------------- Coroutines ------------------------------ //
    IEnumerator ChangeRedColor()
    {
        List<GameObject> disable = new List<GameObject>();

        disable.AddRange(GameObject.FindGameObjectsWithTag("False"));

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = false;
        }

        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.red;

        yield return new WaitForSeconds(1f);

        img.color = Color.white;

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator ButtonChangeColor()
    {
        List<GameObject> disable = new List<GameObject>();

        disable.AddRange(GameObject.FindGameObjectsWithTag("False"));

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = false;
        }

        Image i = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        i.color = Color.green;

        yield return new WaitForSeconds(1f);

        i.color = Color.white;

        if (cur == 0)
        {
            exampleImage.SetActive(true);
            conButton.SetActive(true);

            instructionText[0].enabled = false;

            for (int o = 0; o < mcq.Length; o++)
            {
                mcq[o].SetActive(false);
            }
        }
        else if (cur == 1)
        {
            for (int o = 0; o < mcq.Length; o++)
            {
                mcq[o].SetActive(false);
                mcq[2].SetActive(true);
                mcq[2].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }
        else if (cur == 2)
        {
            for (int o = 0; o < mcq.Length; o++)
            {
                mcq[o].SetActive(false);
                mcq[3].SetActive(true);
                mcq[3].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }
        else if (cur == 3)
        {
            for (int o = 0; o < mcq.Length; o++)
            {
                mcq[o].SetActive(false);
                mcq[4].SetActive(true);
                mcq[4].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }
        else if (cur == 4)
        {
            for (int o = 0; o < mcq.Length; o++)
            {
                mcq[o].SetActive(false);
            }

            secondQuestion.SetActive(true);
            instructionText[0].text = "Determine if the statement is true or false.";
            ground.enabled = true;
            instructTextGO.SetActive(true);
        }

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }

        cur += 1;
    }

    // ---------------------------- Scene Loaders ------------------------------ //
    public void Restart()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - C5 Quiz");
    }

    public void ToGame()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - C5 Game");
    }

    public void BackToAR()
    {
        BackSFX();
        SceneManager.LoadScene("Y5 - C5 AR");
    }

    // ---------------------------- SFX ------------------------------ //
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
