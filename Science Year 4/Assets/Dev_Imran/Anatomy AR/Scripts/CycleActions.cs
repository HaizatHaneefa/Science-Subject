using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class CycleActions : MonoBehaviour
{
    [SerializeField] ButtonSet[] sets;
    public int index {private set; get;} = 0;
    public ButtonSet currentSet => sets[index];
    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void OnEnable()
    {
        button.onClick.AddListener(Cycle);
    }

    void OnDisable()
    {
        button.onClick.RemoveListener(Cycle);
    }

    void OnValidate()
    {
        if (sets.Length == 0) {
            return;
        }
        if (!button) {
            button = GetComponent<Button>();
        }
        button.transition = Selectable.Transition.SpriteSwap;
        button.image.sprite = currentSet.unpressedSprite;
        button.spriteState = currentSet.spriteState;
    }

    public void Cycle()
    {
        index = (int)Mathf.Repeat(index + 1, sets.Length);

        button.image.sprite = currentSet.unpressedSprite;
        button.spriteState = currentSet.spriteState;

        currentSet.action?.Invoke();
    }
}

[System.Serializable]
public class ButtonSet
{
    public string name;
    public Sprite unpressedSprite;
    public SpriteState spriteState;
    public UnityEvent action;
}
