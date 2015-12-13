using UnityEngine;
using System.Collections;

public class SwapMesh : MonoBehaviour {

	public Mesh[] meshes;

	// Use this for initialization
	void Start () {
		GetComponent<MeshFilter>().sharedMesh = meshes[Random.Range(0, meshes.Length)];
	}

	// Update is called once per frame
	void Update () {

	}
}
