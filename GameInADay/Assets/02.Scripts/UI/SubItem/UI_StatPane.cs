using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatPane : UI_Base
{
    private enum Texts
    {
        Name, Age, PassBtnText
    }
    
    private enum Buttons
    {
        PassBtn
    }
    
    enum GameObjects
    {
        StatGrid
    }
    
    private UI_Stat[] stats;
    public GameObject statGrid;
    public TextMeshProUGUI name, age, passBtnText;
    public Button passBtn;
    private Dictionary<int, string> IntToName = new(){{0,"귀여움"}, {1,"쿨"}, {2,"섹시"}, {3,"아름다움"}, {4,"보컬"}, {5,"댄스"}, {6,"유머"}, {7,"지성"}};

    public override void Init()
    {
        if (IsBinded()) return;
        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        
        statGrid = GetObject((int)GameObjects.StatGrid);
        name = GetTextMeshPro((int)Texts.Name);
        age = GetTextMeshPro((int)Texts.Age);
        passBtn = GetButton((int)Buttons.PassBtn);
        passBtnText = GetTextMeshPro((int)Texts.PassBtnText);
        
        var statsLength = System.Enum.GetValues(typeof(IdolStatType)).Length;
        stats = new UI_Stat[statsLength];
        for (var i = 0; i < statsLength; i++)
        {
            stats[i] = Managers.UI.MakeSubItem<UI_Stat>(parent: statGrid.transform);
            stats[i].Init();
            stats[i].name.text = IntToName[i];
        }
        
        passBtnText.color = Color.clear;
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.black; },Define.UIEvent.PointerEnter);
        passBtn.gameObject.BindEvent((evt) => { passBtnText.color = Color.clear; },Define.UIEvent.PointerExit);
    }
    
    public void SetIdol(IdolStat idol)
    {
        name.text = idol.Name;
        foreach (var i in System.Enum.GetValues(typeof(IdolStatType)))
        {
            var idx = (int)i - 1;
            stats[idx].SetStat(idol.Stats[(IdolStatType)i]);
        }
    }
}
