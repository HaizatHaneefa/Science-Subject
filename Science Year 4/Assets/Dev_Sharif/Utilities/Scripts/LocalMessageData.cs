using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

[CreateAssetMenu (menuName = "LocalMessage", fileName = "LocalMessageData")]
public class LocalMessageData : ScriptableObject {
    [SerializeField] LocalMessage[] messages;
    public Dictionary<string, Dictionary<string, string>> messageDict;
    string language => LeanLocalization.CurrentLanguage;

    void SetDict() {
        messageDict = new Dictionary<string, Dictionary<string, string>>();
        foreach (var message in messages) {
            Dictionary<string, string> translations = new Dictionary<string, string>();
            foreach (var translation in message.translations) {
                translations.Add(translation.language, translation.translation);
            }
            messageDict.Add(message.original, translations);
        }
    }

    public string GetTranslation(string text) {
        if (messageDict == null) {
            SetDict();
        }
        if (!messageDict.ContainsKey(text)) return text;
        if (!messageDict[text].ContainsKey(language)) return text;
        string translation = messageDict[text][language];
        return string.IsNullOrEmpty(translation) ? text : translation;
    }
}

[System.Serializable]
public class LocalMessage {
    public string original;
    public LocalMessageTranslation[] translations;
}

[System.Serializable]
public class LocalMessageTranslation {
    [LeanLanguageName] public string language;
    public string translation;
}
