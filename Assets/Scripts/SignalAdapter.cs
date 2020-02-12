using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalAdapter : MonoBehaviour
{
    public static SignalAdapter instance;
    public ReadDigitalData adapterRead;
    public WriteDigitalData adapterWrite;

    public Text StatsRead;
    public InputField COM_FieldRead;
    public Button BTN_ConnectRead;
    public Text StatsWrite;
    public InputField COM_FieldWrite;
    public Button BTN_ConnectWrite;
    public static Action<int> OnRecieveRun;

    void Awake(){
        instance = this;
    }

    void Start() {
        if(COM_FieldRead){
            COM_FieldRead.text = PlayerPrefs.GetString("ReadCOM", "");
            COM_FieldRead.onValueChanged.AddListener((str)=>{
                PlayerPrefs.SetString("ReadCOM", str);
            });
            BTN_ConnectRead.onClick.AddListener(ConnectReadPort);

            adapterRead.OnRecieveData += OnReadData;
        }
        if(COM_FieldWrite){
            COM_FieldWrite.text = PlayerPrefs.GetString("WriteCOM", "");
            COM_FieldWrite.onValueChanged.AddListener((str)=>{
                PlayerPrefs.SetString("WriteCOM", str);
            });
            BTN_ConnectWrite.onClick.AddListener(ConnectWritePort);
        }

        StartCoroutine(CheckStatus());
        StartCoroutine(ConnectHardware());
    }

    IEnumerator CheckStatus(){
        while(true){
            
            if(adapterRead)
                if(adapterRead.ArduinoPortState){
                    StatsRead.text = "Online";
                    StatsRead.color = Color.cyan;
                } else {
                    StatsRead.text = "Offline";
                    StatsRead.color = Color.red;
                }

            if(adapterWrite)
                if(adapterWrite.ArduinoPortState){
                    StatsWrite.text = "Online";
                    StatsWrite.color = Color.cyan;
                } else {
                    StatsWrite.text = "Offline";
                    StatsWrite.color = Color.red;
                }

            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator ConnectHardware(){
        yield return new WaitForSeconds(1.0f);
        ConnectReadPort();
        ConnectWritePort();
    }

    public static void SendSerial(string src){
        instance.adapterWrite.WriteData(src);
    }
    public void ConnectReadPort(){
        try {
            adapterRead.DvInit(COM_FieldRead.text);
        } catch (System.Exception e){ Debug.Log(e.Message.ToString()); }
    }
    public void ConnectWritePort(){
        try {
            adapterWrite.DvInit(COM_FieldWrite.text);
        } catch (System.Exception e){ Debug.Log(e.Message.ToString()); }
    }

    void OnReadData(string str){
        //Compare the string of Arduino?
        if(str == "1")
            OnRecieveRun?.Invoke(1);
        if(str == "2")
            OnRecieveRun?.Invoke(2);
        if(str == "3")
            OnRecieveRun?.Invoke(3);
        if(str == "4")
            OnRecieveRun?.Invoke(4);
    }

    public static void FakeInvoke(int opt){
        OnRecieveRun?.Invoke(opt);
    }

    void OnApplicationQuit() {
        adapterRead?.CloseArduino();
        adapterWrite?.CloseArduino();
    }
}
