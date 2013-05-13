using UnityEngine;
using System.Collections;

public class scr_vikingAxeThrow : MonoBehaviour
{
	void Start ()
	{
		rigidbody.AddForce(new Vector3(0, 0, -1000));
	}
	
	void Update()
	{
		if(transform.position.z < 7.5f)
			Destroy(gameObject);
	}
}
