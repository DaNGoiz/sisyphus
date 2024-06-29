using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChangeSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //得到画布
    Transform canvas;
    //要拖动物体的原始父物体
    private Transform originalParent;
    //组件
    private CanvasGroup canvasGroup;
    //偏移量
    Vector3 offset;
    void Start()
    {
        canvas = GameObject.FindWithTag(TagName.UICanvas_Screen).transform;
        canvasGroup = GetComponent<CanvasGroup>();
    }


    void Update()
    {

    }


    #region 开始拖拽
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        //改变要拖拽物体的父物体为画布，这样物体就会显示在所有背包的最前面
        transform.SetParent(canvas);
        offset = transform.position - Input.mousePosition;
        //在拖拽控件时，鼠标射线可以穿透控件，并被下面的控件所接受
        canvasGroup.blocksRaycasts = false;
    }
    #endregion


    #region IDragHandler implementation


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
    }


    #endregion
    #region IEndDragHandler implementation


    public void OnEndDrag(PointerEventData eventData)
    {
        //鼠标拖拽控件时进入的物体
        Transform obj;
        //如果鼠标在背包的外面
        if (eventData.pointerEnter == null)
        {
            //把拖拽的物体放回到原来的位置
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
            return;
        }
        else
            obj = eventData.pointerEnter.transform;
        //需要判断OBJ是什么控件
        switch (obj.tag)
        {
            case "Untagged":
                {
                    if (obj.GetComponent<Spawn>() != null)
                    {
                        Transform temp = obj.parent;
                        obj.SetParent(originalParent);
                        transform.SetParent(temp);
                        obj.localPosition = Vector3.zero;
                    }
                    else
                        transform.SetParent(originalParent);
                }
                break;
            case TagName.slot:
                {
                    //如果有一个物体
                    if (obj.childCount == 1)
                    {
                        Transform child = obj.GetChild(0);
                        child.SetParent(originalParent);
                        transform.SetParent(obj);
                        child.localPosition = Vector3.zero;
                    }
                    else
                    {//如果没有物体
                        transform.SetParent(obj);
                    }
                }
                break;
            default:
                transform.SetParent(originalParent);
                break;
        }
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
    }
    #endregion
}
