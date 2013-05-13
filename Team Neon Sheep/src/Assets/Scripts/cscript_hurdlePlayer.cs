using UnityEngine;
using System.Collections;

public class cscript_hurdlePlayer : MonoBehaviour
{
	public Material[] frames;
	int currentFrame;
	int frameTimer = 30;
	
	bool isGrounded = true;
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "ground")
		{
			isGrounded = true;
		}
	}

	void Update ()
	{
		frameTimer--;
		
		if(frameTimer < 0)
		{
			if(currentFrame == 2)
				currentFrame = 0;
			else
				currentFrame++;
			
			frameTimer = 30;
			renderer.material = frames[currentFrame];
		}
		
		if(Input.GetKey(KeyCode.Space))
		{
			if(isGrounded)
			{
				rigidbody.AddForce(0, 750, 0);
				isGrounded = false;
			}
		}
		
		if(Input.GetKey(KeyCode.P))
		{
			Application.LoadLevel("Main Scene");
		}
	}
}