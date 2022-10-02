using System;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Utils {
	[AttributeUsage(AttributeTargets.Field)]
	public class CallAccessorsAttribute : PropertyAttribute {
#if UNITY_EDITOR
		private readonly string name;
		public string Name => name;

		public CallAccessorsAttribute(string name) {
			this.name = name;
		}
#endif
	}

#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(CallAccessorsAttribute))]
	public class CallAccessorsAttributeDrawer : PropertyDrawer {
		private PropertyInfo propertyInfo = null;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			try {
				string name = (attribute as CallAccessorsAttribute).Name;

				if( propertyInfo == null )
					propertyInfo = GetInfoFromProperty(name, property);

				if( propertyInfo == null ) // still null?
					DrawErrorGUI(position, name);
				else
					DrawPropertyGUI(position, name, property, propertyInfo, label);
			}
			catch( Exception ex ) {
				DrawErrorGUI(position, ex);
			}
		}

		private static PropertyInfo GetInfoFromProperty(string name, SerializedProperty property) {
			return property.serializedObject.targetObject.GetType().GetProperty(
				name,
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
			);
		}

		private static void DrawErrorGUI(Rect position, string name) {
			EditorGUI.HelpBox(position, "Could not find property '" + name + "'.", MessageType.Error);
		}

		private static void DrawErrorGUI(Rect position, Exception ex) {
			EditorGUI.HelpBox(position, ex.Message, MessageType.Error);
		}

		private static void DrawPropertyGUI(Rect position, string name, SerializedProperty property, PropertyInfo propertyInfo, GUIContent label) {
			var target = property.serializedObject.targetObject;
			object value = propertyInfo.GetValue(target, null);

			EditorGUI.BeginChangeCheck();

			value = GetValueFromGUI(position, property, propertyInfo, value, label);

			if( EditorGUI.EndChangeCheck() ) {
				Undo.RecordObject(target, "Serialize property '" + name + "'");
				propertyInfo.SetValue(target, value, null);
			}
		}

		private static object GetValueFromGUI(Rect position, SerializedProperty property, PropertyInfo propertyInfo, object value, GUIContent label) {
			return property.propertyType switch {
				SerializedPropertyType.Integer => EditorGUI.IntField(position, label, (int)value),
				SerializedPropertyType.Boolean => EditorGUI.Toggle(position, label, (bool)value),
				SerializedPropertyType.Float => EditorGUI.FloatField(position, label, (float)value),
				SerializedPropertyType.String => EditorGUI.TextField(position, label, (string)value),
				SerializedPropertyType.Color => EditorGUI.ColorField(position, label, (Color)value),
				SerializedPropertyType.ObjectReference => EditorGUI.ObjectField(position, label, (UnityEngine.Object)value, propertyInfo.PropertyType, true),
				SerializedPropertyType.LayerMask => EditorGUI.LayerField(position, label, (int)value),
				SerializedPropertyType.Enum => EditorGUI.EnumPopup(position, label, (Enum)value),
				SerializedPropertyType.Vector2 => EditorGUI.Vector2Field(position, label, (Vector2)value),
				SerializedPropertyType.Vector3 => EditorGUI.Vector3Field(position, label, (Vector3)value),
				SerializedPropertyType.Vector4 => EditorGUI.Vector4Field(position, label, (Vector4)value),
				SerializedPropertyType.Rect => EditorGUI.RectField(position, label, (Rect)value),
				// missing ArraySize
				SerializedPropertyType.Character => GetCharFromGUI(position, label, (char)value),
				SerializedPropertyType.AnimationCurve => EditorGUI.CurveField(position, label, (AnimationCurve)value),
				SerializedPropertyType.Bounds => EditorGUI.BoundsField(position, label, (Bounds)value),
				SerializedPropertyType.Gradient => EditorGUI.GradientField(position, label, (Gradient)value),
				SerializedPropertyType.Quaternion => GetQuaternionFromGUI(position, label, (Quaternion)value),
				SerializedPropertyType.ExposedReference => EditorGUI.ObjectField(position, label, (UnityEngine.Object)value, propertyInfo.PropertyType, true),
				// missing FixedBufferSize
				SerializedPropertyType.Vector2Int => EditorGUI.Vector2IntField(position, label, (Vector2Int)value),
				SerializedPropertyType.Vector3Int => EditorGUI.Vector3IntField(position, label, (Vector3Int)value),
				SerializedPropertyType.RectInt => EditorGUI.RectIntField(position, label, (RectInt)value),
				SerializedPropertyType.BoundsInt => EditorGUI.BoundsIntField(position, label, (BoundsInt)value),
				SerializedPropertyType.ManagedReference => EditorGUI.ObjectField(position, label, (UnityEngine.Object)value, propertyInfo.PropertyType, true),
				// missing Hash128
				_ => throw new NotImplementedException("Unsupported property type '" + property.propertyType + "'."),
			};
		}

		private static char GetCharFromGUI(Rect position, GUIContent label, char value) {
			string input = EditorGUI.TextField(position, label, value.ToString());

			return input.Length > 0 ? input[0] : '\0';
		}

		private static Quaternion GetQuaternionFromGUI(Rect position, GUIContent label, Quaternion value) {
			return Quaternion.Euler(EditorGUI.Vector3Field(position, label, value.eulerAngles));
		}
	}
#endif
}