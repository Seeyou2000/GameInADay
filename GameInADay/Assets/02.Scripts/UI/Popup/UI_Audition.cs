using UnityEngine;
using UnityEngine.UI;

public class UI_Audition : UI_Popup
{
    private enum Buttons
    {
        NextBtn,
        RedoBtn
    }
    
    enum GameObjects
    {
        StatGrid,
    }

    private const int StatMax = 8;
    private UI_Stat[] stats;
    public GameObject statGrid;
    public Button nextBtn,redoBtn;

    public override void Init()
    {
        base.Init();

        if (nextBtn != null) return;
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));

        statGrid = GetObject((int)GameObjects.StatGrid);
        var statsLength = System.Enum.GetValues(typeof(Define.Stats)).Length;
        stats = new UI_Stat[statsLength];
        for (var i = 0; i < statsLength; i++)
        {
            stats[i] = Managers.UI.MakeSubItem<UI_Stat>(parent: statGrid.transform);
        }
        
        nextBtn = GetButton((int)Buttons.NextBtn);
        redoBtn = GetButton((int)Buttons.RedoBtn);
    }
}
