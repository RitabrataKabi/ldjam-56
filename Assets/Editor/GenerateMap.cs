using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tex2Model))]
public class GenerateMap : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Tex2Model mapGenerator = (Tex2Model)target;

		GUILayout.BeginHorizontal();

		if(GUILayout.Button("Generate Map"))
		{
			mapGenerator.GenerateMap();
		}

		if(GUILayout.Button("Reset Map"))
		{
			mapGenerator.Reset();
		}

		GUILayout.EndHorizontal();
	}
}