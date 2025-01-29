using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{

    enum Button_UI
    {
        Draw_Button,

    }
    enum Text_UI
    {
        Draw_Text,
    }
    enum TextMeshPro_UI
    {
        Draw_TextMeshPro,
    }
    enum Image_UI
    {
        Draw_Image,
    }
    enum GameObject_UI
    {
        Draw_GameObject,
    }
    private void Start()
    {

        //reflection기능 : 컴파일 시에 알 수 없었던 타입이나 멤버들을 찾아내고 사용할 수 있게 해주는 메커니즘
        //Type로 인자받고 사용시에는 typeof로 지정하면 됨
        Bind<Button>(typeof(Button_UI));
        Bind<Text>(typeof(Text_UI));
        Bind<TextMeshProUGUI>(typeof(TextMeshPro_UI));
        Bind<Image>(typeof(Image_UI));
        Bind<GameObject>(typeof(GameObject_UI));

        GetUI<Text>((int)Text_UI.Draw_Text).text = "뽑기 테스트중";
        GetText((int)Text_UI.Draw_Text).text = "대박 뽑기";

    }

   


}
