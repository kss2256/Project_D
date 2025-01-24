using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Engine : MonoBehaviour
{

    private static Engine s_Instance;
    private static Engine Instance { get { Init(); return s_Instance; } }

    private InputManager m_Input = new InputManager();
    private ResourceManager m_Resource = new ResourceManager();
    private SceneManager m_Scene = new SceneManager();
    public static InputManager Input { get { return Instance.m_Input; } }
    public static ResourceManager Resource { get { return Instance.m_Resource; } }
    public static SceneManager Scene { get { return Instance.m_Scene; } }


    private void Update()
    {
        m_Input.MouseCheak();
    }


    private static void Init()
    {
        if(null == s_Instance)
        {
            GameObject go = GameObject.Find("@Engine");
            if(null == go)
            {
                go = new GameObject("@Engine");
                go.AddComponent<Engine>();
            }

            if(null == go.GetComponent<Engine>())
                go.AddComponent<Engine>();

            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Engine>();

        }



    }
    



}
