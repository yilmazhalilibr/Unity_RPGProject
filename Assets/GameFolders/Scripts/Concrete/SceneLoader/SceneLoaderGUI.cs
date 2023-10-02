#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using Unity_RPGProject.Concrete;
using System.IO;

[CustomEditor(typeof(SceneLoader))]
public class SceneLoaderGUI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Delete save"))
        {
            var path = Path.Combine(Application.persistentDataPath, "save.sav");
            if (File.Exists(path))
            {
                File.Delete(path);
                Debug.Log("Save deleted successfully.");
            }
            else
            {
                Debug.Log("Save file does not exist.");
            }
        }


    }
}
#endif
