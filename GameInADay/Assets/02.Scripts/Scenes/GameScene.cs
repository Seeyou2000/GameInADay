using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameScene : BaseScene
{
    private UI_Game _uiGame;
    private IdolStat[] _idolStats;
    
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        
        _uiGame = Managers.UI.ShowSceneUI<UI_Game>();
        _uiGame.Init();
        _uiGame.localAuditionBtn.onClick.AddListener(() =>
        {
            for (var idx = 0; idx < Define.MaxAuditionCount; idx++)
            {
                // _uiGame.UIAudition.cards[idx].SetPoint(_idolStats[idx].Stats.Sum(x => x.Value.Current) / 8);
            }
        });
    }

    public override void Clear()
    {
        
    }
}
