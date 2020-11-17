using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;

public class DialogPopup : MonoBehaviour
{
    public static DialogPopup Instance;
    [SerializeField] Image avatar;
    [SerializeField] TMP_Text label;
    [SerializeField] Image nextIcon;
    [SerializeField] RectTransform panel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float typewriterSpeed = 100f;
    public UnityEvent OnShowBegin;
    public UnityEvent OnShowEnd;
    public UnityEvent OnHideBegin;
    public UnityEvent OnHideEnd;
    public Action<DialogScript> showAction; 
    public Action<DialogScript> showCompleteAction;
    public Action<DialogScript> hideAction;
    public Action<DialogScript> hideCompleteAction;
    CanvasGroup panelGroup;
    Sequence sequence;
    DialogScript nextScript;
    DialogScript script;
    public bool isShowing => panel.anchoredPosition == Vector2.zero && sequence == null;
    Coroutine bgmDucking;
    float bgmDuckVolume = 0.02f;

    void Awake()
    {
        panelGroup = panel.GetComponent<CanvasGroup>();
        panel.anchoredPosition = new Vector2(0f, -250f);
        Instance = this;
    }

    void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }

    void Start()
    {
        nextIcon.rectTransform.localScale = Vector3.zero;
        nextIcon.rectTransform.DOAnchorPosY(40f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutExpo);
        nextIcon.rectTransform.DOPause();
    }

    public void Show(DialogScript script, Action onStart = null, Action onComplete = null, bool isInstant = false)
    {
        if (sequence != null) {
            return;
        }
        
        this.script = script;
        showAction?.Invoke(script);
        onStart?.Invoke();
        OnShowBegin?.Invoke();

        avatar.sprite = script.avatar;
        avatar.rectTransform.localScale = new Vector3(1f, 0.8f, 1f);
        label.pageToDisplay = 1;
        label.text = string.Empty;
        nextScript = script.next;
        nextIcon.rectTransform.localScale = Vector3.zero;
        nextIcon.rectTransform.DOPlay();
        audioSource.clip = script.voiceover;
        
        float typewriterDuration = (float)script.text.Length / typewriterSpeed;

        sequence = DOTween.Sequence().SetDelay(Time.fixedDeltaTime);
        if (panel.anchoredPosition != Vector2.zero) {
            sequence.Append(panel.DOAnchorPosY(0f, 0.25f).SetEase(Ease.OutCubic));
        }
        sequence
        .AppendCallback(() => {
            audioSource.Play();
            if (bgmDucking == null) {
                bgmDucking = StartCoroutine(BGMDuck());
            }
        })
        .Append(avatar.rectTransform.DOScaleY(1f, 0.5f).SetEase(Ease.OutBack))
        // .Join(label.DOTypewriter2(typewriterDuration)).SetEase(Ease.Linear)
        //     .OnStart(() => {
        //         label.text = script.text;
        //         label.maxVisibleCharacters = 0;
        //     })
        .Join(label.DOTypewriter(script.text, typewriterDuration).SetEase(Ease.Linear)
            .OnUpdate(() => {
                if (label.textInfo.pageCount > 1) sequence.Complete();
            })
        )
        .OnComplete(() => {
            // if (!label.text.EndsWith(".") && !label.text.EndsWith("!") && !label.text.EndsWith("?"))
            // {
            //     label.text = $"{label.text}.";
            // }
            nextIcon.rectTransform.DOScale(1f, 0.25f).SetEase(Ease.OutBack).SetDelay(0.25f);
            onComplete?.Invoke();
            OnShowEnd?.Invoke();
            showCompleteAction?.Invoke(script);
        })
        .OnKill(() => sequence = null);

        if (isInstant) {
            sequence.Complete();
        }
    }

    IEnumerator BGMDuck() {
        BGMManager.Instance?.audio.DOComplete();
        yield return null;
        BGMManager.Instance?.audio.DOFade(bgmDuckVolume, 0.3f);
        while (audioSource.isPlaying) {
            yield return null;
        }
        BGMManager.Instance?.audio.DOFade(BGMManager.Instance.otherSceneVolume, 0.3f);
        bgmDucking = null;
    }

    public void Next()
    {
        if (sequence != null) {
            sequence.Complete();
        } else if (label.pageToDisplay < label.textInfo.pageCount) {
            label.pageToDisplay++;
        } else if (nextScript != null) {
            hideAction?.Invoke(script);
            hideCompleteAction?.Invoke(script);
            Show(nextScript);
        } else {
            Hide();
        }
    }

    public void Hide(Action onStart = null, Action onComplete = null, bool isInstant = false)
    {
        if (sequence != null) {
            return;
        }

        hideAction?.Invoke(script);
        onStart?.Invoke();
        OnHideBegin?.Invoke();
        audioSource.Stop();

        sequence = DOTween.Sequence();
        sequence
        .Append(avatar.rectTransform.DOScaleY(0.7f, 0.5f).SetEase(Ease.InBack))
        .Join(panel.DOAnchorPosY(-250f, 0.25f).SetEase(Ease.InBack).SetDelay(0.2f))
        .OnComplete(() => {
            nextIcon.rectTransform.DOPause();
            onComplete?.Invoke();
            OnHideEnd?.Invoke();
            hideCompleteAction?.Invoke(script);
        })
        .OnKill(() => sequence = null);

        if (isInstant) {
            sequence.Complete();
        }
    }

    public void Hide(bool instant) => Hide(isInstant: instant);
}
