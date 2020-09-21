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

    [SerializeField] private GameObject[] mcq;
    [SerializeField] private GameObject exampleImage;
    [SerializeField] public GameObject secondQuestion;
    [SerializeField] public GameObject thirdQuestion;
    [SerializeField] public GameObject[] thirdAnswers;
    [SerializeField] public GameObject continueButton;
    [SerializeField] public GameObject blocker;
    [SerializeField] private GameObject introPop;
    //public GameObject yayPop;
    [SerializeField] public GameObject signBoard;

    [SerializeField] public TextMeshProUGUI hint1;
    [SerializeField] public TextMeshProUGUI hint2;
    [SerializeField] public TextMeshProUGUI[] instructionText;

    [SerializeField] private Image ground;

    public bool[] secondBool;
    public bool[] thirdBool;

    [SerializeField] public AudioClip[] sound;
    [SerializeField] public AudioSource audioSource;

    [SerializeField] public Sprite[] rightWrongSprite;

    private void Start()
    {
        signBoard.SetActive(false);
        ground.enabled = false;
        introPop.transform.GetChild(0).GetComponent<Animation>().Play("MoreInfoPop");

        instructionText[0].text = "";
        instructionText[1].text = "";

        secondBool = new bool[6];
        secondBool[0] = true;

        thirdBool = new bool[5];
        thirdBool[0] = true;

        //yayPop.SetActive(false);
        blocker.SetActive(false);

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
        blocker.SetActive(true);
    }

    public void StartQuiz()
    {
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

        blocker.SetActive(false);
    }

    public void _MCQ()
    {
        audioSource.clip = sound[0];
        audioSource.Play();

        StartCoroutine(ButtonChangeColor());
    }

    public void _NOMCQ()
    {
        audioSource.clip = sound[1];
        audioSource.Play();

        StartCoroutine(ChangeRedColor());
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Y5 - C5 AR");
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
        }

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }

        cur += 1;
    }

    public void Continue()
    {
        exampleImage.SetActive(false);

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
        continueButton.SetActive(false);
        thirdQuestion.SetActive(true);

        instructionText[0].enabled = false;
        instructionText[1].text = "Place the correct plant that suits the characteristics and behaviours in the holder";

        thirdAnswers[0].GetComponent<Animation>().Play("Question-Year 5 Chap 4");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Y5 - C5 Quiz");
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
}
