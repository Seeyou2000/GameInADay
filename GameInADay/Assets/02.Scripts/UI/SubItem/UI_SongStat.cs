using TMPro;
using UnityEngine.UI;

public class UI_SongStat : UI_Base
{
    enum Texts
    {
        TypeText,PointText
    }

    enum Images
    {
        Fill
    }

    public TextMeshProUGUI typeText, pointText;
    public Image fill;

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        typeText = GetTextMeshPro((int)Texts.TypeText);
        pointText = GetTextMeshPro((int)Texts.PointText);
        fill = GetImage((int)Images.Fill);
    }

    public void SetStat(HumanStat stat)
    {
        pointText.text = $"{stat.Current}";
        fill.fillAmount = (float)stat.Current/100;
    }
}
