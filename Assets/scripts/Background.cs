using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public Transform targetCamera;
	float parallaxFactor = 1.05f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (targetCamera.position.x/parallaxFactor + 6.5f, targetCamera.position.y, 0);
	}
}
