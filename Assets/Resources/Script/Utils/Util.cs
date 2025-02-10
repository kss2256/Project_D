using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Util
{

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (null == component)
            component = go.AddComponent<T>();

        return component;
    }


    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)       
    {
        Transform tr = FindChild<Transform>(go, name, recursive);
        if (null == tr)
            return null;

        return tr.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) 
        where T : UnityEngine.Object
    {

        if (null == go)
            return null;

        
        if(recursive)
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }

        }
        else
        {
            for(int i = 0; i < go.transform.childCount; ++i)
            {
                Transform tr = go.transform.GetChild(i);

                if (string.IsNullOrEmpty(name) || tr.name == name)
                {
                    T component = tr.GetComponent<T>();
                    if (null != component)
                        return component;
                }
            }


        }


        return null;
    }





}
