using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StayPressed : MonoBehaviour
{
    bool btn1Pressed = true;
    bool btn2Pressed = false;
    bool btn3Pressed = false;

    public GameObject btn1, btn2, btn3;

    public Sprite pressedSprite;
    public Sprite unpressedSprite;



    private void Update()
    {
        if (btn1Pressed == true)
        {
            btn1.GetComponent<Image>().sprite = pressedSprite;
            btn2.GetComponent<Image>().sprite = unpressedSprite;
            btn3.GetComponent<Image>().sprite = unpressedSprite;
        }
        else if (btn2Pressed == true)
        {
            btn1.GetComponent<Image>().sprite = unpressedSprite;
            btn2.GetComponent<Image>().sprite = pressedSprite;
            btn3.GetComponent<Image>().sprite = unpressedSprite;
        }
        else if(btn3Pressed == true)
        {
            btn1.GetComponent<Image>().sprite = unpressedSprite;
            btn2.GetComponent<Image>().sprite = unpressedSprite;
            btn3.GetComponent<Image>().sprite = pressedSprite;
        }
    }

    public void Btn1Pressed()
    {
        btn1Pressed = true;
        btn2Pressed = false;
        btn3Pressed = false;
    }

    public void Btn2Pressed()
    {
        btn1Pressed = false;
        btn2Pressed = true;
        btn3Pressed = false;
    }

    public void Btn3Pressed()
    {
        btn1Pressed = false;
        btn2Pressed = false;
        btn3Pressed = true;
    }
}
