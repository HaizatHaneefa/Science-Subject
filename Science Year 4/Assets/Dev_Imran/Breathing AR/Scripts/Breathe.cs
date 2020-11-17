using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PalReality.Breathing
{
    public abstract class Breathe : MonoBehaviour
{
    public float oxygenIn;
    public float carbonDioxideOut;
    public float duration = 2f;
    public string animationState;
    
    public Button button;
    public BreatheEvent onBreathe;


    void Awake()
    {        
        button = GetComponent<Button>();
    }

    void Start() {
        button.onClick.AddListener(BreatheAction);
    }

    public Breathe(float oxygenIn, float carbonDioxideOut, float duration, string animationState) {
        this.oxygenIn = oxygenIn;
        this.carbonDioxideOut = carbonDioxideOut;
        this.duration = duration;
        this.animationState = animationState;
    }

    public void BreatheAction() {
        onBreathe?.Invoke(this);
    }
}

[System.Serializable]
public class BreatheEvent : UnityEvent<Breathe> {}
}
