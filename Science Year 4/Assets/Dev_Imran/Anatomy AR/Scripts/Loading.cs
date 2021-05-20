using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public string loadStatement;
    public TextMeshProUGUI loadingText;
    public AudioSource pop;

    public void LoadLevel (int sceneIndex)
    {
        loadingScreen.SetActive(true);
        pop.Play();
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Menu");

        while (!operation.isDone)
        {
            loadingText.text = loadStatement + ".";

            yield return new WaitForSeconds(0.1f);

            loadingText.text = loadStatement + "..";

            yield return new WaitForSeconds(0.1f);

            loadingText.text = loadStatement + "...";

            yield return new WaitForSeconds(0.1f);
        }
    }
}
