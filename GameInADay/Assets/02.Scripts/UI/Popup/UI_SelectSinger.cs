using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UI_SelectSinger : UI_Popup
{
    enum GameObjects
    {
        Content
    }

    public GameObject content;

    public override void Init()
    {
        base.Init();
        if (IsBinded()) return;
        Bind<GameObject>(typeof(GameObjects));
        content = GetObject((int)GameObjects.Content);
    }
}
