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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate() {
        if(Application.isEditor){
            mNumber.text = val_number;
            mContent.text = val_content;
        }
    }
}
