using UnityEngine;
using System.Collections;

public class CScript_Viking : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	int VikingAttack = 0;
	int IPlayerHealth = 100;
	bool Damage = false;
	int death = 0;
	int IEnemyHealth = 0;
	
	public Material enemy_standing;
	public Material enemy_attack1;
	public Material enemy_attack2;
	public Material enemy_attack3;
	public Material enemy_attack4;
	public GUIText GPlayerHealth;
	public GameObject Player_Fencing;
	public GameObject Player_dodge1;
	public GameObject Player_dodge2;
	public GameObject Player_dodge3;
	private Vector3 position;
	private Vector3 rotation;

	// Update is called once per frame
	void Update () 
	{
		VikingAttack++;
		GPlayerHealth.text = "Player Health: " + IPlayerHealth;
		if(VikingAttack == 0)
		{
			//transform.position = new Vector3(-20f,7.7f,-2.5f);
			renderer.material = enemy_standing;
		}
		if(VikingAttack == 10)
		{
			renderer.material = enemy_attack1;
		}
		if(VikingAttack == 20)
		{
			renderer.material = enemy_attack2;
		}
		if(VikingAttack == 30)
		{
			//transform.position = new Vector3(-21.1f,7.7f,-2.5f);
			renderer.material = enemy_attack3;
			Damage = true;
		}
		if(VikingAttack == 40)
		{
			renderer.material = enemy_attack4;
			transform.position = new Vector3(-21.01f,7.7f,-2.5f);
			
		}
		if(VikingAttack == 50)
		{
			renderer.material = enemy_standing;
			transform.position = new Vector3(-20f,7.7f,-2.5f);
			VikingAttack = 0;
			Damage = false;
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Player_Fencing")
		{
			if(Damage == true)
			{
				IPlayerHealth -= 20;
				GPlayerHealth.text = "Player Health: " + IPlayerHealth;
			}
			if(IPlayerHealth == 0)
			{
				death++;
				if(death == 1);
				{
					Destroy(Player_Fencing);
					position = new Vector3(-27f,5f,-2.5f);
					Instantiate(Player_dodge1, position, Quaternion.identity);
				}
				if(death == 20);
				{
					Destroy(Player_dodge1);
					position = new Vector3(-27f,5f,-2.5f);
					Instantiate(Player_dodge2, position, Quaternion.identity);
				}
				if(death == 30);
				{
					Destroy(Player_dodge2);
					position = new Vector3(-27f,5f,-2.5f);
					Instantiate(Player_dodge3, position, Quaternion.identity);
				}
			}
		}
	}
}
