using UnityEngine;
using System.Collections;

public class DriftAroundPlayer : MonoBehaviour {

	Vector3 direction;
	public float maxDistance;
	public float speed;

	// Use this for initialization
	void Start () {
		ChangeDirection();
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.magnitude > maxDistance) {
			ChangeDirection();
		}
		transform.position += direction*speed*Time.deltaTime;
	}

	void ChangeDirection() {
		direction = Random.onUnitSphere;
	}
}
