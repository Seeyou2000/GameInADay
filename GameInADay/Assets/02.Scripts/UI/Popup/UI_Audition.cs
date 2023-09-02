using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Audition : UI_Popup
{
    private enum Buttons
    {
        NextBtn,
        RedoBtn,
        GatchaBtn
    }

    private enum Texts
    {
        Name, Age
    }
    
    enum GameObjects
    {
        StatGrid,
    }

    private const int StatMax = 8;
    private UI_Stat[] stats;
    public GameObject statGrid;
    public Button nextBtn,redoBtn;
    public TextMeshProUGUI name, age;

    public override void Init()
    {
        base.Init();

        if (nextBtn != null) return;
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        statGrid = GetObject((int)GameObjects.StatGrid);
        var statsLength = System.Enum.GetValues(typeof(IdolStatType)).Length;
        stats = new UI_Stat[statsLength];
        for (var i = 0; i < statsLength; i++)
        {
            stats[i] = Managers.UI.MakeSubItem<UI_Stat>(parent: statGrid.transform);
        }
        
        nextBtn = GetButton((int)Buttons.NextBtn);
        redoBtn = GetButton((int)Buttons.RedoBtn);
        name = GetTextMeshPro((int)Texts.Name);
        age = GetTextMeshPro((int)Texts.Age);
        GetButton((int)Buttons.GatchaBtn).onClick.AddListener(Gatcha);
    }

    public void Gatcha()
    {
        TableManager.Load();
        var idol = ModelIdol.GenerateIdol();
        name.text = idol.Name;
        foreach (var i in System.Enum.GetValues(typeof(IdolStatType)))
        {
            var index = (int)i - 1;
            stats[index].name.text = System.Enum.GetName(typeof(IdolStatType), i);
            stats[index].SetStat(idol.Stats[(IdolStatType)i]);
        }
    }
}
