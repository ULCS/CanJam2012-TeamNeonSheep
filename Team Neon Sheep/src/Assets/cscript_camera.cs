using UnityEngine;
using System.Collections;

public class cscript_camera : MonoBehaviour 
{
	public GameObject moveObject;
	public float LockedZ = -5;
	public float LockedY = 0;

	//public GameObject player;
	void Update ()
	{
		Vector3 currentPos = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, LockedZ);
		moveObject.transform.position = currentPos;
	}

	/*{
     transform.position = new Vector3(player.transform.x,player.transform.y, LockedZ);
	}*/

}
