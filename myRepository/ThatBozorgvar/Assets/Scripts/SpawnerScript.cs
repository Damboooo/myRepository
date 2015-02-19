using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	
	public Transform platform;
	public Transform tigh;
	private float xPosition=10f;
	private bool wasItTigh=false;
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", 1, 1);
	}
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		float x;
		float i;
		i = Random.Range (0f, 1.3f);

		xPosition += i;
		x = Random.Range (0f, 6f);
		if (x >= 5) {
			if (!wasItTigh){
				xPosition += 0.8f;


			Instantiate (tigh, new Vector3 (xPosition, -3, 0), new Quaternion (0, 0, 0, 0));
			wasItTigh = true;
			}
		} else {
			if (!wasItTigh)
				xPosition += 2;
			else
				xPosition += 0.8f;
			Instantiate (platform, new Vector3 (xPosition, -3, 0), new Quaternion (0, 0, 0, 0));
			wasItTigh=false;
		}
	}
}