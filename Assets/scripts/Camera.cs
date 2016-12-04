using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public DumbAssController playerScript;
	public GameObject playerController;
	public Transform player;
	// Use this for initialization
	void Start () {
		playerController = GameObject.Find("Character"); //This is how you reference another script
		playerScript = playerController.GetComponent<DumbAssController>(); // Seriously, no other way
	}

	// Update is called once per frame
	void Update () {
		if (player) {
			transform.position = new Vector3 (player.position.x, player.position.y +2.5f, -5);
		} else {

		}
		if (playerScript.canShoot) {
			this.gameObject.transform.Find("napoleon3").gameObject.SetActive(true);
		} else {
			this.gameObject.transform.Find("napoleon3").gameObject.SetActive(false);
		}
	}
}
