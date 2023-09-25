using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(AchievementDatabase))]

public class AchievementDbEditor : Editor
{
    private AchievementDatabase database;

    private void OnEnable()
    {
        database = target as AchievementDatabase;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Enum", GUILayout.Height(30)))
        {
            GenerateEnum();
        }
        
    }

    public void GenerateEnum()
    {
        string filePath = Path.Combine(Application.dataPath, "MyAchievements.cs");
        string code = "public enum MyAchievements {";

        foreach (Achievement achievement in database.achievements)
        {
            //To do: validate the id is proper format
            code += achievement.id + ",";
        }
        code += "}";
        File.WriteAllText(filePath, code);
        AssetDatabase.ImportAsset("Assets/MyAchievements.cs");
    }

}
//Code by Salma Elabsi