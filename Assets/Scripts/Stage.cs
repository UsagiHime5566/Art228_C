using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public StageContent content;

    public Image Background;

    int currentIndex;

    public GameObject currentEffect;
    public GameObject currentRect;
    
    void Start()
    {
        TurnOnBTN();
    }

    public void LoadStage(StageContent cont){
        content = cont;
        if(!content || content.pages == null)
            return;

        currentIndex = 0;
        Background.sprite = content.pages[0].preview;
        ShowOtherInfos();
    }

    void TurnOnBTN(){
        StageManager.instance.OnLeft += GoPrePage;
        StageManager.instance.OnRight += GoNextPage;
        StageManager.instance.OnView += ViewDetail;
        StageManager.instance.OnHome += BackToMap;
    }

    void ShowOtherInfos(){
        if(currentEffect)
            Destroy(currentEffect);
        if(currentRect)
            Destroy(currentRect);

        if(content.pages[currentIndex].effect != null){
            currentEffect = Instantiate(content.pages[currentIndex].effect, transform);
        }

        if(content.pages[currentIndex].infoRect != null){
            currentRect = Instantiate(content.pages[currentIndex].infoRect, transform);
            currentRect.GetComponent<InfoRect>().shiftInfos = content.pages[currentIndex].infos;
        }

        if(content.pages[currentIndex].content == null)
            StageManager.instance.BTNView.gameObject.SetActive(false);
        else
            StageManager.instance.BTNView.gameObject.SetActive(true);
    }

    public void GoNextPage(){
        if(currentIndex + 1 >= content.pages.Count)
            return;
        
        currentIndex++;
        Background.sprite = content.pages[currentIndex].preview;
        ShowOtherInfos();
    }

    public void GoPrePage(){
        if(currentIndex - 1 < 0)
            return;
        
        currentIndex--;
        Background.sprite = content.pages[currentIndex].preview;
        ShowOtherInfos();
    }

    public void ViewDetail(){
        if(content.pages[currentIndex].content != null)
            Background.sprite = content.pages[currentIndex].content;

        ShowOtherInfos();
    }

    public void BackToMap(){
        if(currentEffect)
            Destroy(currentEffect);
        if(currentRect)
            Destroy(currentRect);
    }
}
