using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVFile<_T>
{
    public int ID;

    protected static Dictionary<int, _T> _map = new();

    protected void Add(_T Sender)
    {
        if (_map.ContainsKey(ID))
        {
            Debug.LogWarning($"Key {ID} is already contained");
        }
        else
        {
            _map.Add(ID, Sender);
        }
    }

    public static _T Get(int key)
    {
        _T ret;
        _map.TryGetValue(key, out ret);

        if (ret == null)
        {
            Debug.Log($"Key { key} is not Contained.");
            Debug.Log($"Map.Count = {_map.Count}");
        }
        return ret;
    }

    public static int GetSize()
    {
        return _map.Count;
    }

    public static _T GetRandom(int startIndex = 1)
    {
        return Get(UnityEngine.Random.Range(startIndex, GetSize()));
    }
}