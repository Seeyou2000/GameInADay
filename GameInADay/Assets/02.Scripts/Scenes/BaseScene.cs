using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;
    public EventSystem currentEventSystem;

	void Awake()
	{
		Init();
	}

	protected virtual void Init()
    {
        EventSystem obj = GameObject.FindObjectOfType<EventSystem>();
        if (obj == null)
        {
	        obj = Managers.Resource.Instantiate("UI/EventSystem").GetComponent<EventSystem>();
	        obj.name = "@EventSystem";
        }
        currentEventSystem = obj;
    }

    public abstract void Clear();
}
