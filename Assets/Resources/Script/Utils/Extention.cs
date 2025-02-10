using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extention 
{

    public static void Mouse_UIEvent(this GameObject go, Action<PointerEventData> action, Define.Mouse_Type type = Define.Mouse_Type.Click)
    {
        UI_Base.Mouse_UIEvent(go, action, type);
    }




}
