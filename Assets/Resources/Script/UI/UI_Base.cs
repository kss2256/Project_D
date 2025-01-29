using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{

    protected Dictionary<Type, UnityEngine.Object[]> m_Objects = new Dictionary<Type, UnityEngine.Object[]>();


    protected Button GetButton(int _idx) { return GetUI<Button>(_idx); }
    protected Text GetText(int _idx) { return GetUI<Text>(_idx); }
    protected Image GetImage(int _idx) { return GetUI<Image>(_idx); }
    protected GameObject GetGameObject(int _idx) { return GetUI<GameObject>(_idx); }

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


}
