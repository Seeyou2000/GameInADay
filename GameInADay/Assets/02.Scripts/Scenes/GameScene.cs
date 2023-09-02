using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{
    private UI_Game _uiGame;
    private List<IdolStat> _currentIdols;
    private List<IdolStat> _tmpIdolStats;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        _currentIdols = new List<IdolStat>();
        _tmpIdolStats = new List<IdolStat>();
        
        _uiGame = Managers.UI.ShowSceneUI<UI_Game>();
        _uiGame.Init();
        _uiGame.localAuditionBtn.onClick.AddListener(() => { HavingAudition("LocalAudition"); });
        _uiGame.wideAreaAuditionBtn.onClick.AddListener(() => { HavingAudition("WideAreaAudition"); });
        _uiGame.nationalAuditionBtn.onClick.AddListener(() => { HavingAudition("NationalAudition"); });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PointerEventData eventData = new(EventSystem.current);
            eventData.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new();
            currentEventSystem.RaycastAll(eventData, raycastResults);
            Debug.Log(raycastResults[0]);
        }
    }

    private void HavingAudition(string auditionType)
    {
        _tmpIdolStats.Clear();
        for(var i = 0; i < Define.MaxAuditionCount; i++)
            _tmpIdolStats.Add(ModelIdol.GenerateIdol(auditionType));
        for (var idx = 0; idx < Define.MaxAuditionCount; idx++)
        {
            var point = _tmpIdolStats[idx].Stats.Sum(x => x.Value.Current) / 8;
            _uiGame.UIAudition.cards[idx].SetPoint(point);
            _uiGame.UIAudition.cards[idx].background.gameObject.BindEvent((evt) => { _uiGame.UIAudition.ShowIdol(_tmpIdolStats[idx]);}, Define.UIEvent.PointerEnter);
        }
    }

    public override void Clear()
    {
        _tmpIdolStats.Clear();
    }
}
