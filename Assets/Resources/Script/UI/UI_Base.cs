using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{

    protected Dictionary<Type, UnityEngine.Object[]> m_Objects = new Dictionary<Type, UnityEngine.Object[]>();


    protected Button GetButton(int _idx) { return GetUI<Button>(_idx); }
    protected Text GetText(int _idx) { return GetUI<Text>(_idx); }
    protected Image GetImage(int _idx) { return GetUI<Image>(_idx); }
    protected GameObject GetObject(int _idx) { return GetUI<GameObject>(_idx); }

    protected void Bind<T>(Type _type) where T : UnityEngine.Object
    {

        string[] names = Enum.GetNames(_type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        m_Objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            
        }

    }

    protected T GetUI<T>(int _idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;

        if (false == (m_Objects.TryGetValue(typeof(T), out objects)))
            return null;

        return objects[_idx] as T;


    }

    public static void Mouse_UIEvent(GameObject go, Action<PointerEventData> action, Define.Mouse_Type type = Define.Mouse_Type.Click)
    {

        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.Mouse_Type.Click:
                evt.m_OnPointerClick -= action;
                evt.m_OnPointerClick += action;
                break;
            case Define.Mouse_Type.Drag:
                evt.m_OnDrag -= action;
                evt.m_OnDrag += action;
                break;
        }     

    }
}
