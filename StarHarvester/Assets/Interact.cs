using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Interact : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	GameObject player;
	Rigidbody rigidbody;
	Renderer renderer;
	public float minGlowPower;
	public float maxGlowPower = 0.3f;
	float focusDistance;
	public bool focused;
	float glowStartTime;
	public float glowFadeTime;
	public bool harvested = false;
	public float harvestTime;
	float harvestStartTime;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		renderer = GetComponent<Renderer>();
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		focusDistance = player.GetComponent<PlayerMovement>().focusDistance;
	}

	// Update is called once per frame
	void Update () {
		if(Time.time - glowStartTime < glowFadeTime) {
			if(focused) {
				renderer.material.SetFloat("_MKGlowPower",
					Mathf.Lerp(
						minGlowPower,
						maxGlowPower,
						Mathf.Clamp((Time.time - glowStartTime)/glowFadeTime, 0f, 1f)
				));
			} else {
				renderer.material.SetFloat("_MKGlowPower",
					Mathf.Lerp(
						minGlowPower,
						maxGlowPower,
						Mathf.Clamp((Time.time - glowStartTime)/glowFadeTime, 0f, 1f)
				));
			}
		}
		if(harvested) {
			// speed up rotation
			// shrink
			// effects
			// remove self
			if(Time.time - harvestStartTime > harvestTime) {

			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData) {
		if((player.transform.position - transform.position).magnitude < player.GetComponent<PlayerMovement>().focusDistance) {
			player.GetComponent<PlayerMovement>().SetDriftTarget(this.gameObject);
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		player.GetComponent<PlayerMovement>().SetDriftTarget(null);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject == player) {
			focused = true;
			glowStartTime = Time.time;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject == player) {
			focused = false;
			glowStartTime = Time.time;
		}
	}

	public void Harvest() {
		harvestStartTime = Time.time;
		harvested = true;
	}
}
