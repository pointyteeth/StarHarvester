using UnityEngine;
using System.Collections;

public class GentlyRotate : MonoBehaviour {

	Rigidbody rb;
	public float torque;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		rb.AddTorque(transform.up*torque);
		rb.AddTorque(transform.right*torque);
	}
}
