﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Y5PlantGame : MonoBehaviour
{
    [SerializeField] private QuestionHolderPlants data;
    [SerializeField] private SpawnTrackPlantsGame spawntrack;

    [SerializeField] private float AIspeed;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float[] multiplier;
    [SerializeField] private float speed = 5f;
    public float timer;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI timerText;

    int cur;
    int diff;
    public int newSpeed;

    [SerializeField] private Button[] answerbutton;

    [SerializeField] private GameObject introPop;
    [SerializeField] private GameObject[] thingsToRemoveFirst;
    public GameObject pop;
    [SerializeField] GameObject player, bot;

    Vector2[] oriPos;

    public bool[] tstbool;
    public bool isPlaying;
    bool isTimer;
    public bool isReady;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sound;

    void Start()
    {
        spawntrack = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnTrackPlantsGame>();
        spawntrack.enabled = false;

        audioSource = GetComponent<AudioSource>();

        oriPos = new Vector2[2];

        oriPos[0] = player.transform.position;
        oriPos[1] = bot.transform.position;

        pop.SetActive(false);

        LookForQuestion();

        tstbool = new bool[6];
        tstbool[0] = true;

        InvokeRepeating("BotSpeed", 0, 3f);

        introPop.GetComponent<Animation>().Play("Intro_Anim");
        timer = 3f;

        timerText.enabled = false;

        for (int i = 0; i < thingsToRemoveFirst.Length; i++)
        {
            thingsToRemoveFirst[i].SetActive(false);
        }
    }

    void Update()
    {
        timerText.text = timer.ToString("F0");

        if (playerSpeed <= speed)
        {
            playerSpeed = speed;
        }

        if (isPlaying)
        {
            player.transform.position += transform.right * playerSpeed * Time.deltaTime;
            bot.transform.position += transform.right * AIspeed * Time.deltaTime;

            playerSpeed -= 0.8f * Time.deltaTime;
        }

        if (isTimer)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0.60f)
        {
            timerText.text = "GO!";
        }

        if (timer <= 0.10f)
        {
            isTimer = false;
            timerText.enabled = false;
            isPlaying = true;
            thingsToRemoveFirst[0].SetActive(true);

            spawntrack.enabled = true;
            isReady = true;
        }
    }

    public void Play()
    {
        introPop.SetActive(false);
        isTimer = true;

        timerText.enabled = true;

        for (int i = 0; i < thingsToRemoveFirst.Length; i++)
        {
            thingsToRemoveFirst[i].SetActive(true);
            thingsToRemoveFirst[0].SetActive(false);
        }
    }

    void LookForQuestion()
    {
        int index = Random.Range(0, 20);

        if (diff == index)
        {
            LookForQuestion();
            return;
        }
        else if (diff != index)
        {
            diff = index;

            if (index == 0)
            {
                questionText.text = data.q1.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q1.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q1.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q1.ans3.ToString();

                cur = data.q1.num;
            }
            else if (index == 1)
            {
                questionText.text = data.q2.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q2.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q2.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q2.ans3.ToString();

                cur = data.q2.num;
            }
            else if (index == 2)
            {
                questionText.text = data.q3.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q3.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q3.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q3.ans3.ToString();

                cur = data.q3.num;
            }
            else if (index == 3)
            {
                questionText.text = data.q4.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q4.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q4.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q4.ans3.ToString();

                cur = data.q4.num;
            }
            else if (index == 4)
            {
                questionText.text = data.q5.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q5.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q5.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q5.ans3.ToString();

                cur = data.q5.num;
            }
            else if (index == 5)
            {
                questionText.text = data.q6.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q6.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q6.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q6.ans3.ToString();

                cur = data.q6.num;
            }
            else if (index == 6)
            {
                questionText.text = data.q7.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q7.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q7.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q7.ans3.ToString();

                cur = data.q7.num;
            }
            else if (index == 7)
            {
                questionText.text = data.q8.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q8.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q8.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q8.ans3.ToString();

                cur = data.q8.num;
            }
            else if (index == 8)
            {
                questionText.text = data.q9.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q9.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q9.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q9.ans3.ToString();

                cur = data.q9.num;
            }
            else if (index == 9)
            {
                questionText.text = data.q10.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q10.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q10.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q10.ans3.ToString();

                cur = data.q10.num;
            }
            else if (index == 10)
            {
                questionText.text = data.q11.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q11.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q11.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q11.ans3.ToString();

                cur = data.q11.num;
            }
            else if (index == 11)
            {
                questionText.text = data.q12.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q12.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q12.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q12.ans3.ToString();

                cur = data.q12.num;
            }
            else if (index == 12)
            {
                questionText.text = data.q13.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q13.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q13.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q13.ans3.ToString();

                cur = data.q13.num;
            }
            else if (index == 13)
            {
                questionText.text = data.q14.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q14.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q14.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q14.ans3.ToString();

                cur = data.q14.num;
            }
            else if (index == 14)
            {
                questionText.text = data.q15.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q15.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q15.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q15.ans3.ToString();

                cur = data.q15.num;
            }
            else if (index == 15)
            {
                questionText.text = data.q16.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q16.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q16.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q16.ans3.ToString();

                cur = data.q16.num;
            }
            else if (index == 16)
            {
                questionText.text = data.q17.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q17.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q17.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q17.ans3.ToString();

                cur = data.q17.num;
            }
            else if (index == 17)
            {
                questionText.text = data.q18.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q18.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q18.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q18.ans3.ToString();

                cur = data.q18.num;
            }
            else if (index == 18)
            {
                questionText.text = data.q19.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q19.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q19.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q19.ans3.ToString();

                cur = data.q19.num;
            }
            else if (index == 19)
            {
                questionText.text = data.q20.question.ToString();

                answerbutton[0].transform.parent.GetComponent<Animation>().Play("Y5 - RaceQuestion");

                answerbutton[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q20.ans1.ToString();
                answerbutton[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q20.ans2.ToString();
                answerbutton[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data.q20.ans3.ToString();

                cur = data.q20.num;
            }
        }

     
    }

    void BotSpeed()
    {
        newSpeed = Random.Range(0, 100);

        if (newSpeed <= 45)
        {
            AIspeed = speed;
        }
        else if (newSpeed <= 60 && newSpeed >= 46)
        {
            AIspeed = speed * multiplier[0];
        }
        else if (newSpeed <= 75 && newSpeed >= 61)
        {
            AIspeed = speed * multiplier[1];
        }
        else if (newSpeed <= 85 && newSpeed >= 76)
        {
            AIspeed = speed * multiplier[2];
        }
        else if (newSpeed <= 95 && newSpeed >= 86)
        {
            AIspeed = speed * multiplier[3];
        }
        else if (newSpeed <= 100 && newSpeed >= 96)
        {
            AIspeed = speed * multiplier[4];
        }
    }

    public void button(int index)
    {
        StartCoroutine(DisableButtons());

        if (cur == index)
        {
            StartCoroutine(DisableButton());
            StartCoroutine(Change());

            player.transform.GetChild(3).GetComponent<Animation>().Play("Go Splat");

            audioSource.clip = sound[0];
            audioSource.Play();
        }
        else if (cur != index)
        {
            playerSpeed = speed;

            audioSource.clip = sound[1];
            audioSource.Play();

            StartCoroutine(Wrong());
        }
    }

    IEnumerator DisableButtons()
    {
        List<GameObject> disable = new List<GameObject>();

        disable.AddRange(GameObject.FindGameObjectsWithTag("Animal 1"));

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = false;
        }

        yield return new WaitForSeconds(1f);

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator Wrong()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        img.color = Color.red;

        yield return new WaitForSeconds(1f);

        img.color = Color.white;
    }

    IEnumerator DisableButton()
    {
        List<GameObject> disable = new List<GameObject>();
        disable.AddRange(GameObject.FindGameObjectsWithTag("False"));
        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = false;
        }

        yield return new WaitForSeconds(1f);

        foreach (GameObject but in disable)
        {
            but.GetComponent<Button>().enabled = true;
        }
    }

    public void PlayAgain()
    {
        for (int i = 0; i < tstbool.Length; i++)
        {
            tstbool[i] = false;
            tstbool[0] = true;
        }

        Time.timeScale = 1;
        timerText.enabled = true;
        isTimer = true;

        pop.SetActive(false);

        player.transform.position = oriPos[0];
        bot.transform.position = oriPos[1];

        playerSpeed = speed;
        thingsToRemoveFirst[0].SetActive(false);
    }

    public void BackToAR()
    {
        SceneManager.LoadScene("Y5 - C5 AR");
    }

    IEnumerator Change()
    {
        Image image = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        image.color = Color.green;

        yield return new WaitForSeconds(1f);

        image.color = Color.white;
        LookForQuestion();

        if (tstbool[0])
        {
            for (int i = 0; i < tstbool.Length; i++)
            {
                tstbool[i] = false;
                tstbool[1] = true;
            }
        }
        else if (tstbool[1])
        {
            for (int i = 0; i < tstbool.Length; i++)
            {
                tstbool[i] = false;
                tstbool[2] = true;
            }
        }
        else if (tstbool[2])
        {
            for (int i = 0; i < tstbool.Length; i++)
            {
                tstbool[i] = false;
                tstbool[3] = true;
            }
        }
        else if (tstbool[3])
        {
            for (int i = 0; i < tstbool.Length; i++)
            {
                tstbool[i] = false;
                tstbool[4] = true;
            }
        }
        else if (tstbool[4])
        {
            for (int i = 0; i < tstbool.Length; i++)
            {
                tstbool[i] = false;
                tstbool[5] = true;
            }
        }

        if (tstbool[1])
        {
            playerSpeed = speed * multiplier[0];
        }
        else if (tstbool[2])
        {
            playerSpeed = speed * multiplier[1];
        }
        else if (tstbool[3])
        {
            playerSpeed = speed * multiplier[2];
        }
        else if (tstbool[4])
        {
            playerSpeed = speed * multiplier[3];
        }
        else if (tstbool[5])
        {
            playerSpeed = speed * multiplier[4];
        }
    }
}