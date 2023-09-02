using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_FacilityListItem : UI_Base
{
    private enum Texts
    {
        NameText, RoomSpaceText, PriceText
    }

    public TextMeshProUGUI NameText, RoomSpaceText, PriceText;
    public Button Button;
    public int ID;

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Button = GetComponent<Button>();

        NameText = GetTextMeshPro((int)Texts.NameText);
        RoomSpaceText = GetTextMeshPro((int)Texts.RoomSpaceText);
        PriceText = GetTextMeshPro((int)Texts.PriceText);
    }

    public void SetFacility(int id)
    {
        ID = id;
        var facility = ModelAgencyFacilities.Get(id);
        NameText.text = facility.FacilitiesName;
        RoomSpaceText.text = $"{facility.RoomSpace}칸";
        PriceText.text = $"초기비용: {facility.Money} / 임대료: ₩ {facility.RentalCost} /주";
    }
}
