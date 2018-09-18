using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class _3CSettingCreate {
    [MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        _3CSettings asset = ScriptableObject.CreateInstance<_3CSettings>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
