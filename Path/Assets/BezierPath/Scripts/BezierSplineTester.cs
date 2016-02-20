using UnityEngine;

namespace BezierPath
{
	[RequireComponent(typeof(BezierSpline))]
	public class BezierSplineTester : MonoBehaviour
	{
		[Range(0,1)]
		public float T;
		public GameObject Marker;

		[SerializeField]
		private BezierSpline _bezierSpline;

		private void Awake()
		{
			if (_bezierSpline == null)
			{
				_bezierSpline = GetComponent<BezierSpline>();
			}

			if (Marker == null)
			{
				Marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
				Marker.transform.parent = this.gameObject.transform;
				Marker.transform.localPosition = Vector3.zero;
			}
		}

		private void Update()
		{
			if (_bezierSpline == null)
				return;

			Marker.transform.position = _bezierSpline.GetPoint(T);
		}
	}
}
