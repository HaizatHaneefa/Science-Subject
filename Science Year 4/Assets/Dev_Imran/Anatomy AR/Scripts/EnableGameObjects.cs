using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjects : MonoBehaviour
{
    public Animator anim;
    public Animator lungAnim;
    public AudioSource scan;

    public void StartAnim()
    {
        anim.SetTrigger("Popup");
        lungAnim.SetTrigger("Popup");
        scan.Play();
    }
}
