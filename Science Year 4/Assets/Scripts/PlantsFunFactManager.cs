using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlantsFunFactManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI explainText;

    [SerializeField] private string[] explain;
    [SerializeField] private string[] dialogue;

    //[SerializeField] private GameObject image;
    [SerializeField] private GameObject[] image;
    [SerializeField] private GameObject[] buttons, plantButtons;

    int num;

    [SerializeField] private Sprite[] sprite;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        explainText.enabled = false;

        for (int i = 0; i < image.Length; i++)
        {
            image[i].SetActive(false);
        }
    }

    public void PlantsResponse()
    {
        explainText.enabled = true;

        explainText.text = explain[0].ToString();

        for (int i = 0; i < image.Length; i++)
        {
            image[i].SetActive(false);
            image[0].SetActive(true);
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        num = 0;
        
        plantButtons[0].GetComponent<Image>().sprite = sprite[1];
        plantButtons[1].GetComponent<Image>().sprite = sprite[0];

    }

    public void PlantsTropism()
    {
        explainText.enabled = true;

        for (int i = 0; i < image.Length; i++)
        {
            image[i].SetActive(false);
            image[1].SetActive(true);
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }

        if (num == 0)
        {
            explainText.text = dialogue[0].ToString();
        }

        plantButtons[1].GetComponent<Image>().sprite = sprite[1];
        plantButtons[0].GetComponent<Image>().sprite = sprite[0];
    }

    public void Back()
    {
        explainText.enabled = false;

        explainText.text = "";
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextDialogue()
    {
        if (num == 1)
        {
            return;
        }
        if (num == 0)
        {
            explainText.text = dialogue[1].ToString();
            num = 1;
        }
    }

    public void PrevDialogue()
    {
        if (num == 0)
        {
            return;
        }
        else if (num == 1)
        {
            explainText.text = dialogue[0].ToString();
            num = 0;
        }
    }
}
