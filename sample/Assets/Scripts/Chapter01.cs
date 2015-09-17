using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chapter01 : MonoBehaviour {

	private GameObject capsule;

	private float targetAngle = 0f;
	public float capsuleRotationSpeed = 4f;

	private GameObject sphere;
	private float buttonDownTime;

	public float sphereMagnitudeX = 2.0f;
	public float sphereMagnitudeY = 3.0f;
	public float sphereFrequency = 1.0f;

	// Use this for initialization
	void Start () {
		capsule = GameObject.Find("Capsule");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
			Debug.Log (string.Format("mousePosition ({0:f}, {1:f})", Input.mousePosition.x, Input.mousePosition.y));

			targetAngle = GetRotationAngleByTargetPosition(Input.mousePosition);

			if (sphere != null) {
				Destroy(sphere);
				sphere = null;
			}

			sphere = SpawnSphereAt(Input.mousePosition);
			buttonDownTime = Time.time;
		}

		capsule.transform.eulerAngles
			= new Vector3(0, 0, Mathf.LerpAngle(capsule.transform.eulerAngles.z, targetAngle, Time.deltaTime * capsuleRotationSpeed));

		if (sphere != null) {
			sphere.transform.position = new Vector3(sphere.transform.position.x + (capsule.transform.position.x - sphere.transform.position.x) * Time.deltaTime * sphereMagnitudeX,
				Mathf.Abs(Mathf.Sin ((Time.time - buttonDownTime) * (Mathf.PI * 2) * sphereFrequency) * sphereMagnitudeY),
			    0
			);
		}
	}

	float GetRotationAngleByTargetPosition(Vector3 mousePosition) {
		Vector3 selfScreenPoint = Camera.main.WorldToScreenPoint(capsule.transform.position);
		Vector3 diff = mousePosition - selfScreenPoint;
		
		float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

		Debug.Log (string.Format("angle: {0:f}", angle));

		float finalAngle = angle - 90f;

		Debug.Log (string.Format("finalAngle: {0:f}", finalAngle));

		return finalAngle;
	}

	GameObject SpawnSphereAt(Vector3 mousePosition) {
		GameObject sp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Vector3 selfScreenPoint = Camera.main.WorldToScreenPoint(capsule.transform.position);
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, selfScreenPoint.z));
		sp.transform.position = new Vector3(position.x, position.y, 0);
		return sp;
	}
}

