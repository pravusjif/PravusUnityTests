using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {
	public Vector3[] newVertices;

	void Start() {
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = newVertices;
	}
}
