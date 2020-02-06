using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageContent : ScriptableObject
{
    public List<ArtPage> pages;
    public List<Sprite> backgrounds;
    public List<Sprite> dataInfo;
}


[System.Serializable]
public class ArtPage 
{
    public Sprite preview;
    public Sprite content;
}