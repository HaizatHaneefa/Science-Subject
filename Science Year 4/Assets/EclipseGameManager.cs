using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EclipseGameManager : MonoBehaviour
{
    [SerializeField] public bool[] isDone;
    [SerializeField] public Button confirmButton;

    [SerializeField] private GameObject[] col;
    [SerializeField] private TextMeshProUGUI progresstext;
    [SerializeField] public GameObject popInfo, wrongPop, endpop, pausePop, introPop;
    int cur;

    void Start()
    {
        popInfo.SetActive(false);
        wrongPop.SetActive(false);
        endpop.SetActive(false);
        pausePop.SetActive(false);
        introPop.SetActive(true);

        isDone = new bool[3];
        confirmButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        progresstext.text = cur.ToString() + "/3";

        if (!isDone[0])
        {
            wrongPop.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Please visit stage 1";
            popInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "stage 1";
        }
        else if (isDone[0])
        {
            wrongPop.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Please visit stage 2";
            popInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "stage 2";
        }

        if (isDone[1])
        {
            popInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "stage 3";
            Debug.Log("ww");
        }

        if (isDone[2])
        {
            endpop.SetActive(true);
        }
    }

    public void Confirm()
    {
        popInfo.SetActive(true);
        confirmButton.gameObject.SetActive(false);
    }

    public void Continue()
    {
        popInfo.SetActive(false);

        cur += 1;

        if (!isDone[0])
        {
            isDone[0] = true;

            col[0].transform.GetChild(0).gameObject.SetActive(false);
            col[0].GetComponent<BoxCollider>().enabled = false;
        }
        else if (isDone[0] && !isDone[1])
        {
            isDone[1] = true;

            col[1].transform.GetChild(0).gameObject.SetActive(false);
            col[1].GetComponent<BoxCollider>().enabled = false;
        }
        else if (isDone[1] && !isDone[2])
        {
            isDone[2] = true;

            col[2].transform.GetChild(0).gameObject.SetActive(false);
            col[2].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void _Pause(int index)
    {
        if (index == 0)
        {
            pausePop.SetActive(true);
            Time.timeScale = 0;
        }
        else if (index == 1)
        {
            pausePop.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void _Start()
    {
        introPop.SetActive(false);
    }

    public void _BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void _Retry()
    {
        SceneManager.LoadScene("Y6 - Eclipse Game");
    }
}
