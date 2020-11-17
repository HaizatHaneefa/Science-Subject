using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Classroom
{
public class HeaderUI : MonoBehaviour
{
    public static HeaderUI Instance;
    public TextMeshProUGUI nameLabel;
    public Button returnButton;
    public RectTransform playArea;
    [Header("Stars")]
    public HeaderStar starPrefab;
    public Color mutedStarColor;
    public Transform starPanel;
    HorizontalOrVerticalLayoutGroup starPanelLayout;
    int starPanelPadLeft;
    int starPanelPadRight;

    [Header("Audio")]
    public AudioClip starSpawnClip;
    public AudioClip starEarnClip;
    public AudioClip starEarnEndClip;
    public float startPitch = 0.9f;
    public float endPitch = 1.1f;
    [Header("Timings")]
    public float starSpawnDuration = 0.5f;
    public float starInitialDelay = 0f;

    private List<HeaderStar> starList = new List<HeaderStar>();
    private List<HeaderStar> earnedStarList = new List<HeaderStar>();
    public int earnedStarCount => earnedStarList.Count;
    public int fullStarCount => starList.Count;
    public bool isCompleted => earnedStarCount >= fullStarCount;
    
    Canvas canvas;


    void Awake()
    {
        if (!Instance) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
        canvas = GetComponent<Canvas>();
        starPanelLayout = starPanel.GetComponent<HorizontalOrVerticalLayoutGroup>();
        
        starPanelPadLeft = starPanelLayout.padding.left;
        starPanelPadRight = starPanelLayout.padding.right;
        starPanelLayout.padding.left = 0;
        starPanelLayout.padding.right = 0;
    }

    void Start() {
        if (!string.IsNullOrEmpty(GameTitleLinker.gameTitle)) {
            nameLabel.text = GameTitleLinker.gameTitle;
        }
    }

    void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying) {
            return;
        }

        if (Input.GetKeyUp(KeyCode.B)) {
            SpawnStars(10);
        }

        if (Input.GetKeyUp(KeyCode.M)) {
            EarnStar();
        }

        if (Input.GetKeyUp(KeyCode.N)) {
            EarnStar(true);
        }
#endif
    }

    public void SpawnStars(int starCount, bool reverse = false) => SpawnStars(starCount, starSpawnDuration, starInitialDelay, startPitch, endPitch, reverse);
    public void SpawnStars(int starCount, float duration, bool reverse = false) => SpawnStars(starCount, duration, starInitialDelay, startPitch, endPitch, reverse);
    public void SpawnStars(int starCount, float duration, float initialDelay, bool reverse = false) => SpawnStars(starCount, duration, initialDelay, startPitch, endPitch, reverse);
    public void SpawnStars(int starCount, float duration, float initialDelay, float startPitch, float endPitch, bool reverse = false)
    {
        float pitchDelta = (endPitch - startPitch) / (starCount - 1);
        foreach (Transform starChild in starPanel) {
            Destroy(starChild.gameObject);
        }
        if (starCount > 0) {
            starPanelLayout.padding.left = starPanelPadLeft;
            starPanelLayout.padding.right = starPanelPadRight;
        } else {
            starPanelLayout.padding.left = 0;
            starPanelLayout.padding.right = 0;
        }
        earnedStarList = new List<HeaderStar>();
        starList = new List<HeaderStar>();
        for (int i = 0; i < starCount; i++) {
            HeaderStar star = Instantiate(starPrefab, starPanel);
            star.image.color = mutedStarColor;
            star.transform.localScale = Vector3.zero;
            star.layoutGroup.enabled = true;
            star.layoutElement.ignoreLayout = false;
            starList.Add(star);
        }
        for (int i = 0; i < starList.Count; i++) {
            float delay = 0.05f * i;
            float pitch = startPitch + (pitchDelta * i);
            HeaderStar star = reverse ? starList[(starList.Count - 1) - i] : starList[i];
            star.transform
                .DOScale(Vector3.one, duration)
                .OnStart(() => {
                    AudioSource starAudio = star.GetComponent<AudioSource>() ?? star.gameObject.AddComponent<AudioSource>();
                    starAudio.pitch = pitch;
                    starAudio.PlayOneShot(starSpawnClip);
                    star.particle.Play();
                })
                .SetDelay(delay)
                .SetEase(Ease.OutBack);
        }
    }


    public float EarnStar(bool reverse = false, TweenCallback callback = null, float delay = 0)
    {
        if (isCompleted) {
            return 0f;
        }

        int index = reverse ? (starList.Count - 1) - earnedStarList.Count : earnedStarList.Count;
        HeaderStar newStar = Instantiate(starPrefab, playArea.position, Quaternion.identity, starList[index].transform);
        newStar.transform.localScale = Vector3.zero;
        AudioSource newStarAudio = newStar.GetComponent<AudioSource>() ?? newStar.gameObject.AddComponent<AudioSource>();
        Sequence earnSequence = DOTween.Sequence()
            .AppendInterval(delay)
            .AppendCallback(() => {
                newStarAudio.PlayOneShot(starEarnClip);
                newStar.particle.Play();
            })
            .Append(newStar.transform.DOScale(Vector3.one * 5, 1f).SetEase(Ease.OutElastic))
            .Join(newStar.image.rectTransform.DOPunchRotation(Vector3.forward * 7.5f, 1f).SetEase(Ease.OutElastic))
            .Append(newStar.transform.DOMove(starList[index].transform.position, 1f).SetEase(Ease.OutCubic))
            .Join(newStar.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutCubic))
            .AppendCallback(() => {
                newStarAudio.PlayOneShot(starEarnEndClip);
                newStar.particle.Play();
            })
            .AppendInterval(starEarnEndClip.length)
            .AppendCallback(callback);
        earnedStarList.Add(newStar);
        return earnSequence.Duration();
    }
    public float EarnStar(TweenCallback callback) => EarnStar(false, callback);
}
}
