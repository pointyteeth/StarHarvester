﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(false) { // if something is selected
			Debug.Log("lol");
		}
	}

	public void SetDriftTarget(GameObject target) {
		Debug.Log(target);
	}
}
