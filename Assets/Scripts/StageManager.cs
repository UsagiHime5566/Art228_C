using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public RectTransform HomePage;
    public Button BTNView;
    public Button BTNHome;
    public Button BTNLeft;
    public Button BTNRight;


    public Action OnHome;
    public Action OnLeft;
    public Action OnRight;
    public Action OnView;

    void Awake(){
        instance = this;
    }

    void Start(){
        BTNView.onClick.AddListener(ButtonView);
        BTNHome.onClick.AddListener(ButtonHome);
        BTNLeft.onClick.AddListener(ButtonLeft);
        BTNRight.onClick.AddListener(ButtonRight);
    }
    
    void ButtonView(){
        OnView?.Invoke();
    }
    void ButtonHome(){
        OnHome?.Invoke();
    }
    void ButtonLeft(){
        OnLeft?.Invoke();
    }
    void ButtonRight(){
        OnRight?.Invoke();
    }
}
