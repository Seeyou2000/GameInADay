using UnityEngine;
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
    public UI_AuditionStatPane auditionStatPane;
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
        auditionStatPane = Managers.UI.MakeSubItem<UI_AuditionStatPane>(parent: pane.transform );
        auditionStatPane.Init();
        auditionStatPane.transform.localPosition = Vector3.zero;

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
        auditionStatPane.SetIdol(idol);
    }
    
    public void ShowPane()
    {
        pane.SetActive(true);
        auditionStatPane.passBtnText.color = Color.clear;
    }
    
    public void ClosePane()
    {
        pane.SetActive(false);
        auditionStatPane.passBtnText.color = Color.clear;
    }
}
