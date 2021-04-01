using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeGameManager : MonoBehaviour
{
    [SerializeField] private TimeQuestions[] questions;

    [SerializeField] private float timer;
    [SerializeField] private int score, answerInt;

    [SerializeField] private TextMeshProUGUI scoreText, timerText, questionsText, endText;
    [SerializeField] private GameObject introPop, yayPop, endPop, roundSprite;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    [SerializeField] private Sprite[] selectedSprite;

    bool hasStarted;

    int cur;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        timer = 60f;
        timerText.text = "0";

        introPop.SetActive(true);
        yayPop.SetActive(false);
        endPop.SetActive(false);
        roundSprite.SetActive(false);
    }

    public void _Button()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        answerInt = int.Parse(go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);

        if (answerInt == questions[cur].answer)
        {
            roundSprite.SetActive(true);
            roundSprite.GetComponent<Animation>().Play("circle-pop");
            roundSprite.transform.position = go.transform.position;

            StartCoroutine(NextQuestion());
        }
        else if (answerInt != questions[cur].answer)
        {
            StartCoroutine(Wrong());
        }
    }

    IEnumerator Wrong()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        Sprite ww = go.GetComponent<Image>().sprite;

        go.GetComponent<Image>().sprite = selectedSprite[1];

        WrongPressSFX();

        yield return new WaitForSeconds(0.5f);

        go.GetComponent<Image>().sprite = ww;
    }

    IEnumerator NextQuestion()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        Sprite ww = go.GetComponent<Image>().sprite;

        RightSFX();

        yayPop.SetActive(true);
        yayPop.GetComponent<Animation>().Play("MoneyYayPop");

        go.GetComponent<Image>().sprite = selectedSprite[0];

        yield return new WaitForSeconds(0.8f);

        go.GetComponent<Image>().sprite = ww;

        roundSprite.SetActive(false);

        score += 1;
        yayPop.SetActive(false);
        cur = Random.Range(0, questions.Length);
    }

    public void _Start()
    {
        cur = Random.Range(0, questions.Length);

        hasStarted = true;

        introPop.SetActive(false);
    }

    void EndPop()
    {
        EndSFX();

        hasStarted = false;
        endPop.SetActive(true);

        endText.text = " Congratulations!" + "\n" + "Correct answers:" + "\n" + score;
    }

    public void _Back()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _Restart()
    {
        PressSFX();
        SceneManager.LoadScene("Y4 - Time Game");
    }

    void Update()
    {
        if (hasStarted)
        {
            scoreText.text = score.ToString();
            questionsText.text = questions[cur].dialogue;

            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 0;
            EndPop();
        }

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = niceTime;
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

    public void EndSFX() // wrong answer
    {
        aSource.clip = clip[5];
        aSource.Play();
    }
}
