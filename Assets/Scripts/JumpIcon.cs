using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class JumpIcon : MonoBehaviour
{
    Sequence current;
    Tweener colorTween;
    Sequence fingerBlink;
    RectTransform rectTransform;
    Image image;
    Vector2 initPos;
    public RectTransform fingerIcon;
    public Vector2 punAmtJump;
    public float punTimeJump = 0.33f;
    public float delayTime = 1.5f;
    public Color shadowColor;
    public float shadowTime = 1;
    public float blinkTime = 1f;
    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        initPos = rectTransform.anchoredPosition;
    }

    void OnEnable() {
        rectTransform.anchoredPosition = initPos;
        current = DOTween.Sequence();
        current.Append(rectTransform.DOPunchAnchorPos(punAmtJump, punTimeJump));
        current.AppendInterval(delayTime);
        current.SetLoops(-1);

        image.color = Color.white;
        colorTween = image.DOColor(shadowColor, shadowTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        fingerBlink = DOTween.Sequence();
        fingerBlink.AppendCallback(()=>{
            fingerIcon.gameObject.SetActive(false);
        });
        fingerBlink.AppendInterval(blinkTime);
        fingerBlink.AppendCallback(()=>{
            fingerIcon.gameObject.SetActive(true);
        });
        fingerBlink.AppendInterval(blinkTime);
        fingerBlink.SetLoops(-1);

    }

    void OnDisable() {
        if(current != null)
            current.Kill(true);
        
        if(colorTween != null)
            colorTween.Kill(true);

        if(fingerBlink != null)
            fingerBlink.Kill(true);
    }
}
