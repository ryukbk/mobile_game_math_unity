using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Assertions;

public class Chapter06 : MonoBehaviour {

	private GameObject cube;

	private float cubeRotationTime;
	
	private Quaternion cubeRotationFrom;
	private Quaternion cubeRotationTo;

	private bool spinning = true;
	private bool rotating;

	// Use this for initialization
	void Start () {
		cube = GameObject.Find("Cube");
	}

	// Update is called once per frame
	void Update () {
		if (spinning) {
			Quaternion cubeSpinRotation = Quaternion.AngleAxis (-180.0f, Vector3.up);
			cube.transform.rotation = Quaternion.Slerp (cube.transform.rotation, cubeSpinRotation, 0.05f);
		}

		Quaternion cameraRotation = Quaternion.LookRotation(cube.transform.position + new Vector3(0, 0.5f, 0) - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, Time.deltaTime);
		transform.Translate(0.02f, 0.005f, 0.5f * Time.deltaTime);

		if (rotating)	{
			cubeRotationTime += Time.deltaTime / 0.5f;
			cube.transform.rotation = Quaternion.Slerp(cubeRotationFrom, cubeRotationTo, cubeRotationTime);

			if (cubeRotationTime >= 1.0f) {
				rotating = false;
				cubeRotationTime = 0;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				ResetCubeRotation (Vector3.right);
				rotating = true;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				ResetCubeRotation (Vector3.left);
				rotating = true;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				ResetCubeRotation (Vector3.forward);
				rotating = true;
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				ResetCubeRotation (Vector3.back);
				rotating = true;
			}
		}
	}

	public class QuaternionComparer : IEqualityComparer<Quaternion>
	{
		public bool Equals(Quaternion lhs, Quaternion rhs) {
			return lhs == rhs;
		}

		public int GetHashCode(Quaternion obj) {
			return obj.GetHashCode();
		}
	}

	void ResetCubeRotation (Vector3 axis) {
		spinning = false;
		cubeRotationFrom = cube.transform.rotation;

		Quaternion q = Quaternion.AngleAxis(90.0f, Quaternion.Inverse(cubeRotationFrom) * axis);
		cubeRotationTo = cubeRotationFrom * q;

		Assert.IsTrue(Quaternion.Inverse(cubeRotationFrom) * axis == cube.transform.InverseTransformVector(axis));
		Assert.AreEqual<Quaternion>(cubeRotationFrom * q, Quaternion.AngleAxis(90.0f, axis) * cubeRotationFrom, null, new QuaternionComparer());
	}
}

