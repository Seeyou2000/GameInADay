using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UI_Song : UI_Popup
{
    enum GameObjects
    {
        MarketingGrid,GenreGrid,LyricGrid,PoseGrid,AppealGrid,StatGrid
    }

    enum Images
    {
        TotalScoreFill,
    }

    enum Texts
    {
        TotalScorePointText
    }

    enum InputFields
    {
        SongName,
    }

    enum Buttons
    {
        RedoBtn, NextBtn, SelectSingerBtn
    }

    public UI_SelectSinger UISelectSinger;
    public GameObject marketingGrid, genreGrid, lyricGrid, poseGrid, appealGrid, statGrid;
    public UI_SelectBtn[] marketingBtns, genreBtns, lyricBtns, poseBtns;
    public UI_AppealBox[] appealBoxes;
    public UI_SongStat[] songStats;
    public Button redoBtn, nextBtn, selectSingerBtn;
    public Image totalScoreFill;
    public TextMeshProUGUI totalScorePointText;
    public int selectedMarketingIdx, selectedGenreIdx, selectedLyricIdx, selectedPoseIdx;
    public float point;
    public TMP_InputField songName;
    private Dictionary<int, string> IntToName = new(){ {1,"10대"}, {2,"청년"}, {3,"어른"}, {4,"남성"}, {5,"여성"}, {6,"라이트층"}, {7,"매니아층"}};
    private Dictionary<int, string> IntToType = new(){{0,"귀여움"}, {1,"쿨"}, {2,"섹시"}, {3,"아름다움"}, {4,"보컬"}, {5,"댄스"}, {6,"유머"}, {7,"지성"}};

    public override void Init()
    {
        base.Init();
        if (IsBinded()) return;
        Bind<GameObject>(typeof(GameObjects));
        Bind<TMP_InputField>(typeof(InputFields));
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));

        marketingGrid = GetObject((int)GameObjects.MarketingGrid);
        genreGrid = GetObject((int)GameObjects.GenreGrid);
        lyricGrid = GetObject((int)GameObjects.LyricGrid);
        poseGrid = GetObject((int)GameObjects.PoseGrid);
        appealGrid = GetObject((int)GameObjects.AppealGrid);
        statGrid = GetObject((int)GameObjects.StatGrid);
        redoBtn = GetButton((int)Buttons.RedoBtn);
        nextBtn = GetButton((int)Buttons.NextBtn);
        selectSingerBtn = GetButton((int)Buttons.SelectSingerBtn);
        songName = Get<TMP_InputField>((int)InputFields.SongName);
        totalScoreFill = GetImage((int)Images.TotalScoreFill);
        totalScorePointText = GetTextMeshPro((int)Texts.TotalScorePointText);

        selectedMarketingIdx = selectedGenreIdx = selectedLyricIdx = selectedPoseIdx = -1;
        
        marketingBtns = new UI_SelectBtn[6];
        for (var i = 1; i <= 6; i++)
        {
            var idx = 20100 + i;
            var btnIdx = i - 1;
            marketingBtns[btnIdx] = Managers.UI.MakeSubItem<UI_SelectBtn>(parent: marketingGrid.transform);
            marketingBtns[btnIdx].Init();
            marketingBtns[btnIdx].btnText.text = ModelResearch.Get(idx).ResearchName;
            marketingBtns[btnIdx].gameObject.BindEvent((evt) => { 
                foreach (var btn in marketingBtns) btn.DeSelect(); 
                marketingBtns[btnIdx].Select();
                selectedMarketingIdx = idx;
                SetAppeal();
            });
        }
        
        genreBtns = new UI_SelectBtn[9];
        for (int i = 1; i <= 9; i++)
        {
            var idx = 40100 + i;
            var btnIdx = i - 1;
            genreBtns[btnIdx] = Managers.UI.MakeSubItem<UI_SelectBtn>(parent: genreGrid.transform);
            genreBtns[btnIdx].Init();
            genreBtns[btnIdx].btnText.text = ModelResearch.Get(idx).ResearchName;
            genreBtns[btnIdx].gameObject.BindEvent((evt) => {
                foreach (var btn in genreBtns) btn.DeSelect(); 
                genreBtns[btnIdx].Select();
                selectedGenreIdx = idx;
                SetAppeal();
            });
        }
        
        lyricBtns = new UI_SelectBtn[8];
        for (int i = 1; i <= 8; i++)
        {
            var idx = 10100 + i;
            var btnIdx = i - 1;
            lyricBtns[btnIdx] = Managers.UI.MakeSubItem<UI_SelectBtn>(parent: lyricGrid.transform);
            lyricBtns[btnIdx].Init();
            lyricBtns[btnIdx].btnText.text = ModelResearch.Get(idx).ResearchName;
            lyricBtns[btnIdx].gameObject.BindEvent((evt) =>
            {
                foreach (var btn in lyricBtns) btn.DeSelect(); 
                lyricBtns[btnIdx].Select();
                selectedLyricIdx = idx;
                SetAppeal();
            });
        }
        
        poseBtns = new UI_SelectBtn[7];
        for (int i = 1; i <= 7; i++)
        {
            var idx = 30100 + i;
            var btnIdx = i - 1;
            poseBtns[btnIdx] = Managers.UI.MakeSubItem<UI_SelectBtn>(parent: poseGrid.transform);
            poseBtns[btnIdx].Init();
            poseBtns[btnIdx].btnText.text = ModelResearch.Get(idx).ResearchName;
            poseBtns[btnIdx].gameObject.BindEvent((evt) =>
            {
                foreach (var btn in poseBtns) btn.DeSelect(); 
                poseBtns[btnIdx].Select();
                selectedPoseIdx = idx;
                SetAppeal();
            });
        }

        appealBoxes = new UI_AppealBox[7];
        for (int i = 1; i <= 7; i++)
        {
            appealBoxes[i - 1] = Managers.UI.MakeSubItem<UI_AppealBox>(parent: appealGrid.transform);
            appealBoxes[i - 1].Init();
            appealBoxes[i - 1].typeText.text = IntToName[i];
            appealBoxes[i - 1].percentageText.text = $"{ModelSongAppeal.Get(i).AppealRate * 100}%";
        }

        
        var statsLength = System.Enum.GetValues(typeof(IdolStatType)).Length;
        songStats = new UI_SongStat[statsLength];
        for (var i = 0; i < statsLength; i++)
        {
            songStats[i] = Managers.UI.MakeSubItem<UI_SongStat>(parent: statGrid.transform);
            songStats[i].Init();
            songStats[i].typeText.text = IntToType[i];
            songStats[i].pointText.text = "0";
            songStats[i].fill.fillAmount = 0;
        }
        
        redoBtn.onClick.AddListener(() => { Managers.UI.ClosePopupUI();});
        selectSingerBtn.onClick.AddListener(() =>
        {
            if (Managers.Game.CurrentIdols.Count == 0)
                return;
            UISelectSinger = Managers.UI.ShowPopupUI<UI_SelectSinger>();
            UISelectSinger.Init();
            int idx = 0;
            
            foreach (var idol in Managers.Game.CurrentIdols)
            {
                var btn = Managers.UI.MakeSubItem<UI_SingerBtn>(parent: UISelectSinger.content.transform);
                btn.Init();
                btn.btnText.text = idol.Name;
                btn.idolIdx = idx++;
                btn.btn.onClick.AddListener(() =>
                {
                    SetIdol(Managers.Game.CurrentIdols[btn.idolIdx]);
                    selectSingerBtn.GetComponentInChildren<TextMeshProUGUI>().text =
                        Managers.Game.CurrentIdols[btn.idolIdx].Name;
                    Managers.UI.ClosePopupUI();
                });
            }
        });

        totalScoreFill.fillAmount = 0;
    }

    private void SetAppeal()
    {
        float teen, youth, adult, man, woman, light, maniac;
        teen = ModelSongAppeal.Get(1).AppealRate;
        youth = ModelSongAppeal.Get(2).AppealRate;
        adult = ModelSongAppeal.Get(3).AppealRate;
        man = ModelSongAppeal.Get(4).AppealRate;
        woman = ModelSongAppeal.Get(5).AppealRate;
        light = ModelSongAppeal.Get(6).AppealRate;
        maniac = ModelSongAppeal.Get(7).AppealRate;
        
        if (selectedMarketingIdx >= 0)
        {
            teen += ModelResearch.Get(selectedMarketingIdx).PreferTeenage;
            youth += ModelResearch.Get(selectedMarketingIdx).PreferYouth;
            adult += ModelResearch.Get(selectedMarketingIdx).PreferAdult;
            man += ModelResearch.Get(selectedMarketingIdx).PreferMan;
            woman += ModelResearch.Get(selectedMarketingIdx).PreferWoman;
            light += ModelResearch.Get(selectedMarketingIdx).PreferLight;
            maniac += ModelResearch.Get(selectedMarketingIdx).PreferManiac;
        }
        
        if (selectedGenreIdx >= 0)
        {
            teen += ModelResearch.Get(selectedGenreIdx).PreferTeenage;
            youth += ModelResearch.Get(selectedGenreIdx).PreferYouth;
            adult += ModelResearch.Get(selectedGenreIdx).PreferAdult;
            man += ModelResearch.Get(selectedGenreIdx).PreferMan;
            woman += ModelResearch.Get(selectedGenreIdx).PreferWoman;
            light += ModelResearch.Get(selectedGenreIdx).PreferLight;
            maniac += ModelResearch.Get(selectedGenreIdx).PreferManiac;
        }
        
        if (selectedLyricIdx >= 0)
        {
            teen += ModelResearch.Get(selectedLyricIdx).PreferTeenage;
            youth += ModelResearch.Get(selectedLyricIdx).PreferYouth;
            adult += ModelResearch.Get(selectedLyricIdx).PreferAdult;
            man += ModelResearch.Get(selectedLyricIdx).PreferMan;
            woman += ModelResearch.Get(selectedLyricIdx).PreferWoman;
            light += ModelResearch.Get(selectedLyricIdx).PreferLight;
            maniac += ModelResearch.Get(selectedLyricIdx).PreferManiac;
        }
        
        if (selectedPoseIdx >= 0)
        {
            teen += ModelResearch.Get(selectedPoseIdx).PreferTeenage;
            youth += ModelResearch.Get(selectedPoseIdx).PreferYouth;
            adult += ModelResearch.Get(selectedPoseIdx).PreferAdult;
            man += ModelResearch.Get(selectedPoseIdx).PreferMan;
            woman += ModelResearch.Get(selectedPoseIdx).PreferWoman;
            light += ModelResearch.Get(selectedPoseIdx).PreferLight;
            maniac += ModelResearch.Get(selectedPoseIdx).PreferManiac;
        }
        
        appealBoxes[0].percentageText.text = $"{teen*100:F2}%";
        appealBoxes[1].percentageText.text = $"{youth*100:F2}%";
        appealBoxes[2].percentageText.text = $"{adult*100:F2}%";
        appealBoxes[3].percentageText.text = $"{man*100:F2}%";
        appealBoxes[4].percentageText.text = $"{woman*100:F2}%";
        appealBoxes[5].percentageText.text = $"{light*100:F2}%";
        appealBoxes[6].percentageText.text = $"{maniac*100:F2}%";
    }

    public void SetIdol(IdolStat idol)
    {
        point = 0.0f;
        foreach (var i in System.Enum.GetValues(typeof(IdolStatType)))
        {
            var idx = (int)i - 1;
            songStats[idx].SetStat(idol.Stats[(IdolStatType)i]);
            point += (float)idol.Stats[(IdolStatType)i].Current;
        }
        point /= (float)(99 * 8);
        totalScoreFill.fillAmount = point;
        totalScorePointText.text = $"{point:F2}";
    }
}
