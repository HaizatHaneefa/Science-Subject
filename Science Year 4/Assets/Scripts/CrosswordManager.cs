using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrosswordManager : MonoBehaviour
{
    public string answer;

    public Image[] word1;
    public Image[] word2;

    public bool[] isHere;

    public string writingAnswer;

    public int number;

    void Start()
    {
        isHere = new bool[4];

        for (int i = 0; i < word1.Length; i++)
        {
            word1[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        }

        number = 0;
    }

    void FixedUpdate()
    {
        word1[number].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = writingAnswer.ToUpper();

        #region word 1
        if (word1[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 1;
        }

        if (word1[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 2;
        }

        if (word1[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 3;
        }

        if (word1[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 4;
        }

        if (word1[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("B") &&
            word1[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("O") &&
            word1[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("L") &&
            word1[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("A"))
        {
            Debug.Log("sdsdsdsd");
        }
        #endregion

        #region word 2
        if (word2[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 1;
        }

        if (word2[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 2;
        }

        if (word2[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 3;
        }

        if (word2[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text != "")
        {
            ResetWriting();
            number = 4;
        }

        if (word2[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("B") &&
            word2[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("O") &&
            word2[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("L") &&
            word2[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains("A"))
        {
            Debug.Log("sdsdsdsd");
        }
        #endregion
    }

    void ResetWriting()
    {
        writingAnswer = "";
    }
}
