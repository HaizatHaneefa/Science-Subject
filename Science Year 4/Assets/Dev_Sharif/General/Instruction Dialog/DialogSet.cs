using System;
using System.Collections;
using MyBox;
using UnityEngine;

public class DialogSet : MonoBehaviour
{
    [SerializeField] DialogPopup popup;
    [SerializeField] int showOnStart = -1;
    [SerializeField] float startDelay = 1f;
    [Header("Dialog Scripts")]
    [DisplayInspector, SerializeField] DialogScript[] scripts;

    IEnumerator Start() {
        if (!popup) popup = DialogPopup.Instance;

        yield return new WaitForSeconds(startDelay);
        if (showOnStart >= 0) {
            Show(showOnStart);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Show")]
    void ShowInEditor()
    {
        Show(0);
    }
#endif

    public void Show(int index, Action onStart = null, Action onComplete = null, bool instant = false)
    {
        if (scripts == null || scripts.Length == 0 || !scripts.HasIndex(index)) {
            Debug.LogError("Invalid script index", gameObject);
            return;
        }
        popup.Show(scripts[index], onStart, onComplete, instant);
    }

    public void Show(int index) {
        Show(index, null, null, false);
    }
}
