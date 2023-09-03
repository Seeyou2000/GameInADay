using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_AppealBox : UI_Base
{
    enum Texts
    {
        PercentageText,TypeText
    }

    public TextMeshProUGUI percentageText, typeText;
    
    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));

        percentageText = GetTextMeshPro((int)Texts.PercentageText);
        typeText = GetTextMeshPro((int)Texts.TypeText);
    }
}
