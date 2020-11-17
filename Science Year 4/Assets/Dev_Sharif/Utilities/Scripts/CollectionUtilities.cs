using System.Collections.Generic;
using UnityEngine;

public static class CollectionUtilities
{
    public static T GetRandom<T> (this T[] array)
    {
        return array.GetRandom(out int index);
    }

    public static T GetRandom<T> (this T[] array, out int index) 
    {
        if (array == null || array.Length <= 0) {
            Debug.LogError($"Array is empty or null!");
            index = -1;
            return default;
        }
        index = Random.Range(0, array.Length);
        return array[index];
    }

    public static T GetRandom<T> (this List<T> list) 
    {
        return list.GetRandom(out int index);
    }

    public static T GetRandom<T> (this List<T> list, out int index)
    {
        if (list == null || list.Count <= 0) {
            Debug.LogError($"List is empty or null");
            index = -1;
            return default;
        }
        index = Random.Range(0, list.Count);
        return list[index];
    }

    public static T PickRandom<T> (this List<T> list)
    {
        return list.PickRandom(out int index);
    }

    public static T PickRandom<T> (this List<T> list, out int index)
    {
        index = Random.Range(0, list.Count);
        return list.Pick(index);
    }

    public static T Pick<T> (this List<T> list, int index)
    {
        T element = list[index];
        list.RemoveAt(index);
        return element;
    }

    public static T[] ExtractRange<T>(this T[] array, int startIndex, int endIndex)
    {
        List<T> list = new List<T>(array);
        list.RemoveRange(endIndex + 1, list.Count - endIndex);
        list.RemoveRange(0, startIndex - 1);
        return list.ToArray();
    }

    public static T[] Shuffle<T>(this T[] array)
    {
        T[] copy = new T[array.Length];
        System.Array.Copy(array, copy, array.Length);
        List<T> list = new List<T>(array);
        for (int i = 0; i < copy.Length; i++) {
            copy[i] = list.PickRandom();
        }
        return copy;
    }

    public static List<T> Shuffle<T>(this List<T> list)
    {
        List<T> copy = new List<T>(list);
        List<T> result = new List<T>();
        while(copy.Count > 0) {
            result.Add(copy.PickRandom());
        }
        return result;
    }

    public static bool HasIndex<T>(this T[] array, int index)
    {
        return index >= 0 && index < array.Length;
    }
}
