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
	int starsHarvested = 0;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

		if(driftTarget != null && (driftTarget.transform.position - transform.position).magnitude > hoverDistance) {
			transform.position = Vector3.MoveTowards(
				transform.position,
				driftTarget.transform.position,
				driftSpeed*driftTarget.GetComponent<Rigidbody>().mass*Time.deltaTime
			);
		}

		if(Input.GetButtonDown("Fire1")) {
			if(driftTarget != null) {
				Interact interactScript = driftTarget.GetComponent<Interact>();
				if(interactScript.focused) {
					interactScript.Harvest();
					starsHarvested++;
				}
			} else {
				this.rigidbody.velocity = Vector3.zero;
				this.rigidbody.AddForce(transform.GetChild(0).forward*thrustSpeed);
			}
		}

	}

	public void SetDriftTarget(GameObject target) {
		this.rigidbody.velocity = Vector3.zero;
		driftTarget = target;
	}

}
