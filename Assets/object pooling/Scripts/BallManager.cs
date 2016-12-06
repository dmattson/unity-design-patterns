using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	public float SpawnFrequencyInSeconds = 1f;

	public GameObject ObjectPooler;

	// Use this for initialization
	void Start () {
		StartCoroutine (BallFactoryLoop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator BallFactoryLoop()
	{
		while (true) 
		{
			ObjectPooler.GetComponent<ObjectPooler>().SpawnObject(gameObject.transform.position, gameObject.transform.rotation);
			yield return new WaitForSeconds (SpawnFrequencyInSeconds);
		}
	}
}
