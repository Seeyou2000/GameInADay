using UnityEngine;
using UnityEngine.UI;

public class UI_Game : UI_Scene
{
    private enum Buttons
    {
        LocalAuditionBtn,WideAreaAuditionBtn,NationalAuditionBtn
    }

    private enum Facilitys
    {
        FacilityContainer
    }

    public Button localAuditionBtn, wideAreaAuditionBtn, nationalAuditionBtn;
    public UI_Audition UIAudition;
    public UI_Facility UIFacility;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<UI_Facility>(typeof(Facilitys));
        
        localAuditionBtn = GetButton((int)Buttons.LocalAuditionBtn);
        wideAreaAuditionBtn = GetButton((int)Buttons.WideAreaAuditionBtn);
        nationalAuditionBtn = GetButton((int)Buttons.NationalAuditionBtn);
        UIFacility = Get<UI_Facility>((int)Facilitys.FacilityContainer);
        
        localAuditionBtn.onClick.AddListener(ShowAudition);
        wideAreaAuditionBtn.onClick.AddListener(ShowAudition);
        nationalAuditionBtn.onClick.AddListener(ShowAudition);
    }

    public void ShowAudition()
    {
        UIAudition = Managers.UI.ShowPopupUI<UI_Audition>();
        UIAudition.Init();
    }
}
