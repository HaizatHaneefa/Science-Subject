using TMPro;
using DG.Tweening;
using UnityEngine;

[RequireComponent (typeof(TMP_Text))]
public class VersionDisplay : MonoBehaviour
{
    TMP_Text label;

    #if UNITY_ANDROID
    const string platform = "(Android)";
    #elif UNITY_IOS
    const string platform = "(iOS)";
    #else
    const string platform = null;
    #endif

    void Awake()
    {
        label = GetComponent<TMP_Text>();
    }

    void Start()
    {
        label.text = $"v{Application.version} {platform}";
    }

    public void Show(bool status) {
        label.DOFade(status ? 1f : 0f, 0.5f).SetEase(Ease.Linear);
    }

}
