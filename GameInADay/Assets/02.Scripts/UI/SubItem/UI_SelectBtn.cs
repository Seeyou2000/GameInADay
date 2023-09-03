using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI_SelectBtn : UI_Base
{
    enum Images
    {
        Btn
    }

    enum Texts
    {
        BtnText
    }

    public Image btn;
    public TextMeshProUGUI btnText;
    
    public override void Init()
    {
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));

        btn = GetImage((int)Images.Btn);
        btnText = GetTextMeshPro((int)Texts.BtnText);
    }

    public void Select()
    {
        btn.color = Color.blue;
        btnText.color = Color.white;
    }

    public void DeSelect()
    {
        btn.color = Color.white;
        btnText.color = Color.black;
    }
}
