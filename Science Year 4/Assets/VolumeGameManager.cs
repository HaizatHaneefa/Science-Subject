using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class VolumeGameManager : MonoBehaviour
{
    [SerializeField] private NewBehaviourScript[] items;

    [SerializeField] private GameObject[] _buttons;
    [SerializeField] private GameObject introPop, yayPop, endPop;

    [SerializeField] private TextMeshProUGUI timerText, scoreText, roundText, questionText;

    float timer;

    bool isTiming;

    [SerializeField] private int curInt, round, score;
    [SerializeField] private List<int> valueInt;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        curInt = Random.Range(3, 5);

        GetValueButton();

        endPop.SetActive(false);
        introPop.SetActive(true);
        introPop.GetComponent<Animation>().Play("GameOverPop");

        timer = 60f;

        roundText.text = "Round: " + round.ToString();
        scoreText.text = "Score: " + score.ToString();

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].SetActive(false);
        }
    }

    public void _Button()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;

        int i = System.Array.IndexOf(_buttons, go);

        if (valueInt[i] == curInt)
        {
            RightSFX();
            valueInt[i] += 10;
            score += 1;

            go.SetActive(false);
        }
        else if (valueInt[i] == curInt)
        {
            WrongSFX();
        }

        if (valueInt.Contains(curInt))
        {
            return;
        }
        else if (!valueInt.Contains(curInt))
        {
            ChangeQuestion();
        }
    }

    public void _Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].SetActive(true);
        }

        PressSFX();
        isTiming = true;
        introPop.SetActive(false);
    }
    void ChangeQuestion()
    {
        GetValueButton();
        curInt = Random.Range(3, 5);
    }

    void GetValueButton()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].SetActive(true);
        }

        valueInt.Clear();

        foreach (GameObject go in _buttons)
        {
            int val;
            val = Random.Range(0, items.Length);

            go.GetComponent<Image>().sprite = items[val].artwork;

            valueInt.Add(items[val].value);
        }

        Checker();
    }

    void Checker()
    {
        if (valueInt.Contains(curInt))
        {
            return;
        }
        else if (!valueInt.Contains(curInt))
        {
            GetValueButton();
            valueInt.Clear();
        }
    }

    void EndGame()
    {
        endPop.SetActive(true);
        endPop.GetComponent<Animation>().Play("GameOverPop");
    }

    public void _Back()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _Restart()
    {
        PressSFX();
        SceneManager.LoadScene("Y5 - Volume of Liquid Game");
    }

    void Update()
    {
        if (isTiming)
        {
            questionText.text = "Click the shapes with a volume of " + curInt + " cubic units.";
            roundText.text = "Round: " + round.ToString();
            scoreText.text = "Score: " + score.ToString();

            timer -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerText.text = niceTime;
        }

        if (timer <= 0 && isTiming)
        {
            EndGame();
            isTiming = false;
        }
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
