using UnityEngine;
using System.Collections;

public class CycleLightColor : MonoBehaviour {

	Light light;
	public Color[] targets;
	int targetIndex = 0;
	public float cycleTime;
	float startTime;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {

		if(Time.time - startTime > cycleTime) {
			targetIndex = (targetIndex + 1)%targets.Length;
			startTime = Time.time;
		}

		light.color = Color.Lerp(light.color, targets[targetIndex], (Time.time - startTime)/cycleTime);

	}
}
