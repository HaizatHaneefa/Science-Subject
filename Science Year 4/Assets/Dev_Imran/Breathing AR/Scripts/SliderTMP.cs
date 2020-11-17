using TMPro;
using UnityEngine;

[RequireComponent (typeof (TMP_Text))]
public class SliderTMP : MonoBehaviour
{
    TMP_Text label;

    void Awake() {
        label = GetComponent<TMP_Text>();
    }

    void OnValidate() {
        if (!label) {
            label = GetComponent<TMP_Text>();
        }
    }

    public void ShowPercent(float value) {
        label.text = value.ToString("0%");
    }
}
