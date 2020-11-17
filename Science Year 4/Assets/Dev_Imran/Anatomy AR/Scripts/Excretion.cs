using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using Vuforia;
namespace PalReality.Excretion {
public class Excretion : MonoBehaviour
{

    [Header("Animation")]
    public Animator skinAnim;
    public Animator kidneyAnim;
    public Animator lungAnim;

    [Header("Sounds")]
    public AudioSource button;

    [Header("Models")]
    public GameObject body;
    public GameObject kidneyModel;
    public GameObject skinModel;
    public GameObject lungModel;
    public GameObject manModel;

    [Header("Button")]
    public GameObject skinButton;
    public GameObject lungButton;
    public GameObject kidneyButton;
    public GameObject skinCloseButton;
    public GameObject lungCloseButton;
    public GameObject kidneyCloseButton;

    [Header("Organ Labels")]
    public RectTransform lungLabel;
    public RectTransform skinLabel;
    public RectTransform kidneyLabel;

    public List<UILineRenderer> labelLineRender;
    //public ImageTargetBehaviour imageTargetBehaviour;
    public GameObject imgTargetObj;

    bool isViewBody = true;

    void Awake()
    {
        lungLabel.localScale = Vector2.zero;
        skinLabel.localScale = Vector2.zero;
        kidneyLabel.localScale = Vector2.zero;
    }

    void Start()
    {
        lungCloseButton.SetActive(false);
        skinCloseButton.SetActive(false);
        kidneyCloseButton.SetActive(false);
        skinButton.SetActive(true);
        lungButton.SetActive(true);
        kidneyButton.SetActive(true);

        skinModel.SetActive(false);
        kidneyModel.SetActive(false);
        lungAnim.SetBool("isBreathing", false);

        isViewBody = true;

        //imageTargetBehaviour.enabled = false;
        //imgTargetObj.SetActive(false);
    }

    public void ShowOrganLabels()
    {
        if(isViewBody)
        {
            lungLabel.localScale = Vector2.one;
            skinLabel.localScale = Vector2.one;
            kidneyLabel.localScale = Vector2.one;

            foreach(UILineRenderer uiL in labelLineRender)
            {
                uiL.enabled = true;
            }
        }
    }
    public void HideOrganLabels()
    {
        lungLabel.localScale = Vector2.zero;
        skinLabel.localScale = Vector2.zero;
        kidneyLabel.localScale = Vector2.zero;

        foreach(UILineRenderer uiL in labelLineRender)
        {
            uiL.enabled = false;
        }
    }

    public void StartLungAnim()
    {
        isViewBody = false;
        //hide unrelated UI
        skinButton.SetActive(false);
        lungButton.SetActive(false);
        kidneyButton.SetActive(false);

        manModel.SetActive(false);
        HideOrganLabels();

        //show related UI
        lungCloseButton.SetActive(true);

        //begin callbacks
        lungModel.SetActive(true);
        //lungAnim.SetBool("isBreathing", true);
        // button.Play();
    }

    public void StartKidneyAnim()
    {
        isViewBody = false;
        //hide unrelated UI
        skinButton.SetActive(false);
        lungButton.SetActive(false);
        kidneyButton.SetActive(false);

        HideOrganLabels();
        manModel.SetActive(false);

        //show related UI
        kidneyCloseButton.SetActive(true);
        kidneyModel.SetActive(true);

        //begin callbacks
        kidneyAnim.SetTrigger("Excretion");
        //button.Play();
    }

    public void StartSkinAnim()
    {
        isViewBody = false;
        //hide unrelated UI
        skinButton.SetActive(false);
        lungButton.SetActive(false);
        kidneyButton.SetActive(false);

        HideOrganLabels();
        manModel.SetActive(false);

        //show related UI
        skinCloseButton.SetActive(true);
        skinModel.SetActive(true);

        //begin callbacks
        skinAnim.SetTrigger("Excretion");
        button.Play();
    }

    public void CloseAnim()
    {
        isViewBody = true;
        manModel.SetActive(true);
        lungCloseButton.SetActive(false);
        skinCloseButton.SetActive(false);
        kidneyCloseButton.SetActive(false);
        skinButton.SetActive(true);
        lungButton.SetActive(true);
        kidneyButton.SetActive(true);

        ShowOrganLabels();

        lungModel.SetActive(false);
        skinModel.SetActive(false);
        kidneyModel.SetActive(false);
        lungAnim.SetBool("isBreathing", false);
        button.Play();
    }

    public void DisableImageTarget()
    {
        imgTargetObj.SetActive(false);
    }
    public void EnableImageTarget()
    {
        //imageTargetBehaviour.enabled = true;
        imgTargetObj.SetActive(true);
    }
}
}
