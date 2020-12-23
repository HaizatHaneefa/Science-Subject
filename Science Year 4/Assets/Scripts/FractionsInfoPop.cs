using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FractionsInfoPop : MonoBehaviour
{
    FractionARManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FractionARManager>();
    }

    void Update()
    {
        
    }

    public void _Press()
    {
        manager.descriptiveSection.SetActive(true);

        if (gameObject.CompareTag("Up"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[0].ToString();
        }
        else if (gameObject.CompareTag("Down"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[1].ToString();
        }
        else if (gameObject.CompareTag("Right"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[2].ToString();
        }
        else if (gameObject.CompareTag("Left"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[3].ToString();
        }
        else if (gameObject.CompareTag("True"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[4].ToString();
        }
        else if (gameObject.CompareTag("False"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[5].ToString();
        }
        else if (gameObject.CompareTag("Day"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[6].ToString();
        }
        else if (gameObject.CompareTag("Night"))
        {
            manager.descriptiveSection.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = manager.sentence[7].ToString();
        }
    }
}
