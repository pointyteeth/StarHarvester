using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rigidbody;
	GameObject driftTarget;
	public float driftSpeed;
	public float focusDistance;
	public float hoverDistance; // how far away you are when you're focused on an object
	public float hoverDistanceMargin;
	public float thrustSpeed;
	public float maxSpeed;
	public float slowDownTime;
	public float maxDistance;
	int starsHarvested = 0;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

		if(driftTarget != null) {
			if((driftTarget.transform.position - transform.position).magnitude > hoverDistance) {
				transform.position = Vector3.MoveTowards(
					transform.position,
					driftTarget.transform.position,
					driftSpeed*driftTarget.GetComponent<Rigidbody>().mass*Time.deltaTime
				);
			} else {
				//this.rigidbody.velocity = Vector3.zero;
				SlowDown();
			}
		}

		if(Input.GetButtonDown("Fire1")) {
			if(driftTarget != null) {
				Interact interactScript = driftTarget.GetComponent<Interact>();
				if(interactScript.focused) {
					interactScript.Harvest();
					starsHarvested++;
				}
			}
			//this.rigidbody.velocity = Vector3.zero;
			this.rigidbody.AddForce(transform.GetChild(0).forward*thrustSpeed);
		}

		this.rigidbody.velocity = Vector3.ClampMagnitude(this.rigidbody.velocity, maxSpeed);
		if(transform.position.magnitude > maxDistance) {
			SlowDown();
		}
	}

	public void SetDriftTarget(GameObject target) {
		this.rigidbody.velocity = Vector3.zero;
		driftTarget = target;
	}

	public void SlowDown() {
		rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, slowDownTime);
	}

}
