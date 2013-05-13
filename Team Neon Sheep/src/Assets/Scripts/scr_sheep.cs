using UnityEngine;
using System.Collections;

public class scr_sheep : MonoBehaviour
{
	void Start ()
	{
		rigidbody.AddForce(new Vector3(0, 0, -200));
	}
	
	void Update()
	{
		transform.Rotate(new Vector3(0, 0.3f, 0));
		
		if(transform.position.z < -11)
			Destroy(gameObject);
	}
}
