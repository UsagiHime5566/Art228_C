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

    Outline effect;

    void Awake(){
        defaultTextSize = mContent.fontSize;
        defaultTextColor = mContent.color;
        effect = mContent.GetComponent<Outline>();
    }

    public void CancelFocus(){
        mContent.fontSize = defaultTextSize;
        mContent.color = defaultTextColor;
        mContent.fontStyle = FontStyle.Normal;
        if(effect) effect.enabled = false;
        linkMap.gameObject.SetActive(false);
    }

    public void SetFocus(int size, Color color){
        mContent.fontSize = size;
        mContent.color = color;
        mContent.fontStyle = FontStyle.Bold;
        if(effect) effect.enabled = true;
        linkMap.gameObject.SetActive(true);
    }

    private void OnValidate() {
        if(Application.isEditor){
            mNumber.text = val_number;
            mContent.text = val_content;
        }
    }
}
