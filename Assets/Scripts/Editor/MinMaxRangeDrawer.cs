using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer (typeof (MinMaxRangeAttribute))]
class MinMaxSliderDrawer : PropertyDrawer {
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

		if (property.propertyType == SerializedPropertyType.Vector2) {
			Vector2 range = property.vector2Value;
			float min = range.x;
			float max = range.y;
			MinMaxRangeAttribute attr = attribute as MinMaxRangeAttribute;
			EditorGUI.BeginChangeCheck ();
			EditorGUI.MinMaxSlider (label, position, ref min, ref max, attr.min, attr.max);
			if (EditorGUI.EndChangeCheck ()) {
				range.x = min;
				range.y = max;
				property.vector2Value = range;
			}
		} else {
			EditorGUI.LabelField (position, label, "Use only with Vector2");
		}
	}
}
