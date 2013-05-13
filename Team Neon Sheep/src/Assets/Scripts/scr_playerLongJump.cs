using UnityEngine;
using System.Collections;

public class scr_playerLongJump : MonoBehaviour
{
	public GameObject buttonBox;
	public GUIText distanceText;
	public Material[] buttonBoxTextures;
	public Material[] jumpFrames;
	public Material[] groundFrames;
	
	bool onGround = true;
	bool isAnim = true;
	bool sheepCol = false;
	bool offPlatform = false;
	int currentFrame = 0;
	
	int frameTimer = 40;
	float buttonTimer = 20.0f;
	int currentButtonValue = 0;
	string currentButton = "a";
	bool buttonPressed = false;
	bool jump = false;
	
	int distance = 0;
	
	int endCounter = 0;
	
	float velocity = 0.0f;
	
	string[] buttons = new string[] { "a", "d" };
	
	void Update () 
	{
		if(sheepCol)
			isAnim = false;
		
		if(isAnim)
		{
			frameTimer--;
			buttonTimer--;
		}
		
		if((!sheepCol) && (!offPlatform))
		{
			if(!buttonPressed)
			{
				if(Input.GetKey(currentButton))
				{
					buttonPressed = true;
					velocity += 0.1f;
					buttonBox.particleEmitter.Emit(10);
					if(velocity > 15)
						velocity = 15;
				}
				else if(Input.anyKey)
				{
					velocity -= 0.01f;
					if(velocity < 0)
						velocity = 0;
				}
			
			}
		}
		
		if(buttonTimer <= 0)
		{
			buttonTimer = 20;
			
			if(currentButtonValue == 1)
				currentButtonValue = 0;
			else
				currentButtonValue++;
			
			currentButton = buttons[currentButtonValue];
			buttonBox.renderer.material = buttonBoxTextures[currentButtonValue];
			
			buttonPressed = false;
		}
		
		if(frameTimer <= 0)
		{
			if(currentFrame == 3)
				currentFrame = 0;
			else
				currentFrame++;
			
			if(onGround)
			{
				renderer.material = groundFrames[currentFrame];
			}
			else
			{
				renderer.material = jumpFrames[currentFrame];
			}
			
			frameTimer = 15;
		}
		
		if(onGround)
		{
			gameObject.transform.position += new Vector3(velocity, 0, 0);
			buttonBox.transform.position += new Vector3(velocity, 0, 0);
		}
		
		if((offPlatform) && (!sheepCol))
		{
			distance += 1;
			distanceText.text = "Distance: " + distance;
		}
		
		if((!sheepCol) && (onGround))
		{
			if(Input.GetKey(KeyCode.Space))
			{
				jump = true;
				onGround = false;
				rigidbody.AddForce(new Vector3((velocity + 1) * 500, (velocity + 1) * 365, 0));
			}
		}

		
		if(transform.position.x > 90)
		{
			offPlatform = true;
		}
		if(endCounter == 500)
		{
			Application.LoadLevel("Main Scene");
		}
		if(jump == true)
		{
			endCounter++;
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		
		if(col.gameObject.name == "sheep")
		{
			sheepCol = true;
			onGround = true;
			renderer.material = groundFrames[0];
			isAnim = false;
			velocity = 0;
		}
	}
}
