using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChangeSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //�õ�����
    Transform canvas;
    //Ҫ�϶������ԭʼ������
    private Transform originalParent;
    //���
    private CanvasGroup canvasGroup;
    //ƫ����
    Vector3 offset;
    void Start()
    {
        canvas = GameObject.FindWithTag(TagName.UICanvas_Screen).transform;
        canvasGroup = GetComponent<CanvasGroup>();
    }


    void Update()
    {

    }


    #region ��ʼ��ק
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        //�ı�Ҫ��ק����ĸ�����Ϊ��������������ͻ���ʾ�����б�������ǰ��
        transform.SetParent(canvas);
        offset = transform.position - Input.mousePosition;
        //����ק�ؼ�ʱ��������߿��Դ�͸�ؼ�����������Ŀؼ�������
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
        //�����ק�ؼ�ʱ���������
        Transform obj;
        //�������ڱ���������
        if (eventData.pointerEnter == null)
        {
            //����ק������Żص�ԭ����λ��
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
            return;
        }
        else
            obj = eventData.pointerEnter.transform;
        //��Ҫ�ж�OBJ��ʲô�ؼ�
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
                    //�����һ������
                    if (obj.childCount == 1)
                    {
                        Transform child = obj.GetChild(0);
                        child.SetParent(originalParent);
                        transform.SetParent(obj);
                        child.localPosition = Vector3.zero;
                    }
                    else
                    {//���û������
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
