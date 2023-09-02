using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StaffListItem : UI_Base
{
    private enum Texts
    {
        NameText, TypeText
    }

    public TextMeshProUGUI NameText, TypeText;
    public Button Btn;

    public override void Init()
    {
        Btn = GetComponent<Button>();
        Bind<TextMeshProUGUI>(typeof(Texts));

        NameText = GetTextMeshPro((int)Texts.NameText);
        TypeText = GetTextMeshPro((int)Texts.TypeText);
    }

    public void SetStaff(Staff staff)
    {
        NameText.text = staff.Name;
        TypeText.text = $"{staff.Type} / ₩ {staff.PayPerWeek} /주";
    }
}
