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
    [SerializeField] private GameObject secondQuestion, snakeImage, continueButton, instructPop, lowBarImage;

    public GameObject continueButtonSecondQuestion;
    [SerializeField] public GameObject signBoard, instructText;
    [SerializeField] public GameObject[] thingstoDisableEnd;

    //public GameObject yayPop;
    public GameObject thirdQuestion;

    int mcqInt;

    [SerializeField] private TextMeshProUGUI questionText;

    [SerializeField] private Image[] exampleImagesFirst;
    [SerializeField] private Image ground;

    public bool[] secondBool;
    public bool[] thirdBool;

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip[] sound;

    [SerializeField] public Sprite[] rightWrongSprite;

    void Start()
    {
        signBoard.SetActive(false);
        instructPop.transform.GetChild(0).GetComponent<Animation>().Play("MoreInfoPop");

        questionText.enabled = false;

        ground.enabled = false;

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
        instructText.SetActive(false);

        //yayPop.SetActive(false);

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

        audioSource.clip = sound[0];
        audioSource.Play();

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

    public void _NOMCQ()
    {
        audioSource.clip = sound[1];
        audioSource.Play();

        StartCoroutine(ChangeRedColor());
    }

    public void Continue()
    {
        instructText.SetActive(true);
        snakeImage.SetActive(false);
        continueButton.SetActive(false);
        ground.enabled = true;

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
        instructText.SetActive(false);
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

    public void ToGame()
    {
        SceneManager.LoadScene("Y5 - C4 Game");
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
        yield return new WaitForSeconds(1f);

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

            lowBarImage.SetActive(false);

            questionText.enabled = false;

            continueButton.SetActive(true);
        }
    }

    void ChangeColor()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.green;
    }

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

    IEnumerator DisableButton()
    {
        ChangeColor();

        List<GameObject> disable = new List<GameObject>();

        disable.AddRange(GameObject.FindGameObjectsWithTag("False"));

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = false;
        }

        if (mcqInt == 0 || mcqInt == 2 || mcqInt == 3)
        {
            yield return new WaitForSeconds(2f);
        }
        else if (mcqInt == 1 || mcqInt == 4)
        {
            yield return new WaitForSeconds(1f);
        }

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }
    }
}
