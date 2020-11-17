using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    Breathe breathe;
    public GameObject breathingManager;
    public GameObject inhaleButton;
    public GameObject exhaleButton;
    public Sprite inhaleButtonUnpressed;
    public Sprite inhaleButtonPressed;
    public Sprite exhaleButtonUnpressed;
    public Sprite exhaleButtonPressed;

    private void Start()
    {
        breathe = breathingManager.GetComponent<Breathe>();
    }

    public void InhaleButtonSwitch()
    {
        if (breathe.timeForExhale > 0 && breathe.timeForInhale > 0)
        {
            return;
        }
        else
        {
            inhaleButton.GetComponent<Image>().sprite = inhaleButtonPressed;
            exhaleButton.GetComponent<Image>().sprite = exhaleButtonUnpressed;
        }
    }

    public void ExhaleButtonSwitch()
    {
        if (breathe.timeForExhale > 0 && breathe.timeForInhale > 0)
        {
            return;
        }
        else
        {
            inhaleButton.GetComponent<Image>().sprite = inhaleButtonUnpressed;
            exhaleButton.GetComponent<Image>().sprite = exhaleButtonPressed;
        }
    }
}
