using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiScreen : MonoBehaviour
{
    public Canvas MainCanvas;
    public List<Camera> Cameras;
    int loopIndex;

    void Start()
    {
        foreach (var item in Display.displays)
        {
            item.Activate();
        }
    }

    void Update()
    {
        MainCanvas.worldCamera = Cameras[loopIndex];
        loopIndex = (loopIndex + 1) % Cameras.Count;
    }
}
