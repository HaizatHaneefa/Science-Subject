using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FunFactY5Animals : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI explainText;

    [SerializeField] private string[] explanation;

    [SerializeField] private Image exampleImage;

    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Sprite[] buttonSprite;

    [SerializeField] private Button[] button;
    void Start()
    {
        explainText.enabled = false;
        exampleImage.enabled = false;
    }

    public void _Camel()
    {
        explainText.enabled = true;
        explainText.text = explanation[0].ToString();

        exampleImage.enabled = true;
        exampleImage.sprite = sprite[0];

        button[0].GetComponent<Image>().sprite = buttonSprite[1];
        button[1].GetComponent<Image>().sprite = buttonSprite[0];
    }

    public void _Birds()
    {
        explainText.enabled = true;
        explainText.text = explanation[1].ToString();

        exampleImage.enabled = true;
        exampleImage.sprite = sprite[1];


        button[0].GetComponent<Image>().sprite = buttonSprite[0];
        button[1].GetComponent<Image>().sprite = buttonSprite[1];
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
