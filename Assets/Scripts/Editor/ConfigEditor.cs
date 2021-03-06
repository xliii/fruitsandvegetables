﻿using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Config))]
public class ConfigEditor : Editor
{
	private bool useSeed = false;
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Config config = (Config) target;

		if (The.Config == null)
		{
			The.Config = config;
			The.Generator = config.GetComponent<FruitGenerator>();
			Debug.Log("Editor: Initialize");
		}

		useSeed = GUILayout.Toggle(useSeed, "Use seed");
		if (!config.validSize())
		{
			EditorGUILayout.HelpBox("Size should be even", MessageType.Error);
		}
		
		if (GUILayout.Button("Generate"))
		{
			if (config.validSize())
			{
				config.Generate();
			}
			else
			{
				Debug.LogError("Cannot generate field: Invalid size " + PrintSize(config));
			}						
		}
	}

	string PrintSize(Config config)
	{
		return string.Format("{0}x{1}", config.levelConfig.dimensions.x, config.levelConfig.dimensions.y);
	}
	
}
