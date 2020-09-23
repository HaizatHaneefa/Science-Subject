using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceCarManager : MonoBehaviour
{
    [SerializeField] private RaceCarData data;
    [SerializeField] private GameObject carStatsHolder, goButton;
    [SerializeField] private GameObject[] cars;

    [SerializeField] private TextMeshProUGUI carNameText;

    [SerializeField] private Slider[] statsSlider;

    [SerializeField] private Material[] carMats;
    [SerializeField] private GameObject[] colorPalette;
    [SerializeField] private Material[] carTexture;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("GameController").GetComponent<RaceCarData>();

        
        carStatsHolder.SetActive(false);
        goButton.SetActive(false);

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
        }

        for (int i = 0; i < colorPalette.Length; i++)
        {
            colorPalette[i].SetActive(false);
        }
    }

    public void ChooseCar(int index)
    {
        carStatsHolder.SetActive(true);
        goButton.SetActive(true);

        if (index == 0)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[0].SetActive(true);
            }

            carNameText.text = data.c1.carName.ToString();

            statsSlider[0].value = data.c1.topSpeed;
            statsSlider[1].value = data.c1.accel;
            statsSlider[2].value = data.c1.control;
            statsSlider[3].value = data.c1.strength;
        }
        else if (index == 1)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[1].SetActive(true);
            }

            carNameText.text = data.c2.carName.ToString();

            statsSlider[0].value = data.c2.topSpeed;
            statsSlider[1].value = data.c2.accel;
            statsSlider[2].value = data.c2.control;
            statsSlider[3].value = data.c2.strength;
        }
        else if (index == 2)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[2].SetActive(true);
            }

            carNameText.text = data.c3.carName.ToString();

            statsSlider[0].value = data.c3.topSpeed;
            statsSlider[1].value = data.c3.accel;
            statsSlider[2].value = data.c3.control;
            statsSlider[3].value = data.c3.strength;
        }
    }

    public void ChangeColor(int index)
    {
        if (cars[0].activeInHierarchy)
        {
            if (index == 0)
            {
                cars[0].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[0];
            }
            else if (index == 1)
            {
                cars[0].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[1];
            }
            else if (index == 2)
            {
                cars[0].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[2];
            }
        }
        else if (cars[1].activeInHierarchy)
        {
            if (index == 0)
            {
                cars[1].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[3];
            }
            else if (index == 1)
            {
                cars[1].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[4];
            }
            else if (index == 2)
            {
                cars[1].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[5];
            }
        }
        else if (cars[2].activeInHierarchy)
        {
            if (index == 0)
            {
                cars[2].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[6];
            }
            else if (index == 1)
            {
                cars[2].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[7];
            }
            else if (index == 2)
            {
                cars[2].transform.GetChild(0).GetComponent<Renderer>().material = carTexture[8];
            }
        }
    }

    public void GoRace()
    {
        SceneManager.LoadScene(""); // to the bloody race
    }

    public void GoBack()
    {
        SceneManager.LoadScene(""); // previous scene
    }
}
