using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public static class GameObjectExtension
{
	public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
	{
		return Util.GetOrAddComponent<T>(go);
	}

	public static void BindEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
	{
		UI_Base.BindEvent(go, action, type);
	}

	public static bool IsValid(this GameObject go)
	{
		return go != null && go.activeSelf;
	}
}

public static class DictionaryExtension {
    public static string GetString<K, V>(this Dictionary<K, V> self) {
        var items = self.Select(kvp => kvp.ToString());
        return string.Join(", ", items);
    }
}