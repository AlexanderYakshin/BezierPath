using UnityEditor;
using UnityEngine;

namespace BezierPath.Editor
{
	[CustomEditor(typeof(Line))]
	public class LineInspector : UnityEditor.Editor
	{
		private void OnSceneGUI()
		{
			Line line = target as Line;
			if (line == null)
				return;

			Transform handleTransform = line.transform;
			Vector3 p0 = handleTransform.TransformPoint(line.P0);
			Vector3 p1 = handleTransform.TransformPoint(line.P1);
			Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local 
				? handleTransform.rotation
				: Quaternion.identity;

			Handles.color = Color.white;
			Handles.DrawLine(p0, p1);

			EditorGUI.BeginChangeCheck();
			p0 = Handles.DoPositionHandle(p0, handleRotation);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(line, "Move Point");
				EditorUtility.SetDirty(line);
				line.P0 = handleTransform.InverseTransformPoint(p0);
			}
			EditorGUI.BeginChangeCheck();
			p1 = Handles.DoPositionHandle(p1, handleRotation);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(line, "Move Point");
				EditorUtility.SetDirty(line);
				line.P1 = handleTransform.InverseTransformPoint(p1);
				EditorUtility.SetDirty(line);
			}
		}
	}
}
