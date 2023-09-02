using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Audition : UI_Popup
{
    private enum Buttons
    {
        FinishBtn,
        RedoBtn,
        GatchaBtn,
        PassBtn
    }

    private enum Texts
    {
        Name, Age, PassBtnText
    }
    
    enum GameObjects
    {
        StatGrid,
    }

    private const int StatMax = 8;
    private UI_Stat[] stats;
    public GameObject statGrid;
    public Button finishBtn,redoBtn, passBtn;
    public TextMeshProUGUI name, age, passBtnText;
    private Dictionary<int, string> IntToName = new(){{0,"귀여움"}, {1,"쿨"}, {2,"섹시"}, {3,"아름다움"}, {4,"보컬"}, {5,"댄스"}, {6,"유머"}, {7,"지성"}};

    public override void Init()
    {
        base.Init();
        
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        statGrid = GetObject((int)GameObjects.StatGrid);
        var statsLength = System.Enum.GetValues(typeof(IdolStatType)).Length;
        stats = new UI_Stat[statsLength];
        for (var i = 0; i < statsLength; i++)
        {
            stats[i] = Managers.UI.MakeSubItem<UI_Stat>(parent: statGrid.transform);
            stats[i].Init();
            stats[i].name.text = IntToName[i];
        }
        
        finishBtn = GetButton((int)Buttons.FinishBtn);
        redoBtn = GetButton((int)Buttons.RedoBtn);
        passBtn = GetButton((int)Buttons.PassBtn);
        name = GetTextMeshPro((int)Texts.Name);
        age = GetTextMeshPro((int)Texts.Age);
        passBtnText = GetTextMeshPro((int)Texts.PassBtnText);
        GetButton((int)Buttons.GatchaBtn).onClick.AddListener(Gatcha);

        passBtnText.color = Color.clear;
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.black; },Define.UIEvent.PointerEnter);
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.clear; },Define.UIEvent.PointerExit);
    }

    public void Gatcha()
    {
        TableManager.Load();
        var idol = ModelIdol.GenerateIdol();
        name.text = idol.Name;
        foreach (var i in System.Enum.GetValues(typeof(IdolStatType)))
        {
            var idx = (int)i - 1;
            stats[idx].SetStat(idol.Stats[(IdolStatType)i]);
        }
    }
}
