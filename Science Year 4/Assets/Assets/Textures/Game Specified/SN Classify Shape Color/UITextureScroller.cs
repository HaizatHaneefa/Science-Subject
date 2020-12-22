using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextureScroller : MonoBehaviour
{
    [SerializeField] Vector2 speed;
    public bool isScrolling = true;
    [SerializeField] Material material;

    // Update is called once per frame
    void Update()
    {
        if (!isScrolling) return;
        Vector2 offset = material.GetTextureOffset("_MainTex");
        offset += speed * Time.deltaTime;
        offset = new Vector2(Mathf.Repeat(offset.x, 1), Mathf.Repeat(offset.y, 1));
        material.SetTextureOffset("_MainTex", offset);
    }
}
