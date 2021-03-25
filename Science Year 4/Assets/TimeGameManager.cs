using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TimeGameManager : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int score, answerInt, monthInt;

    [SerializeField] private TextMeshProUGUI scoreText, timerText;
    bool hasStarted;

    void Start()
    {
        timer = 60f;

        monthInt = 30;
    }

    public void _Button()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        answerInt = int.Parse(go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);

        //if ()
    }


    void Update()
    {
        if (hasStarted)
        {
            // do stuff here
        }

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = niceTime;
    }
}
