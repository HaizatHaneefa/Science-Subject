using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungAnim : MonoBehaviour
{
    public GameObject lungO2ParticleSystem;
    public GameObject lungCO2ParticleSystem;
    public GameObject boyPivot;
    public GameObject boy;
    public GameObject lungPivot;

    public Animator tracheaAnim;
    Animator boyPivotAnim;
    Animator boyAnim;
    Animator lungPivotAnim;
    Animator anim;

    public Animator lungO2MolAnim;
    public Animator lungCO2MolAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boyAnim = boy.GetComponent<Animator>();
        boyPivotAnim = boyPivot.GetComponent<Animator>();
        lungPivotAnim = lungPivot.GetComponent<Animator>();
    }

    public void StartIdle()
    {
        boyAnim.SetBool("StartBreathing", false);
    }

    public void BoyExhaleAnim()
    {
        boyAnim.SetTrigger("Exhale");
    }

    public void TransitionToBoy()
    {
        Invoke("DisableParticleEffect", 1f);
        lungPivotAnim.SetTrigger("ExitLungState");
        boyPivotAnim.SetTrigger("EnterBoyState");
        boyAnim.SetTrigger("FadeIn");
        tracheaAnim.SetTrigger("FadeOut");
        anim.SetTrigger("FadeOut");
        lungO2MolAnim.SetTrigger("FadeOut");
        lungCO2MolAnim.SetTrigger("FadeOut");
    }

    void DisableParticleEffect()
    {
        lungO2ParticleSystem.SetActive(false);
        lungCO2ParticleSystem.SetActive(false);
    }

    public void StartInhaling()
    {
        lungO2ParticleSystem.SetActive(true);
        lungO2MolAnim.SetTrigger("FadeIn");
    }

    public void StartExhaling()
    {
        lungCO2ParticleSystem.SetActive(true);
        lungCO2MolAnim.SetTrigger("FadeIn");
    }
}
