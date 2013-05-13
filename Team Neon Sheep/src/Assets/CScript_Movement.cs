using UnityEngine;
using System.Collections;

public class CScript_Movement : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	int forwardCounter = 0;
	int backwardCounter = 0;
	int direction = 0;
	int spin = 0;
	bool BfinishAttack = false;
	int finishAttack = 0;
	int dodge = 0;
	bool Bdodge = false;
	bool Attack = false;
	bool Damage = false;
	int IEnemyHealth = 100;
	int death = 0;
	
	public Material player_walk1;
	public Material player_walk2;
	public Material player_walk3;
	public Material player_standing;
	public Material player_Leftwalk1;
	public Material player_Leftwalk2;
	public Material player_Leftwalk3;
	public Material player_Leftstanding;
	public Material player_attack_mid1;
	public Material player_attack_mid2;
	public Material player_attack_low1;
	public Material player_attack_low2;
	public Material player_standing_attack;
	public Material player_standing_dodge1;
	public Material player_standing_dodge2;
	public Material player_standing_dodge3;
	public GUIText GEnemyHealth;
	/*public Material player_death1;
	public Material player_death2;
	public Material player_death3;*/
	public GameObject VikingDeath;
	private Vector3 position;
	private Vector3 rotation;
	GameObject door_Rowing;
	public GameObject Viking;
	public GameObject VikingDeath1;
	public GameObject VikingDeath2;
	
	// Update is called once per frame
	void Update () 
	{
			//GEnemyHealth.text = "Enemy Health: " + IEnemyHealth;
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.position += new Vector3(-0.2f,0,0);
				backwardCounter++;
				direction = 0;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.position += new Vector3(0.2f,0,0);
				forwardCounter++;
				direction = 1;
			}
			if(Attack == false)
			{
				if(!Input.anyKey)
				{
					if (direction == 1)
					{
						renderer.material = player_standing;
					}
					if(direction == 0)
					{
						renderer.material = player_Leftstanding;
					}
					{
						Bdodge = false;
					}
				}
			}
			if (forwardCounter == 1)
			{
				renderer.material = player_walk1;
			}
			if (forwardCounter == 10)
			{
				renderer.material = player_walk2;
			}
			if (forwardCounter == 20)
			{
				renderer.material = player_walk3;
			}
			if (forwardCounter == 30)
			{
				forwardCounter = 0;
			}
		
		
			if (backwardCounter == 1)
			{
				renderer.material = player_Leftwalk1;
			}
			if (backwardCounter == 10)
			{
				renderer.material = player_Leftwalk2;
			}	
			if (backwardCounter == 20)
			{
				renderer.material = player_Leftwalk3;
			}
			if (backwardCounter == 30)
			{
				backwardCounter = 0;
			}
			
			if(Input.GetKey(KeyCode.Return))
			{
				if(gameObject.transform.position.x < -30 && gameObject.transform.position.x > -50)
				{
			   		Application.LoadLevel("Rowing");
				}
				if(gameObject.transform.position.x < 10 && gameObject.transform.position.x > -10)
				{
			   		Application.LoadLevel("AxeThrow");
				}
				if(gameObject.transform.position.x < 50 && gameObject.transform.position.x > 30)
				{
			   		Application.LoadLevel("LongJump");
				}
				if(gameObject.transform.position.x < 90 && gameObject.transform.position.x > 70)
				{
			   		Application.LoadLevel("Fencing");
				}
				if(gameObject.transform.position.x < 120 && gameObject.transform.position.x > 100)
				{
					Application.LoadLevel("hurdlesMiniGame");
				}
			}
			if(Input.GetKey(KeyCode.P))
			{
				Application.LoadLevel("Main Scene");
			}
		
			if(Input.GetKey(KeyCode.I))
			{
				Attack = true;
				renderer.material = player_attack_mid2;
				spin = 1;
			}
			if(spin == 1)
			{
				if(Input.GetKey(KeyCode.K))
				{
					renderer.material = player_attack_low2;
					spin = 2;
					Damage = true;
				}
			}
			if(spin == 2)
			{
				if(Input.GetKey(KeyCode.M))
				{
					renderer.material = player_attack_low1;
					BfinishAttack = true;
				}
			}
			if(BfinishAttack == true)
			{
				finishAttack++;
				if(finishAttack >= 25)
				{
				renderer.material = player_standing_attack;
				BfinishAttack = false;
				finishAttack = 0;
				Attack = false;
				Damage = false;
				}
			}
			if(Input.GetKey(KeyCode.Space))
			{
				if(dodge == 0)
				{
					renderer.material = player_standing_dodge1;
				}
				Bdodge = true;
				if(dodge == 20)
				{
					renderer.material = player_standing_dodge2;
				}
				if(dodge == 30)
				{
					renderer.material = player_standing_dodge3;
				}
				if (dodge == 40)
				{
					renderer.material = player_standing_dodge1;
					Bdodge = false;
					dodge = 0;
				}
			}
			
			/*{
				renderer.material = player_standing_attack;
				Bdodge = false;
			}*/
			if(Bdodge == true)
			{
				dodge++;
			}
		
			/*if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				rigidbody.AddRelativeForce(0,-100,0);
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				rigidbody.AddRelativeForce(0,0,-10);
			}*/
		/*if(gameObject.transform.position.x < -22.5 && gameObject.transform.position.x > -17.5)
		{
			transform.position += new Vector3(-1f,0,0);
		}*/
	}
	void OnCollisionEnter(Collision col)
	{
		
		if(col.gameObject.name == "Viking")
		{
			if(Damage == true)
			{
				IEnemyHealth -= 20;
				GEnemyHealth.text = "Enemy Health: " + IEnemyHealth;
			}
			if(IEnemyHealth == 0)
			{
				death++;
				if(death == 1)
				{
					Destroy(Viking);
					//transform.position += new Vector3(-20f,7.7f,-2.5f);
					position = new Vector3(-20f, 7.7f, -2.5f);
					//rotation = new Vector3(0,0,0);
					Instantiate(VikingDeath1, position, Quaternion.identity);
				}
				
				if(death == 20)
				{
					Destroy(VikingDeath1);
					position = new Vector3(-20f, 7.7f, -2.5f);
					Instantiate(VikingDeath2, position, Quaternion.identity);
				}
				if(death == 30)
				{
				
				}
			}
		}
	}
	
}
