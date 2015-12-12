using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Interact : MonoBehaviour, IPointerEnterHandler {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerEnter(PointerEventData eventData) {
		player.GetComponent<PlayerMovement>().SetDriftTarget(this.gameObject);
	}
}
