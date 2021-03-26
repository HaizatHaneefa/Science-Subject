using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TimeGameManager : MonoBehaviour
{
    [SerializeField] private TimeQuestions[] questions;

    [SerializeField] private float timer;
    [SerializeField] private int score, answerInt;

    [SerializeField] private TextMeshProUGUI scoreText, timerText, questionsText;
    [SerializeField] private GameObject introPop, yayPop, endPop;

    bool hasStarted;

    int cur;

    void Start()
    {
        timer = 3f;
        timerText.text = "0";

        introPop.SetActive(true);
        yayPop.SetActive(false);
        endPop.SetActive(false);
    }

    public void _Button()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        answerInt = int.Parse(go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);

        if (answerInt == questions[cur].answer)
        {
            StartCoroutine(NextQuestion());
        }
        else if (answerInt != questions[cur].answer)
        {
            Debug.Log("qqwee");
        }
    }

    public void _Start()
    {
        cur = Random.Range(0, questions.Length);

        hasStarted = true;

        introPop.SetActive(false);
    }

    void EndPop()
    {
        hasStarted = false;
        endPop.SetActive(true);
    }

    IEnumerator NextQuestion()
    {
        yayPop.SetActive(true);
        yayPop.GetComponent<Animation>().Play("MoneyYayPop");

        yield return new WaitForSeconds(0.8f);

        score += 1;
        yayPop.SetActive(false);
        cur = Random.Range(0, questions.Length);
    }

    public void _Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void _Restart()
    {
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
}
