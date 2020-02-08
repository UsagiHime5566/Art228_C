using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageContent : ScriptableObject
{
    public List<ArtPage> pages;

    [ContextMenu("Reset datas")]
    void ResetParams(){
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i] = null;
        }
        pages = null;
    }
}


[System.Serializable]
public class ArtPage 
{
    public Sprite preview;
    public Sprite content;
    public GameObject effect;
    public GameObject infoRect;
    public List<Sprite> infos;
}