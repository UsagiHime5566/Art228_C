using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameHelper : MonoBehaviour
{
    public Text mNumber;
    public Text mContent;
    public RectTransform linkMap;
    public StageContent stageContent;

    public string val_number;
    public string val_content;

    int defaultTextSize;
    Color defaultTextColor;

    void Start(){
        defaultTextSize = mContent.fontSize;
        defaultTextColor = mContent.color;
    }

    public void CancelFocus(){
        mContent.fontSize = defaultTextSize;
        mContent.color = defaultTextColor;
        linkMap.gameObject.SetActive(false);
    }

    public void SetFocus(int size, Color color){
        mContent.fontSize = size;
        mContent.color = color;
        linkMap.gameObject.SetActive(true);
    }

    private void OnValidate() {
        if(Application.isEditor){
            mNumber.text = val_number;
            mContent.text = val_content;
        }
    }
}
