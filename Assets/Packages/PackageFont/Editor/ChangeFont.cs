using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class ChangeFont
{
    /// <summary>
    /// 配置文件的父文件夹目录
    /// </summary>
    private static string mFontDataFolderPath { get { return Application.dataPath + "/Resources/FontData"; } }
    /// <summary>
    /// 配置文件名字
    /// </summary>
    private static string FontDataName = "FontData.asset";

    static StringBuilder builder;

    private static string GetFontDataPath()
    {
        return mFontDataFolderPath.Substring(mFontDataFolderPath.IndexOf("Assets")) + "/" + FontDataName;
    }

    public static void Change(Font toChangeFont)
    {
        builder = new StringBuilder();
        builder.Append("字体替换结果如下：\n");
        ChangeScene(toChangeFont);
        ChangePrefabAssets(toChangeFont);
        Debug.Log(builder.ToString());
    }

    private static void ChangeScene(Font toChangeFont)
    {
        //筛选文件夹和目标类型
        var scenePaths = GetFiles(Application.dataPath, new List<string> { ".unity" });
        builder.Append("替换的场景数量[" + scenePaths.Count + "]\n");

        foreach (var path in scenePaths)
        {
            builder.Append(path.Substring(path.IndexOf("Assets")) + "\n");
            //打开场景
            var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(path);
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                Text txt = obj.GetComponent<Text>();
                if (txt != null)
                {
                    txt.font = toChangeFont;
                }
            }
            //保存场景
            UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);
        }
    }

    private static void ChangePrefabAssets(Font toChangeFont)
    {
        List<string> prefafbPathList = GetFiles(Application.dataPath, new List<string> { ".prefab" });
        builder.Append("替换的预设体文件数量[" + prefafbPathList.Count + "]\n");
        for (int i = 0; i < prefafbPathList.Count; i++)
        {
            string path = prefafbPathList[i].Substring(prefafbPathList[i].IndexOf("Assets"));
            builder.Append(path + "\n");
            GameObject gameObj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (null != gameObj)
            {
                Component[] labels = null;
                labels = gameObj.GetComponentsInChildren<Text>(true);
                if (null != labels)
                {
                    foreach (Object item in labels)
                    {
                        Text text = (Text)item;
                        text.font = toChangeFont;
                    }
                }
            }
            EditorUtility.SetDirty(gameObj);
        }
        AssetDatabase.SaveAssets();
    }

    /// 获取目录下的所有对象路径
    /// 
    /// 目录路径
    /// 是否递归获取
    /// 
    private static List<string> GetFiles(string path, List<string> extensions, bool recursive = true)
    {
        var resultList = new List<string>();
        var dirArr = Directory.GetFiles(path, "*", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        for (int i = 0; i < dirArr.Length; i++)
        {
            //if (Path.GetExtension(dirArr[i]) != ".meta")
            //    resultList.Add(dirArr[i].Replace('\\', '/'));
            if (extensions.Contains(Path.GetExtension(dirArr[i])))
                resultList.Add(dirArr[i].Replace('\\', '/'));
        }
        return resultList;
    }

    /// <summary>
    /// 从FontData.asset获取字体
    /// </summary>
    /// <returns></returns>
    public static Font GetFont()
    {
        FontData fontData = AssetDatabase.LoadAssetAtPath<FontData>(GetFontDataPath());
        if (fontData != null)
            return fontData.defaultFont;
        else
            return null;
    }

    /// <summary>
    /// 保存设置的字体
    /// </summary>
    /// <param name="font"></param>
    public static void SaveFont(Font font)
    {
        CheckFontDataFolderExist();
        FontData data = ScriptableObject.CreateInstance<FontData>();
        data.defaultFont = font;
        AssetDatabase.CreateAsset(data, GetFontDataPath());
        EditorUtility.SetDirty(data);
    }

    /// <summary>
    /// 确保存放FontData.asset文件夹存在
    /// </summary>
    private static void CheckFontDataFolderExist()
    {
        if (!Directory.Exists(mFontDataFolderPath))
        {
            Directory.CreateDirectory(mFontDataFolderPath);
            AssetDatabase.Refresh();
        }
    }
}