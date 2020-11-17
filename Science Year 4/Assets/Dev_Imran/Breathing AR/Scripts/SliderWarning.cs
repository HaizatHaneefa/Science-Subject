using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PalReality.Breathing
{
    public class SliderWarning : MonoBehaviour {
        public Graphic[] graphics;
        [SerializeField] float threshold = 0.5f;
        [SerializeField] bool invertThreshold;
        bool _isOverThreshold;
        bool isOverThreshold {
            set { _isOverThreshold = value; }
            get { return invertThreshold ? !_isOverThreshold : _isOverThreshold; }
        }
        Sequence fade;

        void Start() {
            fade = DOTween.Sequence();
            foreach (var graphic in graphics) {
                fade.Join(graphic.DOFade(1f, 0.5f).OnStart(() => {
                    Color clear = graphic.color;
                    clear.a = 0f;
                    graphic.color = clear;
                }));
            }
            fade.SetLoops(-1, LoopType.Yoyo);
            if (!isOverThreshold) {
                fade.Pause();
            }
        }

        public void CheckValue(float value) {
            isOverThreshold = value > threshold;
            if (isOverThreshold) {
                fade.Play();
            } else {
                fade.Restart();
                fade.Pause();
            }
        }
    }
}
