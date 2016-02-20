using UnityEngine;

namespace BezierPath
{
	public static class BezierHelper
	{
		public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			t = Mathf.Clamp01(t);
			float oneMinusT = 1f - t;
			return
				oneMinusT * oneMinusT * p0 +
				2f * oneMinusT * t * p1 +
				t * t * p2;
		}

		public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			return
				2f * (1f - t) * (p1 - p0) +
				2f * t * (p2 - p1);
		}

		public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			t = Mathf.Clamp01(t);
			float oneMinusT = 1f - t;
			return
				oneMinusT * oneMinusT * oneMinusT * p0 +
				3f * oneMinusT * oneMinusT * t * p1 +
				3f * oneMinusT * t * t * p2 +
				t * t * t * p3;
		}

		public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			t = Mathf.Clamp01(t);
			float oneMinusT = 1f - t;
			return
				3f * oneMinusT * oneMinusT * (p1 - p0) +
				6f * oneMinusT * t * (p2 - p1) +
				3f * t * t * (p3 - p2);
		}

		public static float GetCurveLength(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			int inc = 20;
			float length = 0f;
			var prevPoint = p0;
			for (int i = 1; i < inc; i++)
			{
				float t = i / (float)inc;
				var point = GetPoint(p0, p1, p2, p3, t);
				length += (point - prevPoint).magnitude;
				prevPoint = point;
			}

			return length;
		}
	}
}
