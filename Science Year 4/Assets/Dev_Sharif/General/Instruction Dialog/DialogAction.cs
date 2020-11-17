using System;
using MyBox;
using UnityEngine;
using UnityEngine.Events;

public class DialogAction : MonoBehaviour
{
    DialogPopup popup = DialogPopup.Instance;
    [DisplayInspector] public DialogScript script;
    public UnityEvent onShowBegin;
    public UnityEvent onShowEnd;
    public UnityEvent onHideBegin;
    public UnityEvent onHideEnd;

    void OnEnable()
    {
        if (!popup) {
            popup = DialogPopup.Instance ?? GameObject.FindObjectOfType<DialogPopup>();
            if (!popup) return;
        }
        
        popup.showAction += ShowAction;
        popup.showCompleteAction += ShowCompleteAction;
        popup.hideAction += HideAction;
        popup.hideCompleteAction += HideCompleteAction;
    }

    void OnDisable()
    {
        if (!popup) return;

        popup.showAction -= ShowAction;
        popup.showCompleteAction -= ShowCompleteAction;
        popup.hideAction -= HideAction;
        popup.hideCompleteAction -= HideCompleteAction;
    }

    void ShowAction(DialogScript script)
    {
        if (this.script != script) return;
        onShowBegin?.Invoke();
    }

    void ShowCompleteAction(DialogScript script)
    {
        if (this.script != script) return;
        onShowEnd?.Invoke();
    }

    void HideAction(DialogScript script)
    {
        if (this.script != script) return;
        onHideBegin?.Invoke();
    }

    void HideCompleteAction(DialogScript script)
    {
        if (this.script != script) return;
        onHideEnd?.Invoke();
    }
}
