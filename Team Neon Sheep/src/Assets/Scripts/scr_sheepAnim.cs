using UnityEngine;
using System.Collections;

public class scr_sheepAnim : MonoBehaviour
{
	public Material[] frames;
	int currentFrame;
	int frameTimer = 50;
	
	void Update ()
	{
		frameTimer--;
		
		if(frameTimer == 0)
		{
			if(currentFrame == 2)
				currentFrame = 0;
			else
				currentFrame++;
					
			renderer.material = frames[currentFrame];
			frameTimer = 50;
		}
	}
}
