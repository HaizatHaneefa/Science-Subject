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

    [SerializeField] private GameObject[] col, infoPops;
    [SerializeField] private TextMeshProUGUI progresstext, text1, text2;
    [SerializeField] public GameObject popInfo, wrongPop, endpop, pausePop, introPop, pauseButton;
    [SerializeField] private string[] questions;
    [SerializeField]private int cur, stageInt;

    bool testBool;

    void Start()
    {
        popInfo.SetActive(false);
        wrongPop.SetActive(false);
        endpop.SetActive(false);
        pausePop.SetActive(false);
        introPop.SetActive(true);

        isDone = new bool[3];
        cur = 1;
        confirmButton.gameObject.SetActive(false);
        Time.timeScale = 1;

        for (int i = 0; i < infoPops.Length; i++)
        {
            infoPops[i].SetActive(false);
        }
    }

    void Update()
    {
        progresstext.text = cur.ToString() + "/3";

        if (!isDone[0])
        {
            wrongPop.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Please visit stage 1";
        }
        else if (isDone[0])
        {
            wrongPop.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Please visit stage 2";
        }

        if (isDone[1])
        {
            popInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "stage 3";
        }

        if (isDone[2])
        {
            endpop.SetActive(true);
        }
    }

    public void Confirm() // pops the info
    {
        if (stageInt == 0)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[0].SetActive(true);
            }
        }
        else if (stageInt == 1)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[4].SetActive(true);
            }
        }
        else if (stageInt == 2)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[8].SetActive(true);
            }
        }
        confirmButton.gameObject.SetActive(false);
    }

    public void Continue() // info pop button
    {
        if (stageInt == 0 && !testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[2].SetActive(true);
            }

            testBool = true;
        }
        else if (stageInt == 0 && testBool)
        {
            isDone[0] = true;

            col[0].transform.GetChild(0).gameObject.SetActive(false);
            col[0].GetComponent<BoxCollider>().enabled = false;

            testBool = false;

            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
            }

            cur += 1;
            stageInt = 1;
        }
        else if (stageInt == 1 && !testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[6].SetActive(true);
            }

            testBool = true;

        }
        else if (stageInt == 1 && testBool)
        {
            isDone[1] = true;

            col[1].transform.GetChild(0).gameObject.SetActive(false);
            col[1].GetComponent<BoxCollider>().enabled = false;

            testBool = false;

            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
            }
            cur += 1;

            stageInt = 2;
        }
        else if (stageInt == 2 && !testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[10].SetActive(true);
            }

            testBool = true;
        }
        else if (stageInt == 2 && testBool)
        {
            isDone[2] = true;

            col[2].transform.GetChild(0).gameObject.SetActive(false);
            col[2].GetComponent<BoxCollider>().enabled = false;

            testBool = false;

            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
            }
            cur += 1;
            endpop.SetActive(true);
            // end the game
        }

   
    }

    public void test() // this is for the fucking question
    {

        if (stageInt == 0 && !testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[1].SetActive(true);
            }
        }
        else if (stageInt == 0 && testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[3].SetActive(true);
            }
        }
        else if (stageInt == 1 && !testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[5].SetActive(true);
            }
        }
        else if (stageInt == 1 && testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[7].SetActive(true);
            }
        }

        else if (stageInt == 2 && !testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[9].SetActive(true);
            }
        }
        else if (stageInt == 2 && testBool)
        {
            for (int i = 0; i < infoPops.Length; i++)
            {
                infoPops[i].SetActive(false);
                infoPops[11].SetActive(true);
            }
        }
    }

    public void _Pause(int index)
    {
        if (index == 0)
        {
            pausePop.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0;
        }
        else if (index == 1)
        {
            pausePop.SetActive(false);
            pauseButton.SetActive(true);
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
