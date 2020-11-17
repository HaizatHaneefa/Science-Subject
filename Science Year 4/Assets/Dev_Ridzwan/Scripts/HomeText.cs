using TMPro;
using UnityEngine;

public class HomeText : MonoBehaviour
{
    static string lastText;
    [SerializeField] TMP_Text target;

    void Start() {
        if (string.IsNullOrEmpty(lastText)) return;
        
        target.text = lastText;
    }

    public void CopyText(TMP_Text label) {
        lastText = label.text;
        target.text = label.text;
    }


}
