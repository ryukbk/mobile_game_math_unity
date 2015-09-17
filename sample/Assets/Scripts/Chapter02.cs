using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Based on the code at http://wiki.unity3d.com/index.php/SphericalCoordinates with minor refactoring changes.
// This code is under Creative Commons Attribution Share Alike http://creativecommons.org/licenses/by-sa/3.0/

public class Chapter02 : MonoBehaviour {

	public float rotateSpeed = 1f;
	public float scrollSpeed = 200f;

	public Transform pivot;

	[System.Serializable]
	public class SphericalCoordinates
	{
		public float _radius, _azimuth, _elevation;

		public float radius
		{ 
			get { return _radius; }
			private set
			{
				_radius = Mathf.Clamp( value, _minRadius, _maxRadius );
			}
		}

		public float azimuth
		{ 
			get { return _azimuth; }
			private set
			{ 
				_azimuth = Mathf.Repeat( value, _maxAzimuth - _minAzimuth ); 
			}
		}

		public float elevation
		{ 
			get{ return _elevation; }
			private set
			{ 
				_elevation = Mathf.Clamp( value, _minElevation, _maxElevation ); 
			}
		}

		public float _minRadius = 3f;
		public float _maxRadius = 20f;

		public float minAzimuth = 0f;
		private float _minAzimuth;

		public float maxAzimuth = 360f;
		private float _maxAzimuth;

		public float minElevation = 0f;
		private float _minElevation;

		public float maxElevation = 90f;
		private float _maxElevation;
		
		public SphericalCoordinates(){}
		
		public SphericalCoordinates(Vector3 cartesianCoordinate)
		{
			_minAzimuth = Mathf.Deg2Rad * minAzimuth;
			_maxAzimuth = Mathf.Deg2Rad * maxAzimuth;

			_minElevation = Mathf.Deg2Rad * minElevation;
			_maxElevation = Mathf.Deg2Rad * maxElevation;

			radius = cartesianCoordinate.magnitude;
			azimuth = Mathf.Atan2(cartesianCoordinate.z, cartesianCoordinate.x);
			elevation = Mathf.Asin(cartesianCoordinate.y / radius);
		}
		
		public Vector3 toCartesian
		{
			get
			{
				float t = radius * Mathf.Cos(elevation);
				return new Vector3(t * Mathf.Cos(azimuth), radius * Mathf.Sin(elevation), t * Mathf.Sin(azimuth));
			}
		}
		
		public SphericalCoordinates Rotate(float newAzimuth, float newElevation){
			azimuth += newAzimuth;
			elevation += newElevation;
			return this;
		}
		
		public SphericalCoordinates TranslateRadius(float x) {
			radius += x;
			return this;
		}
	}
	
	public SphericalCoordinates sphericalCoordinates;
	
	// Use this for initialization
	void Start () {
		sphericalCoordinates = new SphericalCoordinates(transform.position);
		transform.position = sphericalCoordinates.toCartesian + pivot.position;
	}

	// Update is called once per frame
	void Update () {
		float kh, kv, mh, mv, h, v;
		kh = Input.GetAxis( "Horizontal" );
		kv = Input.GetAxis( "Vertical" );
		
		bool anyMouseButton = Input.GetMouseButton(0) | Input.GetMouseButton(1) | Input.GetMouseButton(2);
		mh = anyMouseButton ? Input.GetAxis( "Mouse X" ) : 0f;
		mv = anyMouseButton ? Input.GetAxis( "Mouse Y" ) : 0f;
		
		h = kh * kh > mh * mh ? kh : mh;
		v = kv * kv > mv * mv ? kv : mv;
		
		if (h * h > Mathf.Epsilon || v * v > Mathf.Epsilon) {
			transform.position
				= sphericalCoordinates.Rotate(h * rotateSpeed * Time.deltaTime, v * rotateSpeed * Time.deltaTime).toCartesian + pivot.position;
		}

		float sw = -Input.GetAxis("Mouse ScrollWheel");
		if (sw * sw > Mathf.Epsilon) {
			transform.position = sphericalCoordinates.TranslateRadius(sw * Time.deltaTime * scrollSpeed).toCartesian + pivot.position;
		}

		transform.LookAt(pivot.position);
	}
}

