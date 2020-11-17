using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Breathe : MonoBehaviour
{
    float inhaleDurationLimitW;
    float exhaleDurationLimitW;
    float sliderConstant;
    float startTimeForInhale;
    float inhaleDuration;
    float exhaleDuration;

    [HideInInspector]
    public float timeForExhale;
    public float timeForInhale;

    bool inhaleActive = false;
    bool startBreathing = false;

    [Header("Animator")]
    public Animator anim;
    public Animator boyCO2MolAnim;
    public Animator boyO2MolAnim;

    [Header("Skinned Mesh Renderer")]
    public SkinnedMeshRenderer boyMat;

    [Header("Sounds")]
    public AudioSource button;

    [Header("Game Objects")]
    public GameObject boy;

    [Header("Buttons")]
    public Button inhaleButton;
    public Button exhaleButton;

    [Header("Animator")]
    public Animator anim2DChar;

    [Header("Materials")]
    public Material gasMat;

    [Header("Particle Systems")]
    public GameObject O2ParticleEffect;
    public GameObject CO2ParticleEffect;

    [Header("Colors")]
    public Color red;
    public Color blue;

    [Header("Sliders")]
    public GameObject O2Slider;
    public GameObject CO2Slider;
    Slider O2SliderComp;
    Slider CO2SliderComp;

    [Header("Breathing Speed")]
    public float speed;

    [Header("timeForExhale Speed")]
    public float timeForExhaleSpeed;

    [Header("Reverse Script")]
    public ParticleSystemReverseSimulationSuperSimple reverseScript;

    [Header("Panel")]
    public GameObject panel;

    public bool canPlay = true;

    private void Start()
    {
        canPlay = true;
        ChangeState();
        timeForInhale = sliderConstant / 2;
        timeForExhale = sliderConstant / 2;
        inhaleDuration = sliderConstant / 2 / sliderConstant * inhaleDurationLimitW;
        exhaleDuration = sliderConstant / 2 / sliderConstant * exhaleDurationLimitW;
    }

    private void Update()
    {
        SliderWalk();
    }

    public void ChangeState()
    {
        O2SliderComp = O2Slider.GetComponent<Slider>();
        CO2SliderComp = CO2Slider.GetComponent<Slider>();

        sliderConstant = speed;

        inhaleDurationLimitW = sliderConstant;
        exhaleDurationLimitW = sliderConstant;
        startTimeForInhale = sliderConstant;

        reverseScript.startTime = speed;

        O2SliderComp.maxValue = sliderConstant;
        CO2SliderComp.maxValue = sliderConstant;

        anim2DChar.SetTrigger("Walk 1");

        inhaleDuration = 0;
        exhaleDuration = exhaleDurationLimitW;
    }

    void SliderWalk()
    {
        if (timeForExhale > 0 || timeForInhale > 0)
        {
            timeForExhale -= Time.deltaTime / timeForExhaleSpeed;
            timeForInhale -= Time.deltaTime / timeForExhaleSpeed;
        }

        if (inhaleActive)
        {
            if (timeForExhale <= 0)
            {
                if (inhaleDuration < inhaleDurationLimitW)
                {
                    if (startBreathing)
                    {
                        // O2Slider goes up
                        inhaleDuration += Time.deltaTime;
                    }
                }
            }
        }
        else if (!inhaleActive)
        {
            if (timeForExhale > 0)
            {
                //O2Slider goes down when time for exhale
                inhaleDuration = timeForExhale / sliderConstant * inhaleDurationLimitW;
            }

            if (timeForInhale <= 0)
            {
                if (exhaleDuration > 0)
                {
                    if (startBreathing)
                    {
                        //CO2Slider goes down
                        exhaleDuration -= Time.deltaTime;
                    }
                }
                else if (exhaleDuration <= 0)
                {
                    if (startBreathing)
                    {
                        timeForExhale = gameObject.GetComponent<Breathe>().inhaleDuration;
                        timeForInhale = startTimeForInhale;
                        startBreathing = false;
                    }
                }
            }
            else if (timeForInhale > 0)
            {
                //CO2Slider goes up when time for inhale
                exhaleDuration = (-timeForInhale + sliderConstant) / sliderConstant * exhaleDurationLimitW;
            }
        }

        O2SliderComp.value = inhaleDuration / inhaleDurationLimitW * sliderConstant;
        CO2SliderComp.value = exhaleDuration / exhaleDurationLimitW * sliderConstant;
    }

    public void Inhale()
    {
        if (!inhaleActive && canPlay)
        {
            if (timeForExhale <= 0 || timeForInhale <= 0)
            {
                CancelInvoke();
                O2ParticleEffect.SetActive(true);
                CO2ParticleEffect.SetActive(false);
                anim.SetBool("StartBreathing", true);
                gasMat.color = blue;
                startBreathing = true;
                inhaleActive = true;
                button.Play();
                canPlay = false;
                boyO2MolAnim.SetTrigger("FadeIn");
            }
        }
    }

    public void Exhale()
    {
        if (inhaleDuration < inhaleDurationLimitW && !canPlay)
        {
            return;
        }
        else if (inhaleDuration >= inhaleDurationLimitW && canPlay)
        {
            if (inhaleActive)
            {
                if (timeForExhale <= 0 || timeForInhale <= 0)
                {
                    anim.SetTrigger("Exhale");
                    O2ParticleEffect.SetActive(false);
                    CO2ParticleEffect.SetActive(true);
                    boyCO2MolAnim.SetTrigger("FadeIn");
                    Invoke("DisableExhale", 5f);
                    gasMat.color = red;
                    inhaleActive = false;
                    button.Play();
                    canPlay = false;
                }
            }
        }
    }

    void DisableExhale()
    {
        CO2ParticleEffect.SetActive(false);
    }
}
