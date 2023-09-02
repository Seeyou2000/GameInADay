using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stat : UI_Base
{
    enum Texts
    {
        Name,Point,Potential
    }

    enum Images
    {
        Gage
    }

    public TextMeshProUGUI name, point, potnential;

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        name = GetTextMeshPro((int)Texts.Name);
        point = GetTextMeshPro((int)Texts.Point);
        potnential = GetTextMeshPro((int)Texts.Potential);
    }
}
