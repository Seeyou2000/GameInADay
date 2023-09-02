using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_MainTab : UI_Popup
{
    private enum Texts
    {
        TitleText,
    }

    private enum GameObjects
    {
        Content,
    }

    private GameObject _content;
    private TextMeshProUGUI _titleText;

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));

        _content = GetObject((int)GameObjects.Content);
        _titleText = GetTextMeshPro((int)Texts.TitleText);
    }

    public void SetContent(string title, Action<GameObject> contentSetter) {
        if (_titleText.text == title) {
            // HACK
            Managers.UI.ClosePopupUI(this);
            _titleText.text = "";
            return;
        }
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }
        _titleText.text = title;
        contentSetter.Invoke(_content);
    }
}
