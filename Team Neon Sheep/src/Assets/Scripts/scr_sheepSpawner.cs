using UnityEngine;
using System.Collections;

public class scr_sheepSpawner : MonoBehaviour
{
	public GameObject sheep;
	private Vector3 position;
	private int timer = 70;
	
	// Update is called once per frame
	void Update ()
	{
		timer--;
		
		if(timer < 0)
		{
			if(Random.Range(0, 10) > 6)
			{
				position = new Vector3(Random.Range(-5, 5), 0.3f, 16);
				Instantiate(sheep, position, Quaternion.identity);
			}
			timer = 100;
		}
	}
}
