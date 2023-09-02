using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Lobby;

        var ui = Managers.UI.ShowSceneUI<UI_Lobby>();
    }

    private void Start()
    {
        // throw new NotImplementedException();
    }

    public override void Clear()
    {
        
    }
}
