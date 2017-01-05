using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceController : MonoBehaviour {

	public float speed = 0f;
	public float bulletSpeed = 0f;
	public bool bulletMode = false;
	public GameObject maincamera;	
    private AudioSource[] sources;

    void Start () {
        sources = GetComponents<AudioSource>();
    }	
	
	void Update () {

		if(Input.GetButtonUp("Fire1")){
			sources[0].Play();
			Coroutine coroutine = StartCoroutine("DelayMethod", 0.2f);
		}

		float v1 = bulletMode ? 0f : Input.GetAxis("Horizontal") * speed;
		float v2 = bulletMode ? 0f : Input.GetAxis("Vertical") * speed;
		float v3 = bulletMode ? bulletSpeed : 0f;
		float r1 = bulletMode ? 0f : Input.GetAxis("Horizontal2");
		float r2 = bulletMode ? 0f : Input.GetAxis("Vertical2");

		transform.Translate(v1,v2,0f,Space.World);
		transform.Translate(0f,0f,v3);
		transform.Rotate(r2,r1,0f,Space.World);

		if(transform.position.magnitude>15f){
			//Debug.Log("reload!");
			bulletMode = false;
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
			GetComponent<Rigidbody>().angularVelocity = new Vector3 (0,0,0);
			transform.position = maincamera.transform.position + new Vector3 (0, -0.1f, 1f);
			transform.rotation = maincamera.transform.rotation;
		}

	}

	void OnCollisionEnter (Collision obj) {
		
		//Debug.Log("hit!");
		bulletMode = false;
		Destroy(obj.gameObject);
		GetComponent<Rigidbody>().useGravity = true;
		sources[1].Play();

	}

	private IEnumerator DelayMethod (float waitTime) {

  		yield return new WaitForSeconds(waitTime);
		bulletMode = true;
	
	}

}
