using UnityEngine;
using System.Collections;

public class cscript_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			if (Input.GetKeyDown(KeyCode.A))
			{
				rigidbody.AddRelativeForce(-10,0,0);
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				rigidbody.AddRelativeForce(10,0,0);
			}
			if (Input.GetKeyDown(KeyCode.W))
			{
				rigidbody.AddRelativeForce(0,0,10);
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				rigidbody.AddRelativeForce(0,0,-10);
			}
	}
}

