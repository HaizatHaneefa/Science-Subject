using UnityEngine;

public class ObjectMessageEnabler : MonoBehaviour
{
    public ObjectMessagePair[] objects;

    public void SetObjectsActive(string message) {
        foreach (var pair in objects) {
            pair.SetActive(message);
        }
    }
}
