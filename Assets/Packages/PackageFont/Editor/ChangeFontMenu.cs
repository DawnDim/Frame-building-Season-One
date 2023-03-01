using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeFontMenu : EditorWindow
{
    private static Font m_font;
    private static EditorWindow window;

    [MenuItem("Tools/PFont/设置默认字体并全局替换")]
    public static void OpenWindow()
    {
        window = GetWindow(typeof(ChangeFontMenu));
        window.minSize = new Vector2(200, 200);
        m_font = ChangeFont.GetFont();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("选择字体");
        EditorGUILayout.Space();
        m_font = (Font)EditorGUILayout.ObjectField(m_font, typeof(Font), true);
        EditorGUILayout.Space();
        if (GUILayout.Button("确定"))
        {
            ChangeFont.SaveFont(m_font);
            ChangeFont.Change(m_font);
            window.Close();
        }
    }
}
