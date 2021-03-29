using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MoneyGameManager : MonoBehaviour
{
    [SerializeField] private MoneyList[] moneylist;

    [SerializeField] private float totalChangeValue, timer, floatValue;
    [SerializeField] private Sprite[] moneySprite;
    [SerializeField] private TextMeshProUGUI dialogueText, changeText, timerText, counterText, salesText;
    [SerializeField] private string[] dialogue;

    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject yayPop, introPop, endPop;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    int cur, howMany;

    bool hasStarted;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        dialogue = new string[3];
        dialogue[0] = "I would like to buy ";
        dialogue[1] = ". It costs ";
        dialogue[2] = "I'll give you RM 1. You owe me ";

        introPop.GetComponent<Animation>().Play("SuccessPop");

        cur = Random.Range(0, moneylist.Length);
        yayPop.SetActive(false);
        endPop.SetActive(false);

        timer = 60f;

        itemImage.enabled = false;
        dialogueText.enabled = false;
    }

    public void _Value(int index)
    {
        if (index == 0)
        {
            totalChangeValue = totalChangeValue + .50f;
        }
        else if (index == 1)
        {
            totalChangeValue = totalChangeValue + .20f;
        }
        else if (index == 2)
        {
            totalChangeValue = totalChangeValue + .10f;
        }
        else if (index == 3)
        {
            totalChangeValue = totalChangeValue + .05f;
        }
        else if (index == 4)
        {
            totalChangeValue = totalChangeValue + .01f;
        }
    }

    public void _Calculate()
    {
        floatValue = float.Parse(changeText.text);

        if (floatValue == moneylist[cur].change)
        {
            ChangeQuestion();
            Debug.Log("qwqwewew");
            howMany += 1;
        }
        else if (floatValue != moneylist[cur].change)
        {
            WrongPressSFX();
            totalChangeValue = 0f;
        }
    }

    public void _Start()
    {
        PressSFX();
        hasStarted = true;

        dialogueText.enabled = true;
        itemImage.enabled = true;

        introPop.SetActive(false);
    }

    void ChangeQuestion()
    {
        StartCoroutine(Change());
    }

    public void _Reset()
    {
        totalChangeValue = 0f;
    }

    IEnumerator Change()
    {
        RightSFX();
        yayPop.SetActive(true);
        yayPop.GetComponent<Animation>().Play("MoneyYayPop");

        yield return new WaitForSeconds(.8f);

        totalChangeValue = 0f;

        cur = Random.Range(0, moneylist.Length);

        yayPop.SetActive(false);
    }

    public void _Back()
    {
        BackSFX();
        SceneManager.LoadScene("Menu");
    }

    public void _Retry()
    {
        PressSFX();
        SceneManager.LoadScene("Y4 - Money Game");
    }

    void EndPop()
    {
        EndSFX();

        timer = 0f;

        hasStarted = false;

        endPop.SetActive(true);
    }

    void Update()
    {
        if (hasStarted)
        {
            salesText.text = howMany.ToString();
            changeText.text = totalChangeValue.ToString("F2");

            counterText.text = "Congratulations! Correct changes:" + "\n" + howMany.ToString();

            timer -= Time.deltaTime;

            itemImage.sprite = moneylist[cur].artwork;

            dialogueText.text = dialogue[0] + moneylist[cur].name + dialogue[1] + moneylist[cur].value + "sen. " + dialogue[2] + moneylist[cur].change + "sen";
        }

        if (timer <= 0)
        {
            // end the game
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
