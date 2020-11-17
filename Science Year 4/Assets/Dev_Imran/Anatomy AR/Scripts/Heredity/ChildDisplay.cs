using UnityEngine;

namespace PalReality.Heredity
{
public enum Gender {male, female};

public class ChildDisplay : MonoBehaviour
{

    [Header ("Features")]
    public DisplayFeature hair;
    public DisplayFeature eye;
    public DisplayFeature skin;
}
}
