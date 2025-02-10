using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Lobby : UI_PopUp
{

    enum Button_UI
    {
        Start_Button,
    }
    enum Image_UI
    {
        Start_Image,
    }

    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        Init();
    }

    private void Update()
    {

        

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (Engine.Scene.CurScene == SceneType.STAGE_1)
        {          
            Engine.Scene.ScreenRatio();  // 씬이 완전히 로드된 후 실행
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Button_UI));
        Bind<Image>(typeof(Image_UI));

        GameObject go = GetButton((int)Button_UI.Start_Button).gameObject;

        Mouse_UIEvent(go, (PointerEventData data) => { Engine.Scene.ChangeScene(SceneType.STAGE_1); });

        
    }






}
