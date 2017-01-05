using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	public float speed = 0f;
	public float bulletSpeed = 0f;
	public bool bulletMode = false;
	
	void Update () {

		if(Input.GetButtonUp("Fire1")){
			bulletMode = true;
		}

		float v1 = Input.GetAxis("Horizontal") * speed;
		float v2 = Input.GetAxis("Vertical") * speed;
		float v3 = bulletMode ? bulletSpeed : 0f;
		float r1 = Input.GetAxis("Horizontal2");
		float r2 = Input.GetAxis("Vertical2");

		transform.Translate(v1,v2,v3);
		transform.Rotate(r2,r1,0f,Space.World);

	}
}
