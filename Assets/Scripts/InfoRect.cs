﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InfoRect : MonoBehaviour
{
    public float duration = 3;
    public float shiftDuration = 0.33f;
    public Image infoImg;
    public List<Sprite> shiftInfos;

    int currentIndex;

    void Start(){
        currentIndex = 0;
        StartCoroutine(DoShiftInfos());
    }

    IEnumerator DoShiftInfos(){
        while(true){
            if(shiftInfos != null){
                if(currentIndex < shiftInfos.Count && shiftInfos[currentIndex] != null){
                    SetNextInfo(shiftInfos[currentIndex]);
                    currentIndex = (currentIndex + 1) % shiftInfos.Count;
                }
            }
            yield return new WaitForSeconds(duration);
        }
    }

    void SetNextInfo(Sprite src){
        infoImg.DOColor(Color.black, shiftDuration).OnComplete(()=>{
            infoImg.sprite = src;
            infoImg.DOColor(Color.white, shiftDuration);
        });
    }
}