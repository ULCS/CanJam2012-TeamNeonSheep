using UnityEngine;
using System.Collections;

public class scr_score : MonoBehaviour
{
	public int score = 0;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		guiText.text = "Score: " + score;
	}
}
