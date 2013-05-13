using UnityEngine;
using System.Collections;

public class scr_playerAxeThrow : MonoBehaviour
{
	public Material[] wheelMaterials;
	public Material noAxe;
	public GameObject ButtonWheel;
	public GameObject gameCamera;
	public GameObject axe;
	public GameObject viking;
	public GUIText scoreText;
	public GUIText speedText;
	public GUIText endGameText;
	
	float buttonTimer = 30.0f;
	int currentButtonValue = 0;
	string currentButton = "w";
	
	int releaseTimer = 700;
	int vikingTimer = 200;
	int speedDownTimer = 20;
	int endCounter = 0;
	
	float spinSpeed = 0.0f;
	float axeSpeed = 0;
	int consecutivePresses = 0;
	bool buttonPressed = false;
	bool axeReleased = false;
	
	string[] buttons = new string[] { "w", "e", "d", "x", "z", "a" };
	
	void Update () 
	{
		if(!axeReleased)
		{
			// Button wheel updates
			buttonTimer--;
			if(buttonTimer == 0)
			{
				buttonTimer = 30 - (consecutivePresses / 3);
			
				if(currentButtonValue == 5)
					currentButtonValue = 0;
				else
					currentButtonValue++;
			
				ButtonWheel.renderer.material = wheelMaterials[currentButtonValue];
				currentButton = buttons[currentButtonValue];
			
				if(buttonPressed == false)
				{
					consecutivePresses = 0;
					spinSpeed -= 0.5f;
					if(spinSpeed < 0)
						spinSpeed = 0;
						

				}
				else
					buttonPressed = false;
				}
		
			if((Input.GetKey(currentButton)) && (!buttonPressed))
			{
				if(consecutivePresses < 20)
					consecutivePresses++;
				spinSpeed = 0.1f * consecutivePresses;
				consecutivePresses++;
				buttonPressed = true;
				ButtonWheel.particleEmitter.Emit(10);
			}
			else if(Input.anyKey && (!buttonPressed))
			{
				spinSpeed -= 0.01f;
				if(spinSpeed < 0)
					spinSpeed = 0;
				consecutivePresses = 0;
			}
		}
		
		// Player updates
		transform.Rotate(new Vector3(0, spinSpeed + consecutivePresses, 0));
		
		// Release Timer Updates
		releaseTimer--;
		
		if((releaseTimer == 0) && (!axeReleased))
		{
			if(spinSpeed != 0)
				axeSpeed = ((int)spinSpeed + 1) * 3;
			else
				axeSpeed = 0;
			renderer.material = noAxe;
			axe.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 0.5f);
			axeReleased = true;
		}
		
		if(axeReleased)
		{
			if(axeSpeed > 0)
			{
				if(axe.transform.position.z < 20)
				{
					axe.transform.position += new Vector3(0, 0, 0.5f);
					gameCamera.transform.position += new Vector3(0, 0, 0.5f);
				}
			
				axe.transform.Rotate(new Vector3(0, 6, 0));
				
				vikingTimer--;
				if(vikingTimer < 0)
				{
					vikingTimer = 300;
					Instantiate(viking, new Vector3(Random.Range(-7, 7), -52, 40), Quaternion.identity);
				}
			
				if(Input.GetKey(KeyCode.LeftArrow))
				{				
					if(axe.transform.position.x > -17)
						axe.transform.position += new Vector3(-0.3f, 0, 0);
				}
				if(Input.GetKey(KeyCode.RightArrow))
				{
					if(axe.transform.position.x < 17)
						axe.transform.position += new Vector3(0.3f, 0, 0);
				}
							
				speedDownTimer--;
				if(speedDownTimer == 0)
				{
					speedDownTimer = 20;
					axeSpeed -= 0.1f;
				}
				
				speedText.text = "Speed: " + axeSpeed;
			}
			
			if(axeSpeed <= 0)
			{
				axeSpeed = 0;
				endGameText.text = "End!";
				endCounter++;
			}
			if(endCounter == 100)
			{
				Application.LoadLevel("Main Scene");
			}
		}
	}
}