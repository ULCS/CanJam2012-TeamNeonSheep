using UnityEngine;
using System.Collections;

public class scr_player : MonoBehaviour
{
	int sheep = 0;
	public GUIText sheepText;
	public GameObject wheel;
	public GameObject progressSheep;
	public GameObject progressViking;
	public Material[] materials;
	public Material[] animations;
	int currentAnimation = 0;
	float velocity = 0.0f;
	float distance = 0.0f;
	
	float vikingVelocity = 8;
	float vikingDistance = 0;
	
	float currentDistance = 0.0f;
	
	char[] buttonWheel = new char[] { 'w', 'e', 'd', 'x', 'z', 'a' };
	int currentButtonValue = 0;
	char currentButton;
	int consecutivePresses;
	bool buttonPressed;
	
	int travelDistance = 1;
	int vikingTravelDistance = 1;
	
	float buttonTimer = 50.0f;
	
	void Start ()
	{
		sheepText.text = "Sheep: " + sheep;
		currentButton = buttonWheel[0];
	}
	
	void Update ()
	{
		buttonTimer--;
		
		if(!buttonPressed)
		{
			if(Input.GetKey(buttonWheel[currentButtonValue].ToString()))
			{
				if(velocity < 20)
					velocity += (1 * consecutivePresses) + sheep;
				buttonPressed = true;
				consecutivePresses++;
				wheel.particleEmitter.Emit(5);
				if(currentAnimation == 2)
					currentAnimation--;
				else
					currentAnimation++;
				renderer.material = animations[currentAnimation];
			}
		}
		
		if(buttonTimer < 0)
		{
			buttonTimer = 50 - (consecutivePresses * 1.5f);
			currentButtonValue++;
			if(currentButtonValue > 5)
				currentButtonValue = 0;
			currentButton = buttonWheel[currentButtonValue];
			wheel.renderer.material = materials[currentButtonValue];
			if(buttonPressed == true)
			{
				if(consecutivePresses < 20)
					consecutivePresses++;
				buttonPressed = false;
			}
			else
			{
				consecutivePresses = 0;
				velocity = 0;
				if(velocity < 0)
					velocity = 0;
			}
		}
		
		distance += velocity;
		vikingDistance += vikingVelocity;
		
		if(distance >= 10f * travelDistance)
		{
			progressSheep.transform.position += new Vector3(0, 0, 0.01f);
			travelDistance++;
		}
		
		if(vikingDistance >= 10f * vikingTravelDistance)
		{
			progressViking.transform.position += new Vector3(0, 0, 0.01f);
			vikingTravelDistance++;
		}
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(transform.position.x > -5)
				transform.position += new Vector3(-0.1f, 0, 0);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(transform.position.x < 5)
				transform.position += new Vector3(0.1f, 0, 0);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Sheep(Clone)")
		{
			sheep += 1;
			sheepText.text = "Sheep: " + sheep;
			Destroy(col.gameObject);
		}
	}
}