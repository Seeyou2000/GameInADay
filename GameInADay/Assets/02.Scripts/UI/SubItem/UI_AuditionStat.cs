using TMPro;
using UnityEngine.UI;

public class UI_AuditionStat : UI_Base
{
    enum Texts
    {
        Name,Current,Potential
    }

    enum Images
    {
        Gage,PotentialGage
    }

    public TextMeshProUGUI name,current,potential;
    public Image gage, potentialGage;

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        name = GetTextMeshPro((int)Texts.Name);
        current = GetTextMeshPro((int)Texts.Current);
        potential = GetTextMeshPro((int)Texts.Potential);
        gage = GetImage((int)Images.Gage);
        potentialGage = GetImage((int)Images.PotentialGage);
    }

    public void SetStat(HumanStat stat)
    {
        current.text = $"{stat.Current}";
        potential.text = $"[{stat.Poten}]";
        gage.fillAmount = (float)stat.Current/100;
        potentialGage.fillAmount = (float)stat.Poten/100;
    }
}
