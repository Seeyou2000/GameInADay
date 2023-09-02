using UnityEngine;
using UnityEngine.UI;

public class UI_Lobby : UI_Scene
{
    private enum Buttons
    {
        StartBtn,
        ExitBtn
    }

    public Button startBtn;
    public Button exitBtn;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        startBtn = GetButton((int)Buttons.StartBtn);
        exitBtn = GetButton((int)Buttons.ExitBtn);
        
        exitBtn.onClick.AddListener(Application.Quit);
        startBtn.onClick.AddListener(() =>
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        });
    }
}
