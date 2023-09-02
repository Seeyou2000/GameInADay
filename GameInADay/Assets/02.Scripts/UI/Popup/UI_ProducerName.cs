using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProducerName : UI_Popup
{
    private enum Buttons
    {
        NextBtn,
        RedoBtn
    }

    private enum InputFields
    {
        FirstName, LastName, GroupName
    }

    public Button nextBtn,redoBtn;
    public TMP_InputField firstName, lastName, groupName;

    public override void Init()
    {
        base.Init();

        if (nextBtn != null) return;
        Bind<Button>(typeof(Buttons));
        Bind<TMP_InputField>(typeof(InputFields));
        
        nextBtn = GetButton((int)Buttons.NextBtn);
        redoBtn = GetButton((int)Buttons.RedoBtn);

        firstName = Get<TMP_InputField>((int)InputFields.FirstName);
        lastName = Get<TMP_InputField>((int)InputFields.LastName);
        groupName = Get<TMP_InputField>((int)InputFields.GroupName);
    }
}
