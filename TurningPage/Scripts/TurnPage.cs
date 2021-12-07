using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnPage : MonoBehaviour
{
    /// <summary>
    /// 左边底页面
    /// </summary>
    public Image leftBottomPage_Appear;
    /// <summary>
    /// 左边逐渐消失页面遮罩
    /// </summary>
    public Image leftTopCover_DisAppear;
 
    /// <summary>
    /// 左边逐渐消失页面
    /// </summary>
    public Image leftTopPage_DisAppear;
    /// <summary>
    /// 左边逐渐出现页面遮罩
    /// </summary>
    public Image leftNextCover;
    /// <summary>
    /// 左边逐渐出现页面
    /// </summary>
    public Image leftNextPage;
    /// <summary>
    /// 左边页面阴影效果
    /// </summary>
    public Image leftPageShadow;

    /// <summary>
    /// 右边底页面
    /// </summary>
    public Image rightBottomPage_Appear;
    /// <summary>
    /// 右边逐渐消失页面遮罩
    /// </summary>
    public Image rightTopCover_DisAppear;
    /// <summary>
    /// 右边逐渐消失页面
    /// </summary>
    public Image rightTopPage_DisAppear;
    /// <summary>
    /// 右边逐渐出现页面遮罩
    /// </summary>
    public Image rightNextCover;
    /// <summary>
    /// 右边逐渐出现页面
    /// </summary>
    public Image rightNextPage;
    /// <summary>
    /// 右边页面阴影效果
    /// </summary>
    public Image rightPageShadow;

    public Sprite[] sprites;

    public float turningTime=2;
    private bool isTurning;

    private Coroutine turningRightCoroutine;
    private Coroutine turningLeftCoroutine;

    private int currentPages;
    private int maxPages;


    private void Start()
    {
        maxPages = sprites.Length;
        ResetBookImage();
    }

    public void PageTurning_Left()
    {
        if(!isTurning&&currentPages-2>=0)
        {
            turningLeftCoroutine = StartCoroutine(TurningLeftPage());
        }    
    }

    /// <summary>
    /// 右边翻页效果
    /// </summary>
    public void PageTurning_Right()
    {
        if (!isTurning && currentPages +2<maxPages)
        {
            turningRightCoroutine = StartCoroutine(TurningRightPage());
        }
    }
    /// <summary>
    /// 左边翻页效果
    /// </summary>
    /// <returns></returns>
    private IEnumerator TurningRightPage()
    {
        if (turningTime <= 0)
            StopCoroutine(turningRightCoroutine);
        isTurning = true;
        leftBottomPage_Appear.rectTransform.SetSiblingIndex(0);
        leftTopCover_DisAppear.rectTransform.SetSiblingIndex(1);
        leftNextCover.rectTransform.SetSiblingIndex(2);

        Vector3 offsetAngle = new Vector3(0, 0, 90 / (turningTime * 100));
        float currentTime = 0;
        while(true)
        {
            yield return new WaitForSeconds(0.01f);
            currentTime += 0.01f;
            if(currentTime<turningTime)
            {
                rightTopCover_DisAppear.rectTransform.eulerAngles += offsetAngle;
                rightTopPage_DisAppear.rectTransform.eulerAngles -= offsetAngle;
                rightNextCover.rectTransform.eulerAngles += offsetAngle;
                rightNextPage.rectTransform.eulerAngles += offsetAngle;
                rightPageShadow.rectTransform.eulerAngles -= offsetAngle;
            }
            else
            {
                break;
            }
        }
        currentPages += 2;
        ResetBookImage();
        ResetPageAttribute();
        isTurning = false;
        StopCoroutine(turningRightCoroutine);
    }

    private IEnumerator TurningLeftPage()
    {
        if (turningTime <= 0)
            StopCoroutine(turningLeftCoroutine);
        isTurning = true;
        rightBottomPage_Appear.rectTransform.SetSiblingIndex(0);
        rightTopCover_DisAppear.rectTransform.SetSiblingIndex(1);
        rightNextCover.rectTransform.SetSiblingIndex(2);

        Vector3 offsetAngle = new Vector3(0, 0, 90 / (turningTime * 100));
        float currentTime = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            currentTime += 0.01f;
            if (currentTime < turningTime)
            {
                leftTopCover_DisAppear.rectTransform.eulerAngles -= offsetAngle;
                leftTopPage_DisAppear.rectTransform.eulerAngles += offsetAngle;

                leftNextCover.rectTransform.eulerAngles -= offsetAngle;
                leftNextPage.rectTransform.eulerAngles -= offsetAngle;

                leftPageShadow.rectTransform.eulerAngles += offsetAngle;
            }
            else
            {
                break;
            }
        }
        currentPages -= 2;

        ResetBookImage();
        ResetPageAttribute();
        isTurning = false;
        StopCoroutine(turningLeftCoroutine);
    }

    private void ResetPageAttribute()
    {
        leftBottomPage_Appear.transform.localEulerAngles = Vector3.zero;
        leftTopCover_DisAppear.transform.localEulerAngles = Vector3.zero;
        leftTopPage_DisAppear.transform.localEulerAngles = Vector3.zero;
        leftNextCover.transform.localEulerAngles = new Vector3(0, 0, 90);
        leftNextPage.transform.localEulerAngles = new Vector3(0, 0, 90);
        leftPageShadow.transform.localEulerAngles = new Vector3(0, 0, -90);


        rightBottomPage_Appear.transform.localEulerAngles = Vector3.zero;
        rightTopCover_DisAppear.transform.localEulerAngles = Vector3.zero;
        rightTopPage_DisAppear.transform.localEulerAngles = Vector3.zero;
        rightNextCover.transform.localEulerAngles = new Vector3(0, 0, -90);
        rightNextPage.transform.localEulerAngles = new Vector3(0, 0, -90);
        rightPageShadow.transform.localEulerAngles = new Vector3(0, 0, 90);

        leftBottomPage_Appear.rectTransform.anchoredPosition = new Vector2(-850,-467);
        leftTopCover_DisAppear.rectTransform.anchoredPosition = new Vector2(0, -467);
        leftTopPage_DisAppear.rectTransform.anchoredPosition = new Vector2(850, -467);
        leftNextCover.rectTransform.anchoredPosition = new Vector2(0, -467);
        leftNextPage.rectTransform.anchoredPosition = new Vector2(-425, -934);
        leftPageShadow.rectTransform.anchoredPosition = new Vector2(-425,-445);

        rightBottomPage_Appear.rectTransform.anchoredPosition = new Vector2(0, -467);
        rightTopCover_DisAppear.rectTransform.anchoredPosition = new Vector2(0, -467);
        rightTopPage_DisAppear.rectTransform.anchoredPosition = new Vector2(-850, -467);
        rightNextCover.rectTransform.anchoredPosition = new Vector2(0, -467);
        rightNextPage.rectTransform.anchoredPosition = new Vector2(425, -934);
        rightPageShadow.rectTransform.anchoredPosition = new Vector2(425,-445);
    }

    private void ResetBookImage()
    {
        if (currentPages - 2 >= 0)
        {
            leftBottomPage_Appear.sprite = sprites[currentPages - 2];
            leftNextPage.sprite = sprites[currentPages - 1];
        }
        else
        {
            leftBottomPage_Appear.sprite = null;
            leftNextPage.sprite = null;
        }
        leftTopPage_DisAppear.sprite = sprites[currentPages];
        if (currentPages + 3 < maxPages)
        {
            rightBottomPage_Appear.sprite = sprites[currentPages + 3];
        }

        else
        {
            rightBottomPage_Appear.sprite = null;
        }
        if (currentPages + 2 < maxPages)
        {
            rightNextPage.sprite = sprites[currentPages + 2];

        }
        else
        {
            rightNextPage.sprite = null;
        }
        if (currentPages + 1 < maxPages)
        {
            rightTopPage_DisAppear.sprite = sprites[currentPages + 1];
        }
        else
        {
            rightTopPage_DisAppear.sprite = null;
        }

        
    }
}
