using TMPro;
using UnityEngine.UI;

public class UI_Stat : UI_Base
{
    enum Texts
    {
        Name,Current,Potential
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
        current = GetTextMeshPro((int)Texts.Current);
        potential = GetTextMeshPro((int)Texts.Potential);
    }

    public void SetStat(HumanStat stat)
    {
        current.text = $"{stat.Current}";
        potential.text = $"[{stat.Poten}]";
    }
}
