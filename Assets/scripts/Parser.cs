﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Parser : MonoBehaviour {

	string currentWord;
	public Transform parserPlaceHolder;
	public string parserInputText;
	public Transform parserInputTextObject;
	public Transform parser;
	InputField inputField;
	bool canType = true;
	int randomWord;
	public DumbAssController playerScript;
	public GameObject playerController;
	string[] pelitStuff = new string[] {"mignon", "kylkiasento", "suojaunmatch", "massaman", "kaduria", "rypäleet", "balettisplitti", "munaton sankari", "kaljamaha", "superselitys", "5-vuotta", "ponikuva", "automaatio", "maito", "batang", "lapset scifissä", "ajankohtaista asiaa", "kagonen", "86", "rokotti vouhotus", "tusee", "korvatipat", "löfä", "mihin sitä tarttoo", "tinki", "tsop", "balrogin siivet", "tiikerin torni liian edessä", "maantiepoliisiksi arizonaan", "kukri", "satama-allas", "pikkuvirkamies", "edge maverick", "rei daisuki", "mä haluisin pelaa", "korvatippojen merkki", "nintendokansi", "lähde", "juuh okei", "robusti konstruktio", "jonnelin noob klaaniin", "suomi ilmiö", "syylliset on helppo löytää", "pelit-brändi", "ässä pettää aina", "nauru ja huumori kuvat", "leijuke", "munake", "waifutyyny hanuri", "vitsi on siis siinä", "lisää mammuttitankkeja"};

	void Awake () {
		//InvokeRepeating("SlowUpdateN", 0, 0.1F); //This also seems to work only from Awake.
	}

	// Use this for initialization
	void Start () {
		playerController = GameObject.Find("Character"); //This is how you reference another script
		playerScript = playerController.GetComponent<DumbAssController>(); // Seriously, no other way
		parser = this.gameObject.transform.GetChild(0);
		parserPlaceHolder = this.gameObject.transform.GetChild(0).GetChild(0);
		parserInputTextObject = this.gameObject.transform.GetChild(0).GetChild(1);
		inputField = parser.GetComponent<InputField>();

		randomWord = Random.Range(0, pelitStuff.Length);
		currentWord = pelitStuff[randomWord];
		parserPlaceHolder.GetComponent<Text>().text = currentWord;
	}

	// Update is called once per frame
	//void SlowUpdateN () {
	void Update () {
		if (Input.GetKeyUp("return")) {
			if (canType) {
				inputField.interactable = true;
				inputField.ActivateInputField(); // Activates the input field when you press enter
				canType = false;
			} else {
				SpellCheck();
			}
		}
	}

	public void SpellCheck () {
		//Debug.Log("canShoot " + playerScript.canShoot);
		//Debug.Log("canType " + canType);
		parserInputText = parserInputTextObject.GetComponent<Text>().text;
		Debug.Log(parserInputText);
		if(parserInputText == currentWord) {
			playerScript.canShoot = true;
		} else {
			//Make a sound or something
		}
		randomWord = Random.Range(0, pelitStuff.Length);
		currentWord = pelitStuff[randomWord];
		parserPlaceHolder.GetComponent<Text>().text = currentWord;
		inputField.DeactivateInputField(); // Deactivates the input field
		inputField.text = "";
		canType = true;
		inputField.interactable = false;
	}
}