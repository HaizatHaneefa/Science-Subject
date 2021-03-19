using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyGameManager : MonoBehaviour
{
    [SerializeField] private MoneyList[] moneylist;

    [SerializeField] private float changeValue, totalChangeValue, timer;
    [SerializeField] private Sprite[] moneySprite;
    [SerializeField] private TextMeshProUGUI dialogueText, changeText, timerText;
    [SerializeField] private string[] dialogue;

    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject yayPop;

    int cur;

    void Start()
    {
        dialogue = new string[3];
        dialogue[0] = "I would like to buy ";
        dialogue[1] = ". It costs ";
        dialogue[2] = "I'll give you RM 1. You owe me ";

        cur = Random.Range(0, moneylist.Length);
        yayPop.SetActive(false);

        timer = 60f;

        itemImage.enabled = false;
    }

    public void StartGame()
    {
        itemImage.enabled = true;

        // stuff starts here
    }

    public void _Value(int index)
    {
        if (index == 0)
        {
            totalChangeValue += .50f;
        }
        else if (index == 1)
        {
            totalChangeValue += .20f;
        }
        else if (index == 2)
        {
            totalChangeValue += .10f;
        }
        else if (index == 3)
        {
            totalChangeValue += .05f;
        }
        else if (index == 4)
        {
            totalChangeValue += .01f;
        }

        changeText.text = totalChangeValue.ToString();
    }

    public void _Calculate()
    {
        if (totalChangeValue == moneylist[cur].change)
        {
            ChangeQuestion();
            Debug.Log("qwqwewew");
        }
        else if (totalChangeValue != moneylist[cur].change)
        {
            // redo it
            totalChangeValue = 0f;
        }
    }

    void ChangeQuestion()
    {
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        yayPop.SetActive(true);
        yayPop.GetComponent<Animation>().Play("SuccessPop");
        // do some animation shit

        // display yay
        // sound
        totalChangeValue = 0f;

        yield return new WaitForSeconds(1f);

        cur = Random.Range(0, moneylist.Length);

        changeText.text = totalChangeValue.ToString();

        yayPop.SetActive(false);
        // close yay
        // change question
    }

    void Update()
    {
        itemImage.sprite = moneylist[cur].artwork;

        dialogueText.text = dialogue[0] + moneylist[cur].name + dialogue[1] + moneylist[cur].value + "sen. " + dialogue[2] + moneylist[cur].change + "sen";

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timer -= Time.deltaTime;
        timerText.text = niceTime;
    }
}
