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

    public long Money;
    public List<Staff> Staffs = new();
    public int ResearchPoint;

    public Simulator Simulator;
    
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        _currentIdols = new List<IdolStat>();
        _tmpIdolStats = new List<IdolStat>();
        Simulator = new(this);
        
        _uiGame = Managers.UI.ShowSceneUI<UI_Game>();
        _uiGame.Init();
        _uiGame.localAuditionBtn.onClick.AddListener(() => { HavingAudition("LocalAudition"); });
        _uiGame.wideAreaAuditionBtn.onClick.AddListener(() => { HavingAudition("WideAreaAudition"); });
        _uiGame.nationalAuditionBtn.onClick.AddListener(() => { HavingAudition("NationalAudition"); });
        _uiGame.PlayBtn.onClick.AddListener(() => Simulator.PlayNormal());
        _uiGame.PauseBtn.onClick.AddListener(() => Simulator.Pause());
        _uiGame.PlayDoubleBtn.onClick.AddListener(() => Simulator.PlayDouble());

        _uiGame.HireStaffBtn.onClick.AddListener(() => {
            _uiGame.UIMainTab.SetContent("스태프 고용", (content) => {
                for (int i = 0; i < 10; i++)
                {
                    var newStaff = GameRandom.Staff();
                    var staffListItem = Managers.UI.MakeSubItem<UI_HireStaffListItem>(content.transform);
                    staffListItem.Init();
                    staffListItem.SetStaff(newStaff);
                    staffListItem.HireBtn.onClick.AddListener(() => {
                        HireStaff(newStaff);
                        Destroy(staffListItem.gameObject);
                    });
                }
            });
        });

        _uiGame.StaffListBtn.onClick.AddListener(() => {
            _uiGame.UIMainTab.SetContent("스태프 목록", (content) => {
                foreach (var staff in Staffs)
                {
                    var staffListItem = Managers.UI.MakeSubItem<UI_StaffListItem>(content.transform);
                    staffListItem.Init();
                    staffListItem.SetStaff(staff);
                }
            });
        });

        _uiGame.FacilityListBtn.onClick.AddListener(() => {
            _uiGame.UIMainTab.SetContent("시설", (content) => {
                for (int i = 1; i < ModelAgencyFacilities.GetSize() + 1; i++)
                {
                    var facilityListItem = Managers.UI.MakeSubItem<UI_FacilityListItem>(content.transform);
                    facilityListItem.Init();
                    facilityListItem.SetFacility(i);

                    facilityListItem.gameObject.BindEvent((evt) => { }, Define.UIEvent.Drag);
                }
            });
        });

        _uiGame.SetMoney(Money);
        _uiGame.SetDate(Simulator.DateString, 0f);
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
            
            foreach(var c in _currentIdols)
                Debug.Log(c.Name);
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
            var tmpIdx = idx;
            
            _uiGame.UIAudition.cards[idx].SetPoint(point);
            _uiGame.UIAudition.cards[idx].gameObject.BindEvent((evt) => { _uiGame.UIAudition.ShowIdol(tmpIdx, _tmpIdolStats[tmpIdx]);});
            _uiGame.UIAudition.cards[idx].passBtn.onClick.AddListener(() =>
            {
                _currentIdols.Add(_tmpIdolStats[tmpIdx]);
                Managers.Resource.Destroy(_uiGame.UIAudition.cards[tmpIdx].gameObject);
                if(tmpIdx == _uiGame.UIAudition.currendIdx)
                    _uiGame.UIAudition.ClosePane();
            });
        }
        _uiGame.UIAudition.statPane.passBtn.onClick.AddListener(() =>
        {
            _uiGame.UIAudition.ClosePane();
            _currentIdols.Add(_tmpIdolStats[_uiGame.UIAudition.currendIdx]);
            Managers.Resource.Destroy(_uiGame.UIAudition.cards[_uiGame.UIAudition.currendIdx].gameObject);
        });
    }

    public void HireStaff(Staff staff)
    {
        Staffs.Add(staff);
        var workJob = new StaffWorkJob(staff);
        workJob.OnEnd = () => {
            ResearchPoint += staff.Grade.ResearchPoint;
        };
        Simulator.AddJob(workJob);

        var payJob = new StaffPayJob(staff);
        payJob.OnEnd = () => {
            Pay(staff.PayPerWeek);
        };
        Simulator.AddJob(payJob);
    }

    public bool Pay(int price)
    {
        if (Money < price) {
            return false;
        }
        Money -= price;
        return true;
    }

    public override void Clear()
    {
        _tmpIdolStats.Clear();
    }

    void FixedUpdate() {
        Simulator.OnFixedUpdate();

        _uiGame.SetMoney(Money);
        _uiGame.SetDate(Simulator.DateString, Simulator.DatePercentage);
    }
}
