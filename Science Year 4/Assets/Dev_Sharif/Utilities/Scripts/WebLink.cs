using UnityEngine;

public class WebLink : MonoBehaviour
{
    public void OpenURL(string url) {
        Application.OpenURL(url);
    }
}
