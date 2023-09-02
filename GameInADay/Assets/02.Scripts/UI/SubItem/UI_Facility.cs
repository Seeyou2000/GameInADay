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
                floor.EnableUnlock();
            }
            // HACK
            // floor.GetComponent<RectTransform>().anchoredPosition = new (0, i * image.preferredHeight / 100);
            var i1 = i;
            floor.GetComponent<Button>().onClick.AddListener(() => { Unlock(i1); });
            _facilityFloors.Add(i, floor);
        }

        Unlock(0);
    }
    
    public bool Unlock(int index)
    {
        if(CanUnlock(index))
        {
            _unlockedFacilityIndex.Add(index);
            _facilityFloors[index].UnlockSelf();

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
        var isFirst = _unlockedFacilityIndex.Count == 0;
        var notOpened = !_unlockedFacilityIndex.Contains(index);
        var adjacentFloorOpened = _unlockedFacilityIndex.Contains(index - 1) || _unlockedFacilityIndex.Contains(index + 1);
        return isFirst || (notOpened && adjacentFloorOpened);
    }
}