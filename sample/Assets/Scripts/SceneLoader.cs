using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	void Awake () {
		float ratio = Mathf.Clamp((float)1024 / Screen.height, 0, 1);
		Screen.SetResolution((int)(Screen.width * ratio), (int)(Screen.height * ratio), true, 60);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load(string name) {
		StartCoroutine(DoLoad(name));
	}

	IEnumerator DoLoad(string name) {
		AsyncOperation async = Application.LoadLevelAsync(name);
		yield return async;
	}
}
