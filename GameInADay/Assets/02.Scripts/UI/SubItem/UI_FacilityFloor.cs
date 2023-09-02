using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FacilityFloor : UI_Base
{
    public static readonly float Gap = 15f;
    public bool IsUnlocked = false;
    public bool IsUnlockable = false;
    public int Index;

    public Image EmptyRoomPrefab;
    public Sprite UnlockedBackgroundSprite;

    private Image _backgroundImage;
    
    public override void Init()
    {
        _backgroundImage = GetComponent<Image>();
    }
    
    public void Init(int index) {
        Index = index;
    }

    public void Unlock() {
        if (IsUnlocked) {
            return;
        }
        IsUnlocked = true;
        _backgroundImage.sprite = UnlockedBackgroundSprite;

        var emptyRoomImageWidth = EmptyRoomPrefab.GetComponent<Image>().sprite.bounds.size.x * 100;

        for (int i = 0; i < Define.RoomCount; i++)
        {
            var emptyRoomObject = Managers.UI.MakeSubItem<UI_EmptyRoom>(parent: transform).GetComponent<Image>();
            emptyRoomObject.rectTransform.anchoredPosition = new(Gap + i * (emptyRoomImageWidth + Gap), 10);
        }
    }

    public void EnableUnlock() {
        IsUnlockable = true;
    }
}
