using UnityEngine;

public class DestroyUrea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Urea"))
        {
            Destroy(other.gameObject);
        }
    }
}