using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour,  IDragHandler, IPointerClickHandler

{
    public Action<PointerEventData> m_OnPointerClick = null;
    public Action<PointerEventData> m_OnDrag = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (null != m_OnPointerClick)
            m_OnPointerClick.Invoke(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {

        if (null != m_OnDrag)
            m_OnDrag.Invoke(eventData);
    }


}
