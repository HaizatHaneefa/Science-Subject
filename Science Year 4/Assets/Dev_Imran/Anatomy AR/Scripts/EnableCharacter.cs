using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCharacter : MonoBehaviour
{
    public Animator womanAnim;
    public Animator manAnim;
    public AudioSource pop;

    public void StartAnim()
    {
        womanAnim.SetTrigger("Popup");
        manAnim.SetTrigger("Popup");
        pop.Play();
    }
}
