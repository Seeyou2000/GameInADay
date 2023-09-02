using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private Button _button;
    public TextMeshProUGUI ExpandText;

    private enum Texts {
        ExpandText
    }
    
    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));

        _backgroundImage = GetComponent<Image>();
        _button = GetComponent<Button>();

        ExpandText = GetTextMeshPro((int)Texts.ExpandText);
    }
    
    public void Init(int index) {
        Index = index;

        ExpandText.gameObject.SetActive(false);

        _button.gameObject.BindEvent((evt) => {
            if (!IsUnlockable || IsUnlocked) return;
            ExpandText.gameObject.SetActive(true);
        }, Define.UIEvent.PointerEnter);
        _button.gameObject.BindEvent((evt) => {
            if (!IsUnlockable || IsUnlocked) return;
            ExpandText.gameObject.SetActive(false);
        }, Define.UIEvent.PointerExit);
    }

    public void UnlockSelf() {
        if (!IsUnlockable || IsUnlocked) {
            return;
        }
        IsUnlocked = true;
        _backgroundImage.sprite = UnlockedBackgroundSprite;
        ExpandText.gameObject.SetActive(false);
        _button.enabled = false;

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
