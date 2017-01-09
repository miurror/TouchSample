using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 10;
    private AudioSource hittingSE;

	void Start () {
		GetComponent<Rigidbody>().velocity = transform.up * speed;
        hittingSE = GetComponent<AudioSource>();		
	}
	
	void OnCollisionEnter (Collision obj) {
		hittingSE.Play();
		Destroy(obj.gameObject);
		GetComponent<Rigidbody>().useGravity = true;		
		StartCoroutine("DelayMethod", 0.5f);
	}

	private IEnumerator DelayMethod (float waitTime) {
  		yield return new WaitForSeconds(waitTime);
		Destroy(gameObject);
	}

}
