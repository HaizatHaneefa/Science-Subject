using DG.Tweening;
using UnityEngine;
using TMPro;

public class LoginError : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] LocalMessageData localization;
    public StringEvent onShow;


    public void Show(string message)
    {
        if (string.IsNullOrEmpty(message)) {
            return;
        }
        Debug.Log(message, gameObject);
        label.text = localization.GetTranslation(message);
        onShow?.Invoke(message);
        canvasGroup.DOFade(1f, 0.5f);
        canvasGroup.blocksRaycasts = true;
    }
}