using UnityEngine;
using System.Collections;

public class hurdleMovement : MonoBehaviour
{
	private Vector3 position;
	private Vector3 rotation;
	public GameObject prefab_hurdles;
	public GUIText distanceText;
	
	int velocity = 1; 
	int spawnRate;
	int counter = 30;
	int distance = 0;
	
	// Use this for initialization
	void Start ()
	{
		spawnRate = velocity * 90;
	}
	
	// Update is called once per frame
	void Update ()
	{
		distanceText.text = "Distance: " + distance;
		
		counter--;
		
		if(counter < 0)
		{
			velocity++;
			if(velocity > 10)
				velocity = 10;
			distance += velocity;
			counter = 30;
		}
		
		spawnRate--;
		if (spawnRate < 0)
		{
			position = new Vector3(29, -3, 316);
			Instantiate(prefab_hurdles, position, new Quaternion(0, 0, 180, 0));
			spawnRate = velocity * 90;
		}	
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "prefab_hurdle(Clone)")
		{
			velocity -= 3;
			if(velocity < 0)
				velocity = 0;
			Destroy(col.gameObject);
		}
	}
}
