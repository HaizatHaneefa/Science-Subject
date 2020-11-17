using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class GameTitleLinker : MonoBehaviour
{
    public static string gameTitle;
    
    [SerializeField] TMP_Text label;
    Button button;

    void Awake() {
        button = GetComponent<Button>();
        if (!label) {
            label = GetComponentInChildren<TMP_Text>();
        }

        button.onClick.AddListener(delegate {
            gameTitle = label.text;
        });
    }
}