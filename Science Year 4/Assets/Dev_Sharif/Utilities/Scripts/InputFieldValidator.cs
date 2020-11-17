using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class InputFieldValidator : MonoBehaviour
{
    public TMP_InputField inputField;
    public UnityEvent onEmpty;
    public StringEvent onFilled;

    void onEnable() {
        inputField.onValueChanged.AddListener(ValidateInput);
    }

    void OnDisable() {
        inputField.onValueChanged.RemoveListener(ValidateInput);
    }

    public void ValidateInput(string text) {
        if (string.IsNullOrEmpty(text)) {
            onEmpty?.Invoke();
        } else {
            onFilled?.Invoke(text);
        }
    }
}

[System.Serializable]
public class StringEvent : UnityEvent<string> {}
