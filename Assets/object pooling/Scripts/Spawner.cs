using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject ObjectToSpawn;

	public Vector3 SpawnOffset;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject SpawnObject()
	{
		return GameObject.Instantiate (ObjectToSpawn, gameObject.transform.position - SpawnOffset, gameObject.transform.rotation);
	}
}
