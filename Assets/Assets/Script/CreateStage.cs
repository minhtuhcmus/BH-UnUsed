using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateStage {

	[MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        Stage_Data asset = ScriptableObject.CreateInstance<Stage_Data>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
