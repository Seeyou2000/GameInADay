using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_HireStaffListItem : UI_Base
{
    private enum Texts
    {
        NameText, TypeText
    }

    private enum Buttons
    {
        HireBtn
    }

    public TextMeshProUGUI NameText, TypeText;
    public Button HireBtn;

    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        NameText = GetTextMeshPro((int)Texts.NameText);
        TypeText = GetTextMeshPro((int)Texts.TypeText);
        HireBtn = GetButton((int)Buttons.HireBtn);
    }

    public void SetStaff(Staff staff)
    {
        NameText.text = staff.Name;
        TypeText.text = $"{staff.Type} / ₩ {staff.PayPerWeek} /주";
    }
}
