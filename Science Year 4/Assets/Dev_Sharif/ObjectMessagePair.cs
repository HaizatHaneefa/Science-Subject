using UnityEngine;

[System.Serializable]
public class ObjectMessagePair
{
    public string message;
    public GameObject gameObject;

    public void SetActive(string message)
    {
        gameObject.SetActive(this.message == message);
    }
}