using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private UI_ProducerName _producerNameUI;
    private UI_Audition _auditionUI;
    
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        // TODO: 원래 바로 오디션으로 가지 않기에 임시로 만든 순서
        _producerNameUI = Managers.UI.ShowPopupUI<UI_ProducerName>();
        _producerNameUI.Init();
        
        _producerNameUI.nextBtn.onClick.AddListener(() => { Managers.UI.ClosePopupUI();
            _auditionUI = Managers.UI.ShowPopupUI<UI_Audition>();
            _auditionUI.Init();
            _auditionUI.finishBtn.onClick.AddListener(() => { Managers.UI.ClosePopupUI();});
            _auditionUI.redoBtn.onClick.AddListener(() =>
            {
                Managers.UI.ClosePopupUI();
                _producerNameUI = Managers.UI.ShowPopupUI<UI_ProducerName>();
                _producerNameUI.nextBtn.onClick.AddListener(() =>
                {
                    Managers.UI.ClosePopupUI();
                    _auditionUI = Managers.UI.ShowPopupUI<UI_Audition>();
                });
            });
        });
        _producerNameUI.redoBtn.onClick.AddListener(() => { Managers.Scene.LoadScene(Define.Scene.Lobby);});
    }

    public override void Clear()
    {
        
    }
}
