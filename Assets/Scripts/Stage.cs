using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public StageContent content;

    public Image Background;

    int currentStat;
    
    void Start()
    {
        StageManager.instance.OnLeft += GoPrePage;
        StageManager.instance.OnRight += GoNextPage;
        StageManager.instance.OnView += ViewDetail;
        
        LoadStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStage(){
        if(!content || content.pages == null)
            return;

        currentStat = 0;
        Background.sprite = content.pages[0].preview;
    }

    public void GoNextPage(){
        if(currentStat + 1 >= content.pages.Count)
            return;
        
        currentStat++;
        Background.sprite = content.pages[currentStat].preview;
    }

    public void GoPrePage(){
        if(currentStat - 1 < 0)
            return;
        
        currentStat--;
        Background.sprite = content.pages[currentStat].preview;
    }

    public void ViewDetail(){
        if(content.pages[currentStat].content != null)
            Background.sprite = content.pages[currentStat].content;
    }
}
