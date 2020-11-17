using UnityEngine.UI;

namespace DG.Tweening
{
    public static class LayoutGroupExtensions {
        /// <summary>
        /// Tweens the spacing to the given value using default plugins
        /// </summary>
        public static Core.TweenerCore<float, float, Plugins.Options.FloatOptions> DOSpace (this HorizontalOrVerticalLayoutGroup layoutGroup, float endValue, float duration) {
            return DOTween.To (() => layoutGroup.spacing, x => layoutGroup.spacing = x, endValue, duration);
        }
    }
}