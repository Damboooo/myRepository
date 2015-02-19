using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

	public Transform coinPrefab;
	// Use this for initialization
	private float xPosition=11;
	void Start () {
		InvokeRepeating ("Spawn", 1, 0.4f);
	}
	void Spawn(){
		float i, j;
		i = Random.Range (0, 4);
		j = Random.Range (-2, 0);
		xPosition += i;
		Instantiate (coinPrefab, new Vector3 (xPosition, j, 0), new Quaternion (0, 0, 0,0));
	}
	// Update is called once per frame

}
