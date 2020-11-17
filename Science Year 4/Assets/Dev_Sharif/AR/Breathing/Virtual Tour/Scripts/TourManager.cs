using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TourManager : MonoBehaviour
{
    public static TourSequence currentSequence = null;
    public TourSequence[] sequences;
    [SerializeField] DefaultTrackableEventHandler trackableEventHandler;
    [SerializeField] ImageTargetBehaviour imageTarget;

    void Awake() {
        trackableEventHandler.enabled = false;
        foreach(var sequence in sequences) {
            sequence.manager = this;
            sequence.gameObject.SetActive(false);
        }
    }

    public void EnableScan(bool enable) {
        trackableEventHandler.enabled = enable;
        imageTarget.enabled = enable;
    }

    public void OnDetect() {
        if (currentSequence == null) {
            currentSequence = sequences[0];
            currentSequence.gameObject.SetActive(true);
            currentSequence.Show();
        }
    }

    public void ChangeSequence(int index) {
        currentSequence?.Hide();
        currentSequence = sequences[index];
        currentSequence.gameObject.SetActive(true);
        currentSequence.Show();
    }

    public void ChangeSequence(TourSequence sequence) {
        currentSequence?.Hide();
        currentSequence = sequence;
        currentSequence.gameObject.SetActive(true);
        currentSequence.Show();
    }
}
