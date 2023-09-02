using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Audition : UI_Popup
{
    private enum Buttons
    {
        FinishBtn
    }
    
    enum GameObjects
    {
        Pane, CardGrid
    }

    private const int StatMax = 8;

    public int currendIdx;
    public UI_IdolCard[] cards;
    public UI_StatPane statPane;
    public GameObject pane, cardGrid;
    public Button finishBtn;

    public override void Init()
    {
        base.Init();
        if (IsBinded()) return;
        
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        
        cardGrid = GetObject((int)GameObjects.CardGrid);
        pane = GetObject((int)GameObjects.Pane);
        finishBtn = GetButton((int)Buttons.FinishBtn);
        statPane = Managers.UI.MakeSubItem<UI_StatPane>(parent: pane.transform );
        statPane.Init();
        statPane.transform.localPosition = Vector3.zero;

        cards = new UI_IdolCard[Define.MaxAuditionCount];
        for (var i = 0; i < Define.MaxAuditionCount; i++)
        {
            cards[i] = Managers.UI.MakeSubItem<UI_IdolCard>(parent: cardGrid.transform);
            cards[i].Init();
        }
        
        finishBtn.onClick.AddListener(Managers.UI.ClosePopupUI);
        ClosePane();
    }

    public void ShowIdol(int idx, IdolStat idol)
    {
        currendIdx = idx;
        ShowPane();
        statPane.SetIdol(idol);
    }
    
    public void ShowPane()
    {
        pane.SetActive(true);
        statPane.passBtnText.color = Color.clear;
    }
    
    public void ClosePane()
    {
        pane.SetActive(false);
        statPane.passBtnText.color = Color.clear;
    }
}
