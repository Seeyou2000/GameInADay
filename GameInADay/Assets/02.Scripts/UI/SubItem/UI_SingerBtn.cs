using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI_SingerBtn : UI_Base
{
    enum Buttons
    {
        UI_SingerBtn
    }

    enum Texts
    {
        BtnText
    }

    public int idolIdx;
    public Button btn;
    public TextMeshProUGUI btnText;
    
    public override void Init()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        btn = GetButton((int)Buttons.UI_SingerBtn);
        btnText = GetTextMeshPro((int)Texts.BtnText);
    }
}
