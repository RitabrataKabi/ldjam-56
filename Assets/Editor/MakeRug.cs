using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MakeRugHairy))]
public class MakeRug : Editor
{

    public override void OnInspectorGUI()
    {   
        base.OnInspectorGUI();
        
        MakeRugHairy t = (MakeRugHairy)target;

        if (GUILayout.Button("Add Hair"))
        {
            t.AddHair();
        }
    }
}