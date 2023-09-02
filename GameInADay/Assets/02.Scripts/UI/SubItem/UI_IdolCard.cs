using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_IdolCard : UI_Base
{
    enum Images
    {
        Background
    }
    enum Texts
    {
        Point, PassBtnText
    }
    
    enum Buttons
    {
        PassBtn
    }

    public Image background;
    public TextMeshProUGUI point, passBtnText;
    public Button passBtn;
    public override void Init()
    {
        if (IsBinded()) return;
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        background = GetImage((int)Images.Background);
        point = GetTextMeshPro((int)Texts.Point);
        passBtnText = GetTextMeshPro((int)Texts.PassBtnText);
        passBtn = GetButton((int)Buttons.PassBtn);

        passBtnText.color = Color.clear;
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.black; },Define.UIEvent.PointerEnter);
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.clear; }, Define.UIEvent.PointerExit);
    }

    public void SetPoint(int value)
    {
        point.text = $"{value}";
    }
}
