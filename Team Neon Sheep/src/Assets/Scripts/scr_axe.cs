using UnityEngine;
using System.Collections;

public class scr_axe : MonoBehaviour
{
	public GUIText scoreText;
	public GameObject deadViking;
	
	int score = 0;
	
	void Start()
	{
		scoreText.text = "Score: 0";
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Viking(Clone)")
		{
			Instantiate(deadViking, col.gameObject.transform.position, Quaternion.identity);
			Destroy(col.gameObject);
			score += 10;
			scoreText.text = "Score: " + score;
		}
	}
}