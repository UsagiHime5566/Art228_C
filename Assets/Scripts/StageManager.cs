using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    [Header("Link Object")]
    public Stage stagePage;
    public RectTransform HomePage;
    public RectTransform MapPage;
    public Button BTNView;
    public Button BTNHome;
    public Button BTNLeft;
    public Button BTNRight;
    public RectTransform OptionPanel;


    public Action<Button> OnHome;
    public Action<Button> OnLeft;
    public Action<Button> OnRight;
    public Action<Button> OnView;

    [Header("Animation")]
    public float punchAmt = 10;
    public float punchTime = 0.3f;
    public float idleTime = 180;
    int statIndex;

    ///Map System
    [Header("Map system")]
    public int MapId;
    public const int MaxMapId = 11;

    public int focusSize = 48;
    public Color focusColor;

    public List<NameHelper> area;

    void Awake(){
        instance = this;
    }

    void Start(){
        BTNView.onClick.AddListener(ButtonView);
        BTNHome.onClick.AddListener(ButtonHome);
        BTNLeft.onClick.AddListener(ButtonLeft);
        BTNRight.onClick.AddListener(ButtonRight);

        area = new List<NameHelper>(MapPage.GetComponentsInChildren<NameHelper>());
        statIndex = 0;
        MapId = 0;
        ShowCurrentMap();
        StartCoroutine(IdleToIntro());

        SignalAdapter.OnRecieveRun += RecieveRunSignal;

        RunBatCmd.CreateBatFile();
        StartCoroutine(DelayCloseOption());
    }

    IEnumerator DelayCloseOption()
    {
        yield return new WaitForSeconds(5);
        OptionPanel.gameObject.SetActive(false);
    }

    IEnumerator IdleToIntro(){
        while(true){
            int current = statIndex;
            yield return new WaitForSeconds(idleTime);
            if(current == statIndex)
                GoIntroPage();
        }
    }

    void RecieveRunSignal(int param){
        switch (param)
        {
            case 1:
                ButtonView();
                break;
            case 2:
                ButtonRight();
                break;
            case 3:
                ButtonLeft();
                break;
            case 4:
                ButtonHome();
                break;
        }
    }
    
    void ButtonView(){
        if(!MapPage.gameObject.activeSelf && !HomePage.gameObject.activeSelf) OnView?.Invoke(BTNView);
        statIndex++;

        if(!HomePage.gameObject.activeSelf && MapPage.gameObject.activeSelf){
            LoadIntoMap();
        }

        if(HomePage.gameObject.activeSelf)
            HomePage.gameObject.SetActive(false);

        BTNView.transform.localScale = Vector3.one;
        BTNView.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }
    void ButtonHome(){
        GoHomePage();
        statIndex++;

        BTNHome.transform.localScale = Vector3.one;
        BTNHome.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }
    void ButtonLeft(){
        if(!MapPage.gameObject.activeSelf) OnLeft?.Invoke(BTNLeft);
        statIndex++;

        if(MapPage.gameObject.activeSelf){
            MapId = MapId == 0 ? MaxMapId-1 : MapId-1;
            ShowCurrentMap();
        }

        BTNLeft.transform.localScale = Vector3.one;
        BTNLeft.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }
    void ButtonRight(){
        if(!MapPage.gameObject.activeSelf) OnRight?.Invoke(BTNRight);
        statIndex++;
        
        if(MapPage.gameObject.activeSelf){
            MapId = (MapId + 1) % MaxMapId;
            ShowCurrentMap();
        }

        BTNRight.transform.localScale = Vector3.one;
        BTNRight.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }

    ////////////////////

    void GoHomePage(){
        MapPage.gameObject.SetActive(true);
        BTNView.TurnBTN(true);
        BTNRight.TurnBTN(true);
        BTNLeft.TurnBTN(true);
    }
    void GoIntroPage(){
        stagePage.DestroyEffect();
        MapPage.gameObject.SetActive(true);
        HomePage.gameObject.SetActive(true);
        BTNView.TurnBTN(true);
        BTNRight.TurnBTN(true);
        BTNLeft.TurnBTN(true);
    }

    /////////////////

    void ShowCurrentMap(){
        for (int i = 0; i < area.Count; i++)
        {
            area[i].CancelFocus();
        }
        area[MapId].SetFocus(focusSize, focusColor);
    }

    void LoadIntoMap(){
        stagePage.LoadStage(area[MapId].stageContent);
        
        MapPage.gameObject.SetActive(false);
    }
}


public static class ExtendArt228
{
    public static void TurnBTN(this Button button, bool visible){
        CanvasGroup cg =  button.GetComponent<CanvasGroup>();
        if(cg == null)
            return;

        if(visible){
            cg.alpha = 1;
            cg.blocksRaycasts = true;
        } else {
            cg.alpha = 0;
            cg.blocksRaycasts = false;
        }
    }
}