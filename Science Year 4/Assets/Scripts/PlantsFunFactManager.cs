using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlantsFunFactManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI explainText;

    [SerializeField] private string[] explain;
    [SerializeField] private string[] dialogue;

    [SerializeField] private GameObject image;
    [SerializeField] private GameObject[] buttons;

    int num;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        explainText.enabled = false;

        image.SetActive(false);
    }

    public void PlantsResponse()
    {
        explainText.enabled = true;

        explainText.text = explain[0].ToString();

        image.SetActive(false);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        num = 0;
    }

    public void PlantsTropism()
    {
        explainText.enabled = true;

        image.SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }

        if (num == 0)
        {
            explainText.text = dialogue[0].ToString();
        }
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
        if (num == 2)
        {
            return;
        }
        if (num == 0)
        {
            explainText.text = dialogue[1].ToString();
            num = 1;
        }
        else if (num == 1)
        {
            explainText.text = dialogue[2].ToString();
            num = 2;
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
        else if (num == 2)
        {
            explainText.text = dialogue[1].ToString();
            num = 1;
        }
    }
}
