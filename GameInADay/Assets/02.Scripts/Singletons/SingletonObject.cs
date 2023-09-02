using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObject<T> : MonoBehaviour where T : SingletonObject<T>
{
    static T _instance;

    public static T Instance
    {
        get 
        { 
            if(_instance == null)
            {
                // 이미 생성되있는 오브젝트가 있나 찾아본다
                _instance = FindObjectOfType<T>();

#if UNITY_EDITOR
                if (!Application.isPlaying)
                    return _instance;
#endif
                // 아직도 없으면 하나 만들어준다
                if(null == _instance)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }

                DontDestroyOnLoad(_instance);
            }
            return _instance; 
        }
    }

    public static bool IsAlive
    {
        get { return _instance != null; }
    }
}
