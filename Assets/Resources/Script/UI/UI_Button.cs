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

        //reflection��� : ������ �ÿ� �� �� ������ Ÿ���̳� ������� ã�Ƴ��� ����� �� �ְ� ���ִ� ��Ŀ����
        //Type�� ���ڹް� ���ÿ��� typeof�� �����ϸ� ��
        Bind<Button>(typeof(Button_UI));
        Bind<Text>(typeof(Text_UI));
        Bind<TextMeshProUGUI>(typeof(TextMeshPro_UI));
        Bind<Image>(typeof(Image_UI));
        Bind<GameObject>(typeof(GameObject_UI));

        GetUI<Text>((int)Text_UI.Draw_Text).text = "�̱� �׽�Ʈ��";
        GetText((int)Text_UI.Draw_Text).text = "��� �̱�";

    }

   


}
