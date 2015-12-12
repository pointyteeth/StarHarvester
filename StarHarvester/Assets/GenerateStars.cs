using UnityEngine;
using System.Collections;

public class GenerateStars : MonoBehaviour {

	public GameObject star;
	public int starCount;
	public float minStarDistance;
	public float maxStarDistance;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < starCount; i++) {
			GameObject newStar = (GameObject) Instantiate(star,
				Random.onUnitSphere*Random.Range(minStarDistance, maxStarDistance), // make a unit Vector3 with a random direction, then multiply it by a random distance between minStarDistance and maxStarDistance
				Random.rotation); // rotation is also random
			newStar.name = star.name + " " + i;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
