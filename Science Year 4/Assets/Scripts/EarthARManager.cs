using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EarthARManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI firstText, secondText, thirdText, forthText;
    //[SerializeField] private 
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Button[] button;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void _RotationEarth()
    {
        button[0].GetComponent<Image>().sprite = sprite[1];

    }
}
