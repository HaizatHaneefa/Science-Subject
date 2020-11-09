using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EclipseGameManager : MonoBehaviour
{
    [SerializeField] public bool[] isDone;
    [SerializeField] public Button confirmButton;

    [SerializeField] private GameObject[] col;
    [SerializeField] private TextMeshProUGUI progresstext;
    [SerializeField] private GameObject popInfo;
    int cur;

    void Start()
    {
        popInfo.SetActive(false);

        isDone = new bool[3];
        confirmButton.gameObject.SetActive(false);
    }

    void Update()
    {
        progresstext.text = cur.ToString() + "/3";
    }

    public void Confirm()
    {
        popInfo.SetActive(true);
    }

    public void Continue()
    {
        popInfo.SetActive(false);

        cur += 1;

        if (!isDone[0])
        {
            isDone[0] = true;

            col[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (isDone[0] && !isDone[1])
        {
            isDone[1] = true;

            col[1].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (isDone[1] && !isDone[2])
        {
            isDone[2] = true;

            col[2].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
