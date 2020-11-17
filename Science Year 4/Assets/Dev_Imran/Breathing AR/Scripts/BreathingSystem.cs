using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PalReality.Breathing
{
public class BreathingSystem : MonoBehaviour
{
    [SerializeField] float conversionRate = 0.05f;
    [SerializeField] float highCoversion = 0.125f;
    [SerializeField] float lowConversion = 0.025f;
    [SerializeField] Slider oxygen;
    [SerializeField] Slider carbonDioxide;
    [SerializeField] Breathe inhale;
    [SerializeField] Breathe exhale;
    bool isRespiring = false;
    int cyclesPerMin = 0;
    [SerializeField] TMP_Text rateLabel;
    float lastTime = 0f;
    Queue<float> cycleDurations = new Queue<float>();

    void Start()
    {
        inhale.button.interactable = true;
        exhale.button.interactable = false;
    }

    void Update()
    {
        if (oxygen.value > 0 && carbonDioxide.value < 1) {
            oxygen.value -= conversionRate * Time.deltaTime;
            carbonDioxide.value += conversionRate * Time.deltaTime;
        }
    }

    public void Respire(Breathe breathe)
    {
        if (isRespiring) {
            return;
        }
        StartCoroutine(RespireRoutine(breathe));
    }

    IEnumerator RespireRoutine(Breathe breathe)
    {
        isRespiring = true;
        inhale.button.interactable = false;
        exhale.button.interactable = false;

        if (lastTime == 0) {
            lastTime = Time.time;
        }

        float o2Rate = breathe.oxygenIn / breathe.duration;
        float co2Rate = breathe.carbonDioxideOut / breathe.duration;
        float duration = breathe.duration;

        while (duration > 0) {
            oxygen.value += o2Rate * Time.deltaTime;
            carbonDioxide.value -= co2Rate * Time.deltaTime;
            duration -= Time.deltaTime;
            yield return null;
        }

        if (breathe == inhale) {
            exhale.button.interactable = true;
        } else if (breathe == exhale) {
            inhale.button.interactable = true;
            StartCoroutine(AddCycle());
            // StartCoroutine(AddRate());
        }

        isRespiring = false;
    }

    IEnumerator AddCycle()
    {
        cyclesPerMin++;
        rateLabel.text = $"{cyclesPerMin}x";
        yield return new WaitForSeconds(60f);
        cyclesPerMin = Mathf.Max(0, --cyclesPerMin);
        rateLabel.text = $"{cyclesPerMin}x";
    }

    IEnumerator AddRate()
    {
        float newCycleDuration = Time.time - lastTime;
        lastTime = Time.time;

        cycleDurations.Enqueue(newCycleDuration);
        while (cycleDurations.Count > 5) {
            cycleDurations.Dequeue();
        }
        ShowRate();

        yield return new WaitForSeconds(60f);
        cycleDurations.Dequeue();
        ShowRate();
    }

    void ShowRate()
    {
        float rateSum = 0f;
        foreach (var cycle in cycleDurations) {
            rateSum += cycle;
        }
        float average = rateSum / cycleDurations.Count;
        rateLabel.text = $"{(60f / average).ToString("0.0")}x";
    }

    public void SetConversionRate(float rate) => conversionRate = rate;
    public void SetHigh() => conversionRate = highCoversion;
    public void SetLow() => conversionRate = lowConversion;
}
}
