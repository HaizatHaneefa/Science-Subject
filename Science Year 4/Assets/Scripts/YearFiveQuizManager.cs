using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class YearFiveQuizManager : MonoBehaviour
{
    [SerializeField] private GameObject[] mcq;
    [SerializeField] private GameObject secondQuestion;
    [SerializeField] private GameObject snakeImage;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject instructPop;
    public GameObject continueButtonSecondQuestion;
    public GameObject yayPop;
    public GameObject thirdQuestion;

    int mcqInt;

    [SerializeField] private TextMeshProUGUI questionText;
    public TextMeshProUGUI secondExplanation;

    public Sprite[] spriteImage;

    public Image exampleImage;
    [SerializeField] private Image[] exampleImagesFirst;

    public bool[] secondBool;
    public bool[] thirdBool;

    void Start()
    {
        instructPop.transform.GetChild(0).GetComponent<Animation>().Play("MoreInfoPop");

        questionText.enabled = false;

        secondBool = new bool[6];
        thirdBool = new bool[3];
        thirdBool[0] = true;
        secondBool[0] = true;

        for (int i = 0; i < mcq.Length; i++)
        {
            mcq[i].SetActive(false);
        }

        continueButton.SetActive(false);
        secondQuestion.SetActive(false);
        snakeImage.SetActive(false);
        thirdQuestion.SetActive(false);
        yayPop.SetActive(false);

        continueButtonSecondQuestion.SetActive(false);

        for (int i = 0; i < exampleImagesFirst.Length; i++)
        {
            exampleImagesFirst[i].enabled = false;
        }
    }

    private void Update()
    {
        if (thirdBool[0])
        {
            thirdQuestion.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hard scales";
            thirdQuestion.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Curling up the body";
        }
        else if (thirdBool[1])
        {
            thirdQuestion.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hard claws";
            thirdQuestion.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Long legs and strong muscles";
        }
        else if (thirdBool[2])
        {
            thirdQuestion.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Thick fur";
            thirdQuestion.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hibernate";
        }

        if (secondBool[5])
        {
            continueButtonSecondQuestion.SetActive(true);
        }
    }

    public void _MCQ()
    {
        ChangeColor();

        StartCoroutine(DisableButton());

        if (mcqInt == 5)
            return;

        if (mcqInt == 0)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                StartCoroutine(showImage());
            }
        }
        else if (mcqInt == 1)
        {
            StartCoroutine(Whateverthisisbro());
        }
        else if (mcqInt == 2)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                StartCoroutine(showImage());
            }
        }
        else if (mcqInt == 3)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                StartCoroutine(showImage());
            }
        }
        else if (mcqInt == 4)
        {
            StartCoroutine(Whateverthisisbro());
        }

        mcqInt += 1;
    }

    public void Continue()
    {
        snakeImage.SetActive(false);
        continueButton.SetActive(false);

        secondQuestion.SetActive(true);
        secondQuestion.GetComponent<Animation>().Play("Question-Year 5 Chap 4");

        questionText.enabled = true;
        questionText.text = "Determine if the statement is true or false.";
    }

    public void StartGame()
    {
        instructPop.SetActive(false);

        questionText.enabled = true;

        for (int i = 0; i < mcq.Length; i++)
        {
            mcq[i].SetActive(false);
            mcq[0].SetActive(true);
            mcq[0].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
        }

        StartCoroutine(DisableButton());
    }

    public void ToThirdQuestion()
    {
        secondQuestion.SetActive(false);
        thirdQuestion.SetActive(true);

        thirdQuestion.GetComponent<Animation>().Play("Question-Year 5 Chap 4");

        questionText.text = "Place the correct animal that suits the characteristics and behaviours in the holder";
    }

    public void Retry()
    {
        SceneManager.LoadScene("Y5 - C4 Quiz");
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Y5 - C4 AR");
    }

    IEnumerator DisableButton()
    {
        for (int i = 0; i < mcq.Length; i++)
        {
            mcq[i].transform.GetChild(0).GetComponent<Button>().enabled = false;
            mcq[i].transform.GetChild(1).GetComponent<Button>().enabled = false;
            mcq[i].transform.GetChild(2).GetComponent<Button>().enabled = false;
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < mcq.Length; i++)
        {
            mcq[i].transform.GetChild(0).GetComponent<Button>().enabled = true;
            mcq[i].transform.GetChild(1).GetComponent<Button>().enabled = true;
            mcq[i].transform.GetChild(2).GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator showImage()
    {
        if (mcqInt == 0)
        {
            for (int i = 0; i < exampleImagesFirst.Length; i++)
            {
                exampleImagesFirst[i].enabled = false;
                exampleImagesFirst[0].enabled = true;
                exampleImagesFirst[0].GetComponent<Animation>().Play("SuccessPop");
            }
        }
        else if (mcqInt == 2)
        {
            for (int i = 0; i < exampleImagesFirst.Length; i++)
            {
                exampleImagesFirst[i].enabled = false;
                exampleImagesFirst[1].enabled = true;
                exampleImagesFirst[1].GetComponent<Animation>().Play("SuccessPop");
            }
        }
        else if (mcqInt == 3)
        {
            for (int i = 0; i < exampleImagesFirst.Length; i++)
            {
                exampleImagesFirst[i].enabled = false;
                exampleImagesFirst[2].enabled = true;
                exampleImagesFirst[2].GetComponent<Animation>().Play("SuccessPop");
            }
        }

        yield return new WaitForSeconds(2f);

        if (mcqInt == 1)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                mcq[i].SetActive(false);
                mcq[1].SetActive(true);
                mcq[1].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }
        else if (mcqInt == 3)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                mcq[i].SetActive(false);
                mcq[3].SetActive(true);
                mcq[3].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }
        else if (mcqInt == 4)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                mcq[i].SetActive(false);
                mcq[4].SetActive(true);
                mcq[4].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }

        for (int i = 0; i < exampleImagesFirst.Length; i++)
        {
            exampleImagesFirst[i].enabled = false;
        }
    }

    IEnumerator Whateverthisisbro()
    {
        ChangeColor();

        yield return new WaitForSeconds(0.5f);

        if (mcqInt == 2)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                mcq[i].SetActive(false);
                mcq[2].SetActive(true);
                mcq[2].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }
        else if (mcqInt == 4)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                mcq[i].SetActive(false);
                mcq[3].SetActive(true);
                mcq[3].GetComponent<Animation>().Play("MCQ Year 5 Chapter 4");
            }
        }
        else if (mcqInt == 5)
        {
            for (int i = 0; i < mcq.Length; i++)
            {
                mcq[i].SetActive(false);
            }

            snakeImage.SetActive(true);
            snakeImage.GetComponent<Animation>().Play("Question-Year 5 Chap 4");

            questionText.enabled = false;

            continueButton.SetActive(true);
        }
    }

    void ChangeColor()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.green;
    }
}
