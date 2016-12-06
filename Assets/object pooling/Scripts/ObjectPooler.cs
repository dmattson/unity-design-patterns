using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPooler : MonoBehaviour {

	public int PoolSize = 10;
	public int MaxPoolSize = 100;

	public GameObject ObjectToPool;
    public Text DebugText;

	List<GameObject> pool = new List<GameObject>();

	// Use this for initialization
	void Awake () {
		InitializePool ();
	}
	
	// Update is called once per frame
	void Update () {
        DebugUpdate();
	}

	void InitializePool()
	{
		for (int i = 0; i < PoolSize; i++) 
		{
			GameObject obj = CreateObject(Vector3.zero, Quaternion.identity);
			obj.SetActive (false);
		}
	}

	public GameObject SpawnObject(Vector3 position, Quaternion rotation)
	{
		GameObject result = null;
		for (int i = 0; i < pool.Count; i++) 
		{
			if (!pool [i].activeSelf) 
			{
				pool[i].GetComponent<BallLifeSpan> ().StartPos = position;
				pool [i].transform.position = position;
				pool [i].SetActive (true);
				return pool [i];
			}
		}

		if (result == null && pool.Count < MaxPoolSize) 
		{
			result = CreateObject (position, rotation);
			result.GetComponent<BallLifeSpan> ().StartPos = position;
		}
		return result;
	}

	public GameObject CreateObject(Vector3 position, Quaternion rotation)
	{
		GameObject obj = GameObject.Instantiate (ObjectToPool, position, rotation);

		pool.Add (obj);
        NumberObject(obj, pool.IndexOf(obj));
        obj.transform.parent = gameObject.transform;
		return obj;
	}

    private void DebugUpdate()
    {
        DebugText.text = "Balls Spawned: " + pool.Count;
    }

    private void NumberObject(GameObject obj, int number)
    {
        Color textColor;
        TextMesh textMesh = obj.GetComponentInChildren<TextMesh>();
        if( number < MaxPoolSize * 0.5f)
        {
            textColor = Color.green;
        }
        else if (number < MaxPoolSize * 0.75f)
        {
            textColor = Color.yellow;
        }
        else
        {
            textColor = Color.red;
        }
        textMesh.text = number.ToString();
        //textMesh.color = textColor;
        obj.GetComponent<Renderer>().material.color = textColor;
    }
}
