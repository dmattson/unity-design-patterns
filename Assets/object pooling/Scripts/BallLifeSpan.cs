using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLifeSpan : MonoBehaviour {

	public Vector3 StartPos;

	public float LifeSpanInSeconds = 5f;

    public float TimeToDestroy = 10f;

	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

	void OnEnable() {
		//print("Ball was enabled");
		GetComponent<Rigidbody> ().isKinematic = false;
		StartCoroutine (LifeSpanLoop ());
	}

	void OnDisable()
	{
		gameObject.transform.position = StartPos;
		GetComponent<Rigidbody> ().isKinematic = true;
		//print("Ball was disabled");
		StopCoroutine (LifeSpanLoop ());
	}

	IEnumerator LifeSpanLoop()
	{
		yield return new WaitForSeconds (LifeSpanInSeconds);
		gameObject.SetActive (false);
	}
}
