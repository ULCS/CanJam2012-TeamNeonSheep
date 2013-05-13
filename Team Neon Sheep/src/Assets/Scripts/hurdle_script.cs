using UnityEngine;
using System.Collections;

public class hurdle_script : MonoBehaviour 
{
	public Material[] frames;
	int timer = 13;
	int currentFrame = 0;
	
	// Update is called once per frame
	void Update ()
	{
		timer--;
		if (timer <= 0)
		{
			currentFrame++;
			if (currentFrame > 2)
			{
				currentFrame = 0;
			}
			timer = 13;
			gameObject.renderer.material = frames[currentFrame];
		} 
	}
}
