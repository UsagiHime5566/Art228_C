using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public Stage stagePage;
    public RectTransform HomePage;
    public RectTransform MapPage;
    public Button BTNView;
    public Button BTNHome;
    public Button BTNLeft;
    public Button BTNRight;


    public Action OnHome;
    public Action OnLeft;
    public Action OnRight;
    public Action OnView;

    public float punchAmt = 10;
    public float punchTime = 0.3f;
    public float idleTime = 30;
    int statIndex;

    ///Map System

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
    }

    IEnumerator IdleToIntro(){
        while(true){
            int current = statIndex;
            yield return new WaitForSeconds(idleTime);
            if(current == statIndex)
                GoIntroPage();
        }
    }
    
    void ButtonView(){
        OnView?.Invoke();
        statIndex++;

        if(!HomePage.gameObject.activeSelf && MapPage.gameObject.activeSelf){
            LoadIntoMap();
        }

        if(HomePage.gameObject.activeSelf)
            HomePage.gameObject.SetActive(false);

        BTNView.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }
    void ButtonHome(){
        GoHomePage();
        statIndex++;

        BTNHome.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }
    void ButtonLeft(){
        if(!MapPage.gameObject.activeSelf) OnLeft?.Invoke();
        statIndex++;

        if(MapPage.gameObject.activeSelf){
            MapId = MapId == 0 ? MaxMapId-1 : MapId-1;
            ShowCurrentMap();
        }

        BTNLeft.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }
    void ButtonRight(){
        if(!MapPage.gameObject.activeSelf) OnRight?.Invoke();
        statIndex++;
        
        if(MapPage.gameObject.activeSelf){
            MapId = (MapId + 1) % MaxMapId;
            ShowCurrentMap();
        }

        BTNRight.transform.DOPunchScale(new Vector3(punchAmt, punchAmt, punchAmt), punchTime);
    }

    ////////////////////

    void GoHomePage(){
        MapPage.gameObject.SetActive(true);
        BTNView.gameObject.SetActive(true);
    }
    void GoIntroPage(){
        MapPage.gameObject.SetActive(true);
        HomePage.gameObject.SetActive(true);
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
