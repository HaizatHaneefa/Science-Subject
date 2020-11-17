using UnityEngine;
using Lean.Localization;
using NaughtyAttributes;

[System.Serializable]
[CreateAssetMenu (menuName = "Dialog System/Dialog", fileName = "Dialog")]
public class DialogScript : ScriptableObject
{
    public Sprite avatar;
    public string text => GetLocalizedDialogScript().text;
    public AudioClip voiceover => GetLocalizedDialogScript().voiceover;
    [SerializeField] LocalizedDialogScript[] localizations;

    [Header ("Fallback")]
    [TextArea(5,10)]
    [SerializeField] string fallbackText;
    [SerializeField] AudioClip fallbackVoiceover;
    
    [Header ("Next Dialog")]
    public DialogScript next;
    [Space(50f)]
    bool allowClear = true;

    public LocalizedDialogScript GetLocalizedDialogScript() {
        foreach (var locale in localizations) {
            if (locale.language == LeanLocalization.CurrentLanguage) {
                return locale;
            }
        }
        return new LocalizedDialogScript("fallback", fallbackText, fallbackVoiceover); 
    }

    void OnValidate() {
        foreach (var locale in localizations) {
            if (string.IsNullOrEmpty(locale.text) && locale.voiceover) {
                locale.text = locale.voiceover.name;
            }
        }
        if (string.IsNullOrEmpty(fallbackText) && fallbackVoiceover) {
            fallbackText = fallbackVoiceover.name;
        }
    }

    [Button ("Reset Text")]
    void ResetText() {
        if (!allowClear) return;

        foreach (var locale in localizations) {
            locale.text = null;
        }
        fallbackText = null;
        OnValidate();
    }
}

[System.Serializable]
public class LocalizedDialogScript
{
    public string language;
    [TextArea(5,10)]
    public string text;
    public AudioClip voiceover;

    public LocalizedDialogScript(string language, string text, AudioClip voiceover) {
        this.language = language;
        this.text = text;
        this.voiceover = voiceover;
    }
}