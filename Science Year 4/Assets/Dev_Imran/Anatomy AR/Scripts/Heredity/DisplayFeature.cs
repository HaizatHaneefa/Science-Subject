using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Lean.Localization;

namespace PalReality.Heredity
{
    public class DisplayFeature : MonoBehaviour {
    public Image background;
    public Image feature;
    public TMP_Text label;
    public CommonFeature male;
    public CommonFeature female;
    [SerializeField] LocalizedFeature[] localizations;
    string language => LeanLocalization.CurrentLanguage;

    public Dictionary<string, LocalizedFeature> localized;

    void Awake() {
        localized = new Dictionary<string, LocalizedFeature>();
        foreach (var localFeature in localizations) {
            localized.Add(localFeature.locale, localFeature);
        }
    }

    public void Set (Gender gender) {
        LocalFeature local;
        CommonFeature common;
        if (gender == Gender.male) {
            local = localized[language].male;
            common = male;
        } else {
            local = localized[language].female;
            common = female;
        }
        
        background.color = common.color;
        label.text = local.relation;
        feature.sprite = common.menuButton.spriteState.pressedSprite;
    }
}

[System.Serializable]
public class LocalizedFeature {
    [LeanLanguageName] public string locale;
    public LocalFeature male;
    public LocalFeature female;
}

[System.Serializable]
public class LocalFeature {
    public string relation;
    public AudioClip audioClip;
}

[System.Serializable]
public class CommonFeature {
    public Color color;
    public Button menuButton;
}
}
