using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_Facility : UI_Base
{
    public UI_FacilityFloor FloorPrefab;

    // 시작이 0이고 위로 올라가면 +, 아래로 내려가면 -
    private List<int> _unlockedFacilityIndex = new();

    private Dictionary<int, UI_FacilityFloor> _facilityFloors = new();

    public override void Init()
    {
        var image = FloorPrefab.GetComponent<Image>();
        for (int i = -6; i < 6; i++)
        {
            var floor = Managers.UI.MakeSubItem<UI_FacilityFloor>(parent: transform);
            floor.Init();
            floor.Init(i);
            if (i == 0) {
                floor.Unlock();
            }
            // HACK
            floor.GetComponent<RectTransform>().anchoredPosition = new (0, i * image.preferredHeight / 100);
            _facilityFloors.Add(i, floor);
        }
    }
    
    public bool Unlock(int index)
    {
        if (_unlockedFacilityIndex.Contains(index))
        {
            Debug.LogError("이미 열린 층을 다시 열려고 시도함. 이 메시지가 보이지 않아야 함.");
            return false;
        }
        else if(CanUnlock(index))
        {
            _unlockedFacilityIndex.Add(index);
            _facilityFloors[index].Unlock();

            _facilityFloors.TryGetValue(index - 1, out var downFloor);
            if (downFloor != null) {
                downFloor.EnableUnlock();
            }

            _facilityFloors.TryGetValue(index + 1, out var upFloor);
            if (upFloor != null) {
                upFloor.EnableUnlock();
            }
            return true;
        }
        return false;
    }

    public bool CanUnlock(int index)
    {
        return !_unlockedFacilityIndex.Contains(index) && (_unlockedFacilityIndex.Contains(index - 1) || _unlockedFacilityIndex.Contains(index + 1));
    }
}