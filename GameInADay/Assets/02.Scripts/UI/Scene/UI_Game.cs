using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : UI_Scene
{
    private enum Buttons
    {
        LocalAuditionBtn,WideAreaAuditionBtn,NationalAuditionBtn,PlayBtn,PauseBtn,PlayDoubleBtn
    }

    private enum MainUIs
    {
        FacilityContainer
    }

    private enum Texts
    {
        MoneyText, DateText
    }

    private enum Images
    {
        TimeGaugeBar
    }

    public Button localAuditionBtn, wideAreaAuditionBtn, nationalAuditionBtn, PlayBtn, PauseBtn, PlayDoubleBtn;
    public UI_Audition UIAudition;
    public UI_Facility UIFacility;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI DateText;
    public Image TimeGaugeBar;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(MainUIs));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        
        localAuditionBtn = GetButton((int)Buttons.LocalAuditionBtn);
        wideAreaAuditionBtn = GetButton((int)Buttons.WideAreaAuditionBtn);
        nationalAuditionBtn = GetButton((int)Buttons.NationalAuditionBtn);
        PlayBtn = GetButton((int)Buttons.PlayBtn);
        PauseBtn = GetButton((int)Buttons.PauseBtn);
        PlayDoubleBtn = GetButton((int)Buttons.PlayDoubleBtn);
        UIFacility = Get<GameObject>((int)MainUIs.FacilityContainer).GetComponent<UI_Facility>();
        MoneyText = GetTextMeshPro((int)Texts.MoneyText);
        DateText = GetTextMeshPro((int)Texts.DateText);
        TimeGaugeBar = Get<Image>((int)Images.TimeGaugeBar);
        
        localAuditionBtn.onClick.AddListener(ShowAudition);
        wideAreaAuditionBtn.onClick.AddListener(ShowAudition);
        nationalAuditionBtn.onClick.AddListener(ShowAudition);
    }

    public void ShowAudition()
    {
        UIAudition = Managers.UI.ShowPopupUI<UI_Audition>();
        UIAudition.Init();
    }

    public void SetMoney(long money)
    {
        MoneyText.text = $"$ {money}";
    }

    public void SetDate(string dateString, float datePercentage)
    {
        DateText.text = dateString;
        TimeGaugeBar.DOFillAmount(datePercentage, 0.1f);
    }
}
