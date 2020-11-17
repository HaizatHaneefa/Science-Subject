using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Scanning : MonoBehaviour
{
    public CanvasGroup targetImage;
    public string scanStatement;
    public string targetFound;
    public Renderer cubeRenderer;
    public TextMeshProUGUI scanningText;

    bool isScanning = true;
    bool target = true;
    bool hasBegin = false;

    Coroutine scanningRoutine;
    Coroutine changeTextRoutine;

    void Start() {
        targetImage.alpha = 0f;
    }

    public void StartScanning() {
        hasBegin = true;
        targetImage.DOFade(1f, 0.25f);
    }

    void Update()
    {
        if (!hasBegin) return;

        if (cubeRenderer.enabled) {
            if (!target) {
                return;
            }
            if (changeTextRoutine == null) {
                changeTextRoutine = StartCoroutine(ChangeText());
            }
            target = false;
            isScanning = true;
            return;
        }

        if (!isScanning) {
            return;
        }
        if (scanningRoutine == null) {
            scanningRoutine = StartCoroutine(ScanningForObject());
        }
        isScanning = false;
        target = true;
    }

    IEnumerator ScanningForObject()
    {
        while (!cubeRenderer.enabled) {
            scanningText.text = scanStatement + ".";

            yield return new WaitForSeconds(0.5f);

            scanningText.text = scanStatement + "..";

            yield return new WaitForSeconds(0.5f);

            scanningText.text = scanStatement + "...";

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ChangeText()
    {
        while (cubeRenderer.enabled) {
            scanningText.color = Color.green;
            scanningText.text = targetFound;

            yield return new WaitForSeconds(2f);

            scanningText.gameObject.SetActive(false);
            targetImage.gameObject.SetActive(false);
        }
    }
}
