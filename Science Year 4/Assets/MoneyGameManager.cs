using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyGameManager : MonoBehaviour
{
    [SerializeField] private MoneyList[] moneylist;

    [SerializeField] private float initValue, changeValue, totalChangeValue;
    [SerializeField] private Sprite[] moneySprite;
    [SerializeField] private TextMeshProUGUI dialogueText, changeText;
    [SerializeField] private string[] dialogue;

    int cur;

    void Start()
    {
        dialogue = new string[3];
        dialogue[0] = "I would like to buy this ";
        dialogue[1] = ". It costs ";
        dialogue[2] = "I'll give you RM 1. You owe me ";

        initValue = 1f;

        cur = Random.Range(0, moneylist.Length);
    }

    public void _Value(int index)
    {
        changeText.text = totalChangeValue.ToString();

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
    }

    public void _Calculate()
    {
        if (totalChangeValue == moneylist[cur].change)
        {
            Debug.Log("qwqwewew");
        }
        else if (totalChangeValue != moneylist[cur].change)
        {
            // redo it
            ChangeQuestion();
        }
    }

    void ChangeQuestion()
    {
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        // display yay
        // sound
        totalChangeValue = 0f;

        yield return new WaitForSeconds(1f);


        changeText.text = totalChangeValue.ToString();
        // close yay
        // change question
    }

    void Update()
    {

        dialogueText.text = dialogue[0] + moneylist[cur].name + dialogue[1] + moneylist[cur].value + "sens. " + dialogue[2] + moneylist[cur].change + "sens";
    }
}
