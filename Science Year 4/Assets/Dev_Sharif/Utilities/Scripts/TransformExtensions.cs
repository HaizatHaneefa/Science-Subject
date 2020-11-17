using UnityEngine;
using System.Collections.Generic;

namespace CoolCode.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Destroys all children of the Transform
        /// </summary>
        /// <param name="transform"></param>
        /// <returns>Number of destroyed children</returns>
        public static int DestroyChildren(this Transform transform) {
            Transform[] children = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++) {
                children[i] = transform.GetChild(i);
            }
            transform.DetachChildren();
            foreach(var child in children) {
                Object.Destroy(child.gameObject);
            }
            return children.Length;
        }

        public static int DestroyChildren<T>(this Component obj) where T : Component {
            List<T> children = new List<T>(obj.GetComponentsInChildren<T>());
            int count = children.Count;
            while (children.Count > 0) {
                T child = children[0];
                children.RemoveAt(0);
                if (!Application.isPlaying && Application.isEditor) {
                    Object.DestroyImmediate(child.gameObject);
                } else {
                    Object.Destroy(child.gameObject);
                }
            }
            return count;
        }
    }

    
}