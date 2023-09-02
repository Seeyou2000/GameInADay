using UnityEngine;
using UnityEngine.UI;

public class UI_Game : UI_Scene
{
    private enum Buttons
    {
        LocalAuditionBtn,WideAreaAuditionBtn,NationalAuditionBtn
    }

    public Button localAuditionBtn, wideAreaAuditionBtn, nationalAuditionBtn;
    public UI_Audition UIAudition;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        localAuditionBtn = GetButton((int)Buttons.LocalAuditionBtn);
        wideAreaAuditionBtn = GetButton((int)Buttons.WideAreaAuditionBtn);
        nationalAuditionBtn = GetButton((int)Buttons.NationalAuditionBtn);
        
        localAuditionBtn.onClick.AddListener(ShowAudition);
    }

    public void ShowAudition()
    {
        UIAudition = Managers.UI.ShowPopupUI<UI_Audition>();
    }
}
