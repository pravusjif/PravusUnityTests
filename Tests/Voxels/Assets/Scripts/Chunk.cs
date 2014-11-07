using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk : MonoBehaviour {
	public List<Vector3> newVertices = new List<Vector3>();
	public List<int> newTriangles = new List<int>();
	public List<Vector2> newUV = new List<Vector2>();
	public List<Vector3> colliderVertices = new List<Vector3>();
	public List<int> colliderTriangles = new List<int>();

	Mesh mesh;
	MeshCollider meshCollider;
	float tileUnit = 0.25f;
	Vector2 tileStone = new Vector2(1, 0);
	Vector2 tileGrass = new Vector2(0, 1);
	int faceCount = 0;

	void Start () {
		mesh = GetComponent<MeshFilter>().mesh;
		meshCollider = GetComponent<MeshCollider>();

		CubeTop(0, 0, 0, 0);
		CubeBottom(0, 0, 0, 0);
		CubeBack(0, 0, 0, 0);
		CubeFront(0, 0, 0, 0);
		CubeLeftSide(0, 0, 0, 0);
		CubeRightSide(0, 0, 0, 0);
		UpdateMesh();
	}
	
	void CubeTop(int x, int y, int z, byte block){
		newVertices.Add(new Vector3 (x,  y,  z + 1));
		newVertices.Add(new Vector3 (x + 1, y,  z + 1));
		newVertices.Add(new Vector3 (x + 1, y,  z ));
		newVertices.Add(new Vector3 (x,  y,  z ));
		
		Vector2 texturePos;
		texturePos = tileStone;

		Cube(texturePos);
	}

	void CubeBottom(int x, int y, int z, byte block){
		newVertices.Add(new Vector3 (x,  y-1,  z ));
		newVertices.Add(new Vector3 (x + 1, y-1,  z ));
		newVertices.Add(new Vector3 (x + 1, y-1,  z + 1));
		newVertices.Add(new Vector3 (x,  y-1,  z + 1));
		
		Vector2 texturePos;
		texturePos = tileStone;
		
		Cube(texturePos);
	}

	void CubeBack(int x, int y, int z, byte block){
		newVertices.Add(new Vector3 (x + 1, y-1, z + 1));
		newVertices.Add(new Vector3 (x + 1, y, z + 1));
		newVertices.Add(new Vector3 (x, y, z + 1));
		newVertices.Add(new Vector3 (x, y-1, z + 1));
		
		Vector2 texturePos;
		texturePos = tileStone;
		
		Cube(texturePos);
	}

	void CubeFront(int x, int y, int z, byte block){
		newVertices.Add(new Vector3 (x, y - 1, z));
		newVertices.Add(new Vector3 (x, y, z));
		newVertices.Add(new Vector3 (x + 1, y, z));
		newVertices.Add(new Vector3 (x + 1, y - 1, z));
		
		Vector2 texturePos;
		texturePos = tileStone;
		
		Cube(texturePos);
	}

	void CubeLeftSide(int x, int y, int z, byte block){
		newVertices.Add(new Vector3 (x, y- 1, z + 1));
		newVertices.Add(new Vector3 (x, y, z + 1));
		newVertices.Add(new Vector3 (x, y, z));
		newVertices.Add(new Vector3 (x, y - 1, z));
		
		Vector2 texturePos;
		texturePos = tileStone;
		
		Cube(texturePos);
	}

	void CubeRightSide(int x, int y, int z, byte block){
		newVertices.Add(new Vector3 (x + 1, y - 1, z));
		newVertices.Add(new Vector3 (x + 1, y, z));
		newVertices.Add(new Vector3 (x + 1, y, z + 1));
		newVertices.Add(new Vector3 (x + 1, y - 1, z + 1));
		
		Vector2 texturePos;
		texturePos = tileStone;
		
		Cube(texturePos);
	}

	void Cube(Vector2 texturePos){
		newTriangles.Add(faceCount * 4  ); //1
		newTriangles.Add(faceCount * 4 + 1 ); //2
		newTriangles.Add(faceCount * 4 + 2 ); //3
		newTriangles.Add(faceCount * 4  ); //1
		newTriangles.Add(faceCount * 4 + 2 ); //3
		newTriangles.Add(faceCount * 4 + 3 ); //4

		newUV.Add(new Vector2 (tileUnit * texturePos.x + tileUnit, tileUnit * texturePos.y));
		newUV.Add(new Vector2 (tileUnit * texturePos.x + tileUnit, tileUnit * texturePos.y + tileUnit));
		newUV.Add(new Vector2 (tileUnit * texturePos.x, tileUnit * texturePos.y + tileUnit));
		newUV.Add(new Vector2 (tileUnit * texturePos.x, tileUnit * texturePos.y));

		faceCount++;
	}

	void UpdateMesh(){
		mesh.Clear ();
		mesh.vertices = newVertices.ToArray();
		mesh.uv = newUV.ToArray();
		mesh.triangles = newTriangles.ToArray();
		mesh.Optimize ();
		mesh.RecalculateNormals ();
		
		newVertices.Clear();
		newUV.Clear();
		newTriangles.Clear();
		
		faceCount=0;
	}
}
