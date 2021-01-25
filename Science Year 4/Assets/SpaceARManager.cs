using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceARManager : MonoBehaviour
{
    [SerializeField] private string[] dialogue, subtopicString;
    [SerializeField] private TextMeshProUGUI subtopicText, dialogueText;

    [SerializeField] private Image showImage;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] clip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        dialogue = new string[4];
        dialogue[0] = "These lines are called parallel lines because they will not intersect of meet even if extended."; // parallel
        dialogue[1] = "These lines intersect and form an upright angle. Hence, they are called perpendicular lines."; // tahu dah kan?
        dialogue[2] = "Protractor is used to measure angles and the unit for angles is degree(°)";
        dialogue[3] = "Example: 50° is read as 50 degrees, 180° is read as 180 degrees";

    }


    public void _Next()
    {
        // goes through the next stage of the scene
    }

    public void _Previous()
    { 
        // goes back to the previous stuff
    }

    public void _TriangleButtons(int index)
    {
        if (index == 0)
        {
            // sonething happens here
        }
        else if (index == 1)
        {
            // sonething happens here
        }
        else if (index == 2)
        {
            // sonething happens here
        }
    }

    public void PressSFX() // button press yes
    {
        aSource.clip = clip[0];
        aSource.Play();
    }

    public void WrongPressSFX() // button press no
    {
        aSource.clip = clip[4];
        aSource.Play();
    }

    public void BackSFX() // back button press
    {
        aSource.clip = clip[1];
        aSource.Play();
    }

    public void RightSFX() // right answer
    {
        aSource.clip = clip[2];
        aSource.Play();
    }

    public void WrongSFX() // wrong answer
    {
        aSource.clip = clip[3];
        aSource.Play();
    }

    //void Update()
    //{
    //    // 3d model manipulation stuff goes here i suppose
    //}
}
