using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_IdolCard : UI_Base
{
    enum Texts
    {
        Point, PassBtnText
    }
    
    enum Buttons
    {
        PassBtn
    }
    
    public TextMeshProUGUI point, passBtnText;
    public Button passBtn;
    public override void Init()
    {
        if (point != null) return;
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        
        point = GetTextMeshPro((int)Texts.Point);
        passBtnText = GetTextMeshPro((int)Texts.PassBtnText);
        passBtn = GetButton((int)Buttons.PassBtn);

        passBtnText.color = Color.clear;
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.black; },Define.UIEvent.PointerEnter);
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.clear; }, Define.UIEvent.PointerExit);
    }
}
