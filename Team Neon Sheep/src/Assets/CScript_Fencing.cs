using UnityEngine;
using System.Collections;

public class CScript_Fencing : MonoBehaviour {

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
	GameObject door_Rowing;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.I))
			{
				renderer.material = player_attack_mid2;
				spin = 1;
			}
			if(spin == 1)
			{
				if(Input.GetKey(KeyCode.K))
				{
					renderer.material = player_attack_low2;
					spin = 2;
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
				if(finishAttack >= 50)
				{
				renderer.material = player_standing_attack;
				BfinishAttack = false;
				finishAttack = 0;
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
			else
			{
				renderer.material = player_standing_attack;
				Bdodge = false;
			}
			if(Bdodge == true)
			{
				dodge++;
			}
	
	}
}
