using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GeneratorCS : MonoBehaviour {
    public GameObject prefab;
    public int size = 25;

    List<Vector2> generationList = new List<Vector2>();
    //bool[,] map;

    void Start()
    {
        //map = new bool[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                generationList.Add(new Vector2(x,y));
            }
        }

        StartCoroutine("Generate");
    }

    void Generate()
    {
        Vector2 currentVector;

        while (generationList.Count != 0)
        {
            // grab a random vector2 from our grid
            currentVector = generationList[Random.Range(0, generationList.Count)];

            // create a cube in that position
            GenerateTile(currentVector);

            // remove that position from our grid
            generationList.Remove(currentVector);
        }
    }

    void GenerateTile(Vector2 vc2)
    {
        // change the vc2 to vc3 and move it to the center
        Vector3 pos = Vector3.zero;
        pos.x = vc2.x - (size / 2);
        pos.z = vc2.y - (size / 2);

        GameObject spawnedTile = Instantiate(prefab, pos, prefab.transform.rotation) as GameObject;

        // Set the spectrum index of the Cube according to its distance to the center of the grid (vector3.zero in space)
        float distIndex = Vector3.Distance(pos, Vector3.zero) - 0.25f;
        spawnedTile.GetComponent<SpectrumControllerCS>().spectrumIndex = (int)distIndex;
    }
}
