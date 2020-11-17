using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeText : MonoBehaviour, IPointerDownHandler
{
    public GameObject[] textPanel;
    public GameObject target;
    private int index;
    public AudioSource pop;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (index == textPanel.Length - 1)
        {
            target.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (index < textPanel.Length)
        {
            pop.Play();
            index++;
            textPanel[index].SetActive(true);
        }

        for (int i = 0; i < textPanel.Length; i++)
        {
            if (textPanel[i] != textPanel[index])
            {
                textPanel[i].SetActive(false);
            }
        }
    }
}
