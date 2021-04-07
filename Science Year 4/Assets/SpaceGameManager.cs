using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpaceGameManager : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Image pointer;

    [SerializeField] private TextMeshProUGUI questionText, roundText;

    [SerializeField] private GameObject introPop, endPop;

    float sliderValue;

    public List<int> intList;

    int qNumber, questionValue;

    bool hasStarted;
    void Start()
    {
        endPop.SetActive(false);
        introPop.SetActive(true);
        introPop.GetComponent<Animation>().Play("GameOverPop");

        slider.value = 0;

        StoreList();
    }

    void StoreList()
    {
        qNumber += 1;

        for (int i = 0; i < intList.Count; i++)
        {
            intList[i] = 0;
        }

        questionValue = Random.Range(0, 180);

        intList[0] = questionValue;
        intList[1] = questionValue + 1;
        intList[2] = questionValue + 2;
        intList[3] = questionValue + 3;
        intList[4] = questionValue - 1;
        intList[5] = questionValue - 2;
        intList[6] = questionValue - 3;
    }

    public void _SliderValue()
    {
        sliderValue = (int)slider.value;
        pointer.transform.rotation = Quaternion.Euler(0, 0, (int)sliderValue);
    }

    public void _CheckValue()
    {
        if (intList.Contains((int)sliderValue))
        {
            if (qNumber == 9)
            {
                endPop.GetComponent<Animation>().Play("GameOverPop");
                hasStarted = false;
                // end the game
            }

            NextQuestion();
        }
        else if (!intList.Contains((int)sliderValue))
        {
        }
    }

    void NextQuestion()
    {
        questionValue = Random.Range(0, 180);

        StoreList();

        slider.value = 0;

        pointer.transform.rotation = Quaternion.Euler(0, 0, slider.value);
    }

    public void _Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void _Retry()
    {
        SceneManager.LoadScene("Y6 - Space Game");
    }

    public void _Start()
    {
        introPop.SetActive(false);
        hasStarted = true;
    }

    void Update()
    {
        if (hasStarted)
        {
            questionText.text = questionValue.ToString();
            roundText.text = "Round: " + qNumber.ToString() + "/10";
        }
    }
}

