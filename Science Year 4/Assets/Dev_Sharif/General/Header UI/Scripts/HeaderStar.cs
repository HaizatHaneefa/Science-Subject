using UnityEngine;
using UnityEngine.UI;

namespace Classroom
{
    public class HeaderStar : MonoBehaviour
{
    public Image image {private set; get;}
    public ParticleSystem particle {private set; get;}
    public LayoutGroup layoutGroup {private set; get;}
    public LayoutElement layoutElement {private set; get;}

    void Awake() {
        image = GetComponentInChildren<Image>();
        particle = GetComponentInChildren<ParticleSystem>();
        layoutGroup = GetComponent<LayoutGroup>();
        layoutElement = GetComponent<LayoutElement>();
    }
}
}
