using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    [SerializeField] private GameObject[] row1, row2, row3;
    [SerializeField] private List<GameObject> r1, r2, r3;

    public int num;
    public int boolNum;

    bool[] rowBool;

    public Image[] image;

    [SerializeField] private LineRenderer lr;

    void Start()
    {
        GameObject lineObject = new GameObject();
        lr = lineObject.AddComponent<LineRenderer>();

        rowBool = new bool[3];
        rowBool[0] = true;

        for (int i = 0; i < row1.Length; i++)
        {
            r1.Add(row1[i]);
        }

        for (int i = 0; i < row2.Length; i++)
        {
            r2.Add(row2[i]);
        }

        for (int i = 0; i < row3.Length; i++)
        {
            r3.Add(row3[i]);
        }
    }

    void Update()
    {
        DrawLine();

        for (int i = 0; i < r1.Count; i++)
        {
            if (rowBool[0])
            {
                r1[i].GetComponent<Image>().color = Color.white;
                r1[num].GetComponent<Image>().color = Color.green;
            }
            else if (!rowBool[0])
            {
                r1[i].GetComponent<Image>().color = Color.white;
            }
        }

        for (int i = 0; i < r2.Count; i++)
        {
            if (rowBool[1])
            {
                r2[i].GetComponent<Image>().color = Color.white;
                r2[num].GetComponent<Image>().color = Color.green;
            }
            else if (!rowBool[1])
            {
                r2[i].GetComponent<Image>().color = Color.white;
            }
        }

        for (int i = 0; i < r3.Count; i++)
        {
            if (rowBool[2])
            {
                r3[i].GetComponent<Image>().color = Color.white;
                r3[num].GetComponent<Image>().color = Color.green;
            }
            else if (!rowBool[2])
            {
                r3[i].GetComponent<Image>().color = Color.white;
            }
        }

        for (int i = 0; i < rowBool.Length; i++)
        {
            rowBool[i] = false;
            rowBool[boolNum] = true;
        }
    }

    public void directions()
    {
        if (EventSystem.current.currentSelectedGameObject.CompareTag("Right"))
        {
            int row1End = r1.Count - 1;
            int row2End = r2.Count - 1;
            int row3End = r3.Count - 1;

            if (num == row1End && rowBool[0] || num == row2End && rowBool[1] || num == row3End && rowBool[2])
            {
                return;
            }
            num += 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.CompareTag("Left"))
        {
            if (num == 0)
            {
                return;
            }

            num -= 1;
        }
        else if (EventSystem.current.currentSelectedGameObject.CompareTag("Down"))
        {
            if (boolNum == 2)
            {
                return;
            }

            boolNum += 1;
            num = 0;
        }
        else if (EventSystem.current.currentSelectedGameObject.CompareTag("Up"))
        {
            if (boolNum == 0)
            {
                return;
            }

            boolNum -= 1;
            num = 0;
        }
    }

    public void Confirm()
    {
        if (rowBool[0])
        {
            r1[num].SetActive(false);
            r1.Remove(r1[num]);
        }
        else if (rowBool[1])
        {
            r2[num].SetActive(false);
            r2.Remove(r2[num]);
        }
        else if (rowBool[2])
        {
            r3[num].SetActive(false);
            r3.Remove(r3[num]);
        }
    }

    void DrawLine()
    {
        lr.startWidth = 0.2f;
        lr.endWidth = 0.2f;

        Vector3[] positions = new Vector3[2];

        if (rowBool[0])
        {
            positions[0] = image[0].transform.position;
            positions[1] = r1[num].transform.position;
        }
        else if (rowBool[1])
        {
            positions[0] = image[0].transform.position;
            positions[1] = r2[num].transform.position;
        }
        else if (rowBool[2])
        {
            positions[0] = image[0].transform.position;
            positions[1] = r3[num].transform.position;
        }

        lr.positionCount = positions.Length;

        lr.SetPositions(positions);
    }
}
