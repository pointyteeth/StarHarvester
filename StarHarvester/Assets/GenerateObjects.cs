using UnityEngine;
using System.Collections;

public class GenerateObjects : MonoBehaviour {

	public GameObject prefab;
	public int count;
	public float minDistance;
	public float maxDistance;
	public float minScale;
	public float maxScale;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < count; i++) {

			GameObject newObject = (GameObject) Instantiate(prefab,
				Random.onUnitSphere*Random.Range(minDistance, maxDistance), // make a unit Vector3 with a random direction, then multiply it by a random distance between minStarDistance and maxStarDistance
				Random.rotation); // rotation is also random
			newObject.name = prefab.name + " " + i;
			newObject.transform.localScale *= Random.Range(minScale, maxScale);

		}
	}

	// Update is called once per frame
	void Update () {

	}
}
