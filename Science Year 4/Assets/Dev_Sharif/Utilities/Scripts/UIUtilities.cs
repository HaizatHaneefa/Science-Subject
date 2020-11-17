using UnityEngine;

public static class UIUtilities 
{
    public static CanvasGroup Show (this CanvasGroup canvasGroup, bool status = true) {
        canvasGroup.blocksRaycasts = status;
        canvasGroup.interactable = status;
        canvasGroup.alpha = status ? 1f : 0f;
        return canvasGroup;
    }
}
