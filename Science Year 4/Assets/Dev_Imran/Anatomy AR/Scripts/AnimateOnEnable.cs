using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnEnable : MonoBehaviour
{
    public Animator anim;
    public GameObject body;
    public GameObject ring;
    public AudioSource beam;
    public AudioSource scan;

    public void StartAnim()
    {
        anim.SetTrigger("Popup");
        scan.Play();
    }

    public void Enable()
    {
        body.SetActive(true);
        ring.SetActive(true);
        beam.Play();
    }

    public void Disable()
    {
        ring.SetActive(false);
    }
}
