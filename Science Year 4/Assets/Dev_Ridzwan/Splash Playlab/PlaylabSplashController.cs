using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlaylabSplashController : MonoBehaviour
{
    public GameObject bigBoysGroup;
    public float DelayTime;
    public string sceneName;

    IEnumerator Start ()
    {
        yield return new WaitForSeconds (0.5f);

        bigBoysGroup.SetActive (true);

        yield return new WaitForSeconds (DelayTime);
        SceneManager.LoadScene(sceneName);
    }

}
