using UnityEngine;
using System.Collections;

public class GentlyRotate : MonoBehaviour {

	Rigidbody rigidbody;
	public float torque;
	public float maxTorque;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		rigidbody.AddTorque(transform.up*torque*Time.deltaTime);
		rigidbody.AddTorque(transform.right*torque*Time.deltaTime);
	}
}
