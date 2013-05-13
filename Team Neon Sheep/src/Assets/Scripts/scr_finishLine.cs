using UnityEngine;
using System.Collections;

public class scr_finishLine : MonoBehaviour
{
	public GUIText endGameText;
	bool isEnd = false;
	int endCounter = 0;
	
	void OnCollisionEnter(Collision col)
	{
		if(isEnd == true)
		{
			endCounter++;
		}
		
		if(isEnd == false)
		{
			if(col.gameObject.name == "ProgressSheep")
			{
				isEnd = true;
				endGameText.text = "You Win!";
			}
			else
			{
				isEnd = true;
				endGameText.text = "You Lose!";
			}
		}
	}
	void Update()
	{
		if(isEnd == true)
		{
			endCounter++;
		}
		if(endCounter == 100)
		{
			Application.LoadLevel("Main Scene");
		}
	}
}
