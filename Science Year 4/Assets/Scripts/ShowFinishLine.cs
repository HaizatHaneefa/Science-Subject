using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFinishLine : MonoBehaviour
{
    [SerializeField] FiveAnimalGameManager manager;
    [SerializeField] Image finishLineImage;

    [SerializeField] Color colorw;

    bool isChanging;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FiveAnimalGameManager>();


        colorw = finishLineImage.color;
        colorw.a = 0f;
        finishLineImage.color = colorw;
        //finishLineImage.color.a = 0f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isChanging = true;
    }

    private void Update()
    {
        if (isChanging)
        {
            finishLineImage.color = colorw;
            colorw.a += 0.02f;
        }
    }
}
