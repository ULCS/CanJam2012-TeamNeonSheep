using UnityEngine;
using System.Collections;

public class ReturnToMainScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.P))
		{
			Application.LoadLevel("Main Scene");
		}
	}
}
