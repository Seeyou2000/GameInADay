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
        GatchaBtn,
        PassBtn
    }

    private enum Texts
    {
        Name, Age, PassBtnText
    }
    
    enum GameObjects
    {
        StatGrid, CardGrid
    }

    private const int StatMax = 8;
    private UI_Stat[] stats;
    public UI_IdolCard[] cards;
    public GameObject statGrid, cardGrid;
    public Button finishBtn, passBtn;
    public TextMeshProUGUI name, age, passBtnText;
    private Dictionary<int, string> IntToName = new(){{0,"귀여움"}, {1,"쿨"}, {2,"섹시"}, {3,"아름다움"}, {4,"보컬"}, {5,"댄스"}, {6,"유머"}, {7,"지성"}};

    public override void Init()
    {
        base.Init();
        
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        statGrid = GetObject((int)GameObjects.StatGrid);
        cardGrid = GetObject((int)GameObjects.CardGrid);
        finishBtn = GetButton((int)Buttons.FinishBtn);
        passBtn = GetButton((int)Buttons.PassBtn);
        name = GetTextMeshPro((int)Texts.Name);
        age = GetTextMeshPro((int)Texts.Age);
        passBtnText = GetTextMeshPro((int)Texts.PassBtnText);
        
        var statsLength = System.Enum.GetValues(typeof(IdolStatType)).Length;
        stats = new UI_Stat[statsLength];
        for (var i = 0; i < statsLength; i++)
        {
            stats[i] = Managers.UI.MakeSubItem<UI_Stat>(parent: statGrid.transform);
            stats[i].Init();
            stats[i].name.text = IntToName[i];
        }


        cards = new UI_IdolCard[5];
        for (var i = 0; i < 5; i++)
        {
            cards[i] = Managers.UI.MakeSubItem<UI_IdolCard>(parent: cardGrid.transform);
            cards[i].Init();
        }
        
        GetButton((int)Buttons.GatchaBtn).onClick.AddListener(ShowIdol);

        passBtnText.color = Color.clear;
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.black; },Define.UIEvent.PointerEnter);
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.clear; },Define.UIEvent.PointerExit);
        finishBtn.onClick.AddListener(Managers.UI.ClosePopupUI);
    }

    public void ShowIdol()
    {
        var idol = ModelIdol.GenerateIdol("LocalAudition");
        name.text = idol.Name;
        foreach (var i in System.Enum.GetValues(typeof(IdolStatType)))
        {
            var idx = (int)i - 1;
            stats[idx].SetStat(idol.Stats[(IdolStatType)i]);
        }
    }
}
