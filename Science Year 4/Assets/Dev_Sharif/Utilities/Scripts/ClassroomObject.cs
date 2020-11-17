using UnityEngine;

namespace Classroom {
public class ClassroomObject : MonoBehaviour
{
    public static string identifier {get;} = "com.coolcode.classroom";
    
    void Awake() {
        gameObject.SetActive(Application.identifier == identifier);
    }
}
}
