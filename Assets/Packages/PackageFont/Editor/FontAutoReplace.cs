using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FontAutoReplace
{
    [InitializeOnLoadMethod]
    private static void Init()
    {
        Action OnEvent = delegate
        {
            ChangeDefaultFont();
        };

        EditorApplication.hierarchyChanged += delegate ()
        {
            OnEvent();
        };
    }

    /// <summary>
    /// 编辑器Hierarchy面板发生变化时，判断选择的物体是否含有text组件，如果有，则替换其字体
    /// </summary>
    private static void ChangeDefaultFont()
    {
        if (Selection.activeGameObject != null)
        {
            //Debug.Log(Selection.activeGameObject.name);
            Text text = Selection.activeGameObject.GetComponent<Text>();
            Text[] text_arr = Selection.activeGameObject.transform.GetComponentsInChildren<Text>();

            if (text != null || text_arr.Length >= 1)
            {
                Font font = ChangeFont.GetFont();

                if (text != null && font != null)
                {
                    if (!text.font.Equals(font))
                    {
                        text.font = font;
                        //text.raycastTarget = false;  //关闭射线检测
                    }
                }

                if (text_arr != null && font != null)
                {
                    for (int i = 0; i < text_arr.Length; i++)
                    {
                        if (!text_arr[i].font.Equals(font))
                        {
                            text_arr[i].font = font;
                            //text_arr[i].raycastTarget = false;  //关闭射线检测
                        }
                    }
                }
            }
        }

    }
}
