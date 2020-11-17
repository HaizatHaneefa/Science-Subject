using TMPro;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening
{
    public static class TMProTweenExtensions {
    public static TweenerCore<string, string, StringOptions> DOTypewriter(this TMP_Text TMPtext, string text, float duration) 
    {
        bool isTagging = false;
        return DOTween.To(
            () => TMPtext.text,
            (string x) => {
                if (!isTagging) {
                    isTagging = x.EndsWith("<");
                } else {
                    isTagging = !x.EndsWith(">");
                }

                if (!isTagging) TMPtext.text = x;
            },
            text,
            duration
        );
    }

    public static TweenerCore<int, int, NoOptions> DOTypewriter2(this TMP_Text label, float duration)
    {
        return DOTween.To(
            () => label.maxVisibleCharacters,
            (int x) => label.maxVisibleCharacters = x,
            label.text.Length,
            duration
        );
    }
}
}