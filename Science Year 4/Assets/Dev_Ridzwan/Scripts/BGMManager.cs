using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class BGMManager : MonoBehaviour {
    public static BGMManager Instance;
    
    [SerializeField, Range(0,1)] float homepageVolume = 1f;
    [SerializeField, Range(0,1)] public float otherSceneVolume = 0.3f;
    [SerializeField] float audioFadeDuration = 1f;
    AudioSource audioSource;
    public new AudioSource audio => audioSource;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable() {
        if (Instance != this) return;
        SceneManager.sceneLoaded += SetVolume;
    }

    void OnDisable() {
        if (Instance != this) return;
        SceneManager.sceneLoaded -= SetVolume;
    }

    IEnumerator Start() {
        audioSource.volume = 0f;
        yield return new WaitForSeconds(3.5f);
        audioSource.Play();
        SetVolume(SceneManager.GetActiveScene());
    }

    void SetVolume(Scene scene, LoadSceneMode mode = LoadSceneMode.Single) {
        if(scene.name == "Homepage") {
            audioSource.DOFade(homepageVolume, audioFadeDuration);
        } else {
            audioSource.DOFade(otherSceneVolume, audioFadeDuration);
        }
    }
}