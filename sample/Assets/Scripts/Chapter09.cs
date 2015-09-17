using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Assertions;
using System.Runtime.InteropServices;


public class Chapter09 : MonoBehaviour {
	private GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Phong");
	}

	// Update is called once per frame
	void Update () {
		Quaternion targetRotation = Quaternion.LookRotation(
			target.transform.position + new Vector3(0, 0.5f, 0) - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
		transform.Translate(0.02f, 0.005f, 0.5f * Time.deltaTime);
	}
}
