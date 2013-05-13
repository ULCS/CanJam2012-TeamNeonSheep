using UnityEngine;
using System.Collections;

public class CScript_OpenDoors : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Return))
		{
			transform.position += new Vector3(-0.1f,0,0);
		}
	}
}
