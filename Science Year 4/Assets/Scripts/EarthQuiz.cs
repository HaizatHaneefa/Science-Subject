using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EarthQuiz : MonoBehaviour
{
    [SerializeField] private string[] questionDialogue;

    [SerializeField] private TextMeshProUGUI questionText;

    public bool[] round;

    [SerializeField] private Button[] button;

    [SerializeField] private Transform transf;

    [SerializeField] private GameObject[] frameImage;

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite backgroundSprite;
    [SerializeField] public bool[] secondBool;

    [SerializeField] private GameObject secondQuestion;
    [SerializeField] private GameObject firstQuestion;

    [SerializeField] public Sprite[] rightWrongSprite;

    [SerializeField] public AudioSource aSource;
    [SerializeField] public AudioClip[] sound;

    [SerializeField] private Image transImage;

    [SerializeField] public GameObject gameOverPop, signBoard;

    //[SerializeField] private TextMeshProUGUI 
    void Start()
    {
        gameOverPop.SetActive(false);
        signBoard.SetActive(false);

        transImage.enabled = false;

        secondQuestion.SetActive(false);

        secondBool = new bool[6];
        secondBool[0] = true;

        round = new bool[5];
        round[0] = true;

        frameImage[0].SetActive(false);
        frameImage[1].SetActive(false);

        questionText.text = questionDialogue[0].ToString();
        Anim();
    }

    void Update()
    {
        ButtonText();
    }

    public void _ButA()
    {
        if (round[3])
        {
            StartCoroutine(ChangeColor());
            Right();
        }
        else if (round[0] || round[1] || round[2] || round[4])
        {
            StartCoroutine(WrongColor());
            Wrong();
        }
    }

    public void _ButB()
    {
        if (round[0] || round[1])
        {
            StartCoroutine(ChangeColor());
            Right();
        }
        else if (round[2] || round[3] || round[4])
        {
            StartCoroutine(WrongColor());
            Wrong();
        }
    }

    public void _ButC()
    {
        if (round[2] || round[4])
        {
            StartCoroutine(ChangeColor());
            Right();
        }
        else if (round[0] || round[1] || round[3])
        {
            StartCoroutine(WrongColor());
            Wrong();
        }
    }


    IEnumerator ChangeColor()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = false;
        }

        img.color = Color.green;

        yield return new WaitForSeconds(1f);

        img.color = Color.white;

        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = true;
        }

        if (round[0])
        {
            questionText.text = questionDialogue[1].ToString();

            round[0] = false;
            round[1] = true;

            Anim();
        }
        else if (round[1])
        {
            questionText.text = questionDialogue[2].ToString();

            round[1] = false;
            round[2] = true;

            button[0].transform.parent.transform.position = transf.position;

            frameImage[0].SetActive(true);

            Anim();
        }
        else if (round[2])
        {
            questionText.text = questionDialogue[3].ToString();

            round[2] = false;
            round[3] = true;

            frameImage[0].SetActive(false);
            frameImage[1].SetActive(true);

            Anim();
        }
        else if (round[3])
        {
            questionText.text = questionDialogue[4].ToString();

            round[3] = false;
            round[4] = true;

            RectTransform rect = button[0].transform.parent.GetComponent<RectTransform>();

            rect.anchoredPosition = new Vector2(0, 0);

            frameImage[1].SetActive(false);

            Anim();
        }
        else if (round[4])
        {
            round[4] = false; // final

            StartCoroutine(Fade());
        }
    }

    IEnumerator WrongColor()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        img.color = Color.red;

        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = false;
        }

        yield return new WaitForSeconds(1f);

        img.color = Color.white;

        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = true;
        }
    }

    void ButtonText()
    {
        if (round[0])
        {
            button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Earth's shape";
            button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Earth's rotation";
            button[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Earth's revolution";
        }
        else if (round[1])
        {
            button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "day time";
            button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "night time";
            button[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "dawn";
        }
        else if (round[2])
        {
            button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "The emission of light by the Moon";
            button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "The reflection of the sunlight";
            button[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "The occurrence of day and night";
        }
        else if (round[3])
        {
            button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "12 noon";
            button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "10.00 a.m.";
            button[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "8.00 p.m.";
        }
        else if (round[4])
        {
            button[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "365 ½ days";
            button[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "366 days";
            button[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "365 ¼ days";
        }
    }

    void Anim()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].GetComponent<Animation>().Play("Intro_Anim");
        }

        questionText.GetComponent<Animation>().Play("Intro_Anim");

        for (int i = 0; i < frameImage.Length; i++)
        {
            frameImage[i].GetComponent<Animation>().Play("Intro_Anim");
        }
    }

    IEnumerator Fade()
    {
        transImage.enabled = true;
        transImage.GetComponent<Animation>().Play("Fade");

        yield return new WaitForSeconds(0.5f);

        secondQuestion.SetActive(true);
        firstQuestion.SetActive(false);

        backgroundImage.sprite = backgroundSprite;
        transImage.enabled = false;
    }

    void Right()
    {
        aSource.clip = sound[0];
        aSource.Play();
    }

    void Wrong()
    {
        aSource.clip = sound[1];
        aSource.Play();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Y5 - Earth Quiz");
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Y5 - Earth - AR");
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Y5 - Earth Menu");
    }
}
