using Skibitsky.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHelper : MonoBehaviour
{
    public SceneReference sceneToLoad;
    string activeScene => SceneManager.GetActiveScene().name;

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene() {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadScene(SceneReference scene) {
        SceneManager.LoadScene(scene);
    }

    public AsyncOperation LoadSceneASync(string sceneName) {
        return SceneManager.LoadSceneAsync(sceneName);
    }

    public AsyncOperation LoadSceneASync(int sceneIndex) {
        return SceneManager.LoadSceneAsync(sceneIndex);
    }

    public AsyncOperation LoadSceneASync() {
        return SceneManager.LoadSceneAsync(sceneToLoad);
    }
    public AsyncOperation LoadSceneASync(SceneReference scene) {
        return SceneManager.LoadSceneAsync(scene);
    }

    public void ReloadScene() {
        LoadScene(activeScene);
    }

    public void ReloadSceneAsync() {
        LoadSceneASync(activeScene);
    }
}
