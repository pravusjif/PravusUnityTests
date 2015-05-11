using UnityEngine;
using System.Collections;

public class Pool : MonoBehaviour
{
    public GameObject Prefab;
    public int Count = 10;
	public GameObject PoolObjectsParent;

    private GameObject[] objects;
    public int id = 0;

	// Use this for initialization
	void Awake()
    {
        objects = new GameObject[Count];
		PoolCreatedObject pco = null;
		
        for (int i = 0; i < Count; i++)
        {
            objects[i] = GameObject.Instantiate((Object)Prefab) as GameObject;
            objects[i].SetActiveRecursively(false);
			
			if(PoolObjectsParent != null)
			{
				objects[i].transform.parent = PoolObjectsParent.transform;
			}
			
			if(pco = objects[i].GetComponent<PoolCreatedObject>())
			{
				pco.creatorPool = this;
			}
        }
	}

    public GameObject Create()
    {
        return Create(Vector3.zero);
    }

    public GameObject Create(Vector3 pos)
    {
        GameObject go = null;

        if (id < objects.Length)
        {
            go = objects[id];
            id++;

            go.transform.position = pos;
            go.SetActiveRecursively(true);
        }
        else 
        {
            //Debug.LogWarning("The pool is empty!");
        }

        return go;
    }
	
	public GameObject Create(Vector3 pos, Quaternion rot)
    {
        GameObject go = null;

        if (id < objects.Length)
        {
            go = objects[id];
            id++;

            go.transform.position = pos;
			go.transform.rotation = rot;
            go.SetActiveRecursively(true);
        }
        else 
        {
            //Debug.LogWarning("The pool is empty!");
        }

        return go;
    }
	
	public GameObject Create(Vector3 pos, float scale)
    {
        GameObject go = null;

        if (id < objects.Length)
        {
            go = objects[id];
            id++;

            go.transform.position = pos;			
			go.transform.localScale *= scale;
            go.SetActiveRecursively(true);
        }
        else 
        {
            //Debug.LogWarning("The pool is empty!");
        }

        return go;
    }	

    public void Recycle(GameObject go)
    {
        if (id > 0)
        {
            id--;
            objects[id] = go;
            go.SetActiveRecursively(false);
        }
        else
        {
            //Debug.LogWarning("The pool is full!");
        }
    }	
	
	public int GetActiveQuantity()
	{
		return id;	
	}
	
	public bool isPoolempty()
	{
		return (id == Count);
	}
}
