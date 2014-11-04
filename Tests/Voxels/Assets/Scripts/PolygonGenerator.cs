using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonGenerator : MonoBehaviour {
	public List<Vector3> newVertices = new List<Vector3>();
	public List<int> newTriangles = new List<int>();
	public List<Vector2> newUV = new List<Vector2>();
	public List<Vector3> colliderVertices = new List<Vector3>();
	public List<int> colliderTriangles = new List<int>();
	public byte[,] blocks; // 0 = air; 1 = rock; 2 = grass

	Mesh mesh;
	float tileUnit = 0.25f;
	Vector2 tileStone = new Vector2(0, 0);
	Vector2 tileGrass = new Vector2(0, 1);
	int squareCount;
	int colliderCount;
	MeshCollider meshCollider;

	void Start(){
		mesh = GetComponent<MeshFilter>().mesh;
		meshCollider = GetComponent<MeshCollider>();

		GenerateTerrain();
		BuildMesh();
		UpdateMesh();
	}

	/*void Update(){
		UpdateMesh();
	}*/

	void GenerateSquare(int x, int y, Vector2 texture){
		newVertices.Add(new Vector3(x, y, 0));
		newVertices.Add(new Vector3(x + 1, y, 0));
		newVertices.Add(new Vector3(x + 1, y - 1, 0));
		newVertices.Add(new Vector3(x, y - 1, 0));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4) + 1);
		newTriangles.Add((squareCount*4) + 3);
		newTriangles.Add((squareCount*4) + 1);
		newTriangles.Add((squareCount*4) + 2);
		newTriangles.Add((squareCount*4) + 3);
		
		newUV.Add (new Vector2(tileUnit * texture.x, tileUnit * texture.y + tileUnit));
		newUV.Add (new Vector2(tileUnit * texture.x + tileUnit, tileUnit * texture.y + tileUnit));
		newUV.Add (new Vector2(tileUnit * texture.x + tileUnit , tileUnit * texture.y));
		newUV.Add (new Vector2(tileUnit * texture.x, tileUnit * texture.y));

		squareCount++;
	}

	void GenerateCollider(int x, int y){
		// Top Face Collision
		colliderVertices.Add(new Vector3(x, y, 1));
		colliderVertices.Add(new Vector3(x + 1, y, 1));
		colliderVertices.Add(new Vector3(x + 1, y, 0));
		colliderVertices.Add(new Vector3(x, y, 0));
		
		colliderTriangles.Add(colliderCount*4);
		colliderTriangles.Add((colliderCount*4) + 1);
		colliderTriangles.Add((colliderCount*4) + 3);
		colliderTriangles.Add((colliderCount*4) + 1);
		colliderTriangles.Add((colliderCount*4) + 2);
		colliderTriangles.Add((colliderCount*4) + 3);
		
		colliderCount++;
	}

	void GenerateTerrain(){
		blocks = new byte[10, 10];

		for(int px = 0; px < blocks.GetLength(0); px++){
			for(int py = 0; py < blocks.GetLength(1); py++){
				if(py == 5)
					blocks[px, py] = 2;
				else if(py < 5)
					blocks[px, py] = 1;
			}
		}
	}

	void BuildMesh(){
		for(int px = 0; px < blocks.GetLength(0); px++){
			for(int py = 0; py < blocks.GetLength(1); py++){
				if(blocks[px, py] != 0){
					GenerateCollider(px, py);

					if(blocks[px, py] == 1) // 1 = stone
						GenerateSquare(px, py, tileStone);
					else if(blocks[px, py] == 2) // 2 = grass
						GenerateSquare(px, py, tileGrass);
				}
			}
		}
	}

	void UpdateMesh(){
		// mesh
		mesh.Clear();
		
		mesh.vertices = newVertices.ToArray();
		mesh.triangles = newTriangles.ToArray();
		mesh.uv = newUV.ToArray();
		
		mesh.Optimize();
		mesh.RecalculateNormals();

		squareCount = 0;
		newVertices.Clear();
		newTriangles.Clear();
		newUV.Clear();

		// mesh collider
		Mesh newMesh = new Mesh();
		newMesh.vertices = colliderVertices.ToArray();
		newMesh.triangles = colliderTriangles.ToArray();
		meshCollider.sharedMesh = newMesh;

		colliderVertices.Clear();
		colliderTriangles.Clear();
		colliderCount = 0;
	}
}
