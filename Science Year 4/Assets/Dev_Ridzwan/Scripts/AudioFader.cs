using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioFader : MonoBehaviour
{
    //coding ini tangkap muat aja
    public AudioSource audioSource;
    public float targetVolume;
    void Awake()
    {
        StartCoroutine(FadeIn(audioSource,5.5f));
    }

    void Start()
    {
        audioSource.Play();
    }

    // public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
    //     float startVolume = audioSource.volume;
    //     while (audioSource.volume > 0) {
    //         audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
    //         yield return null;
    //     }
    //     audioSource.Stop();
    // }
    IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        if (!audioSource) yield break;
        
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < targetVolume) {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}