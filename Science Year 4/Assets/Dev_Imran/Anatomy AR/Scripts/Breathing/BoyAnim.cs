using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyAnim : MonoBehaviour
{
    public AudioSource pop;
    public Breathe breathe;

    [Header("Animators")]
    public Animator boyCO2MolAnim;
    public Animator boyO2MolAnim;

    public Animator anim;
    public Animator boyPivotAnim;
    public Animator lungPivotAnim;
    public Animator tracheaAnim;
    Animator lungAnim;

    public GameObject lungs;
    
    public GameObject O2ParticleEffect;
    public GameObject CO2ParticleEffect;

    public GameObject lungO2ParticleSystems;
    public GameObject lungCO2ParticleSystems;

    // Start is called before the first frame update
    void Start()
    {
        lungAnim = lungs.GetComponent<Animator>();
    }

    public void SwapToLungsBreatheIn()
    {
        lungAnim.SetBool("BreatheIn", true);
    }
    public void SwapToLungsBreatheOut()
    {
        lungAnim.SetBool("BreatheIn", false);
    }

    public void SpawnIn()
    {
        boyPivotAnim.SetTrigger("EnterBoyState");
        pop.Play();
    }

    public void TransitionToLung()
    {
        Invoke("DisableParticleEffect", 1f);
        boyPivotAnim.SetTrigger("ExitBoyState");
        lungPivotAnim.SetTrigger("EnterLungState");
        anim.SetTrigger("FadeOut");
        tracheaAnim.SetTrigger("FadeIn");
        lungAnim.SetTrigger("FadeIn");
        boyO2MolAnim.SetTrigger("FadeOut");
        boyCO2MolAnim.SetTrigger("FadeOut");
    }

    void DisableParticleEffect()
    {
        O2ParticleEffect.SetActive(false);
        CO2ParticleEffect.SetActive(false);
    }

    public void CanPlay()
    {
        breathe.canPlay = true;
    }
}
