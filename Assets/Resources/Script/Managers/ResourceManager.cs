using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
   

    public T Load<T>(string _path) where T : Object
    {
        return Resources.Load<T>(_path);
    }

    public GameObject Instantiate(string _path, Transform _parent = null)
    {
        GameObject prefab = Load<GameObject>(_path);
        if (null == prefab)
        {
            Debug.Log($"Instantiate Failed : {_path}");
            return null;
        }

        return Object.Instantiate(prefab, _parent);
    }

    public void Destory(GameObject _go, float _time)
    {
        if (null == _go)
            return;

        Object.Destroy(_go, _time);
    }


}
