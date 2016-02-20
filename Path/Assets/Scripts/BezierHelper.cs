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
			int inc = 10;
			float length = 0f;
			for (int i = 0; i < inc; i++)
			{
				float t = i / (float)inc;
				var t1 = 1f - t;
				var t1_3 = t1 * t1 * t1;
				var t1_3a = (3 * t) * (t1 * t1);
				var t1_3b = (3 * (t * t) * t1);
				var t1_3c = t * t * t;

				Vector2 pt = new Vector2();
				pt = (t1_3 * p0) + (t1_3a * p1) + (t1_3b * p2) + (t1_3c * p3);
				length += pt.magnitude;
			}

			return length;
		}
	}
}
