using UnityEngine;
using UnityEditor;
using LitJson;

/// <summary>
/// 利用ScriptableObject创建资源文件
/// </summary>
public class BuildAsset : Editor {

    [MenuItem("BuildAsset/Build Scriptable Asset")]
    public static void ExcuteBuild()
    {
        BookHolder holder = ScriptableObject.CreateInstance<BookHolder>();

        //查询excel表中数据，赋值给asset文件
        holder.menus = ExcelAccess.SelectMenuTable();

        string path= "Assets/Resources/booknames.asset";

        AssetDatabase.CreateAsset(holder, path);
        AssetDatabase.Refresh();

        Debug.Log("BuildAsset Success!");
    }
    [MenuItem("BuildAsset/Write")]
    public static void XieRu()
    {
        string[] strs;
        TextAsset ta = Resources.Load("ComponentColor2") as TextAsset;
        JsonData jd = JsonMapper.ToObject(ta.ToString());
        strs = new string[jd.Count];
        for (int i = 0; i < jd.Count; i++)
        {
            strs[i] = jd[i]["name"].ToString();
        }
        for (int j=0;j<strs.Length;j++)
        {
            for (int k = j+1; k < strs.Length; k++)
            {
                if (strs[j] == strs[k])
                {
                    Debug.Log(strs[k]);
                }
            }
        }
        ExcelAccess.WriteExcel(strs,"ww.xlsx","www");
    }
}
