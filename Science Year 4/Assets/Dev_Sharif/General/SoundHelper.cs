using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundHelper : MonoBehaviour {
    public SoundData[] clips;
    AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
}