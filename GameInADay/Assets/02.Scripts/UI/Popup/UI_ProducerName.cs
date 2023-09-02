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

    private enum Texts
    {
        FirstName, LastName, GroupName
    }

    public Button nextBtn,redoBtn;
    public TextMeshProUGUI firstName, lastName, groupName;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        
        nextBtn = GetButton((int)Buttons.NextBtn);
        redoBtn = GetButton((int)Buttons.RedoBtn);

        firstName = GetTextMeshPro((int)Texts.FirstName);
        lastName = GetTextMeshPro((int)Texts.LastName);
        groupName = GetTextMeshPro((int)Texts.GroupName);
    }
}
