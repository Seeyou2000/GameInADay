using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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

    public TextMeshProUGUI name;
    public TextMeshProUGUI current;
    public TextMeshProUGUI potential;

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        name = GetTextMeshPro((int)Texts.Name);
        current = GetTextMeshPro((int)Texts.Point);
        potential = GetTextMeshPro((int)Texts.Potential);
    }

    public void SetStat(HumanStat stat)
    {
        current.text = $"{stat.Current}";
        potential.text = $"{stat.Poten}";
    }
}
