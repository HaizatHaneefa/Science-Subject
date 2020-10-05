using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Year5PlantsAR : MonoBehaviour
{
    [SerializeField] private GameObject[] canvas;
    [SerializeField] private GameObject dummyObject;
    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private Image[] imageButtons;

    void Start()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }

        dummyObject.SetActive(false);
    }

    public void _ProtectionEnemies()
    {
        dummyObject.SetActive(false);

        imageButtons[0].sprite = buttonSprite[0];
        imageButtons[1].sprite = buttonSprite[1];

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
            canvas[0].SetActive(true);
            canvas[0].GetComponent<Animation>().Play("Y5 - Animal AR");
        }
    }

    public void _ProtectionWeather()
    {
        dummyObject.SetActive(false);

        imageButtons[1].sprite = buttonSprite[0];
        imageButtons[0].sprite = buttonSprite[1];

        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
            canvas[1].SetActive(true);
            canvas[1].GetComponent<Animation>().Play("Y5 - Animal AR");
        }
    }

    public void Quiz()
    {
        SceneManager.LoadScene("Y5 - C5 Quiz");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowDummyObject()
    {
        dummyObject.SetActive(true);
    }
}
