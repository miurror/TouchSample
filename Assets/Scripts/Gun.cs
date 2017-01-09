using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    
		
	public GameObject bullet;
	public bool bulletMode = false;
	public bool rightHand = false;

    private AudioSource shootSE;
    
	void Start () {
        shootSE = GetComponent<AudioSource>();
    }	
	
	void Update () {

		if((bulletMode && rightHand && Input.GetAxis("IndexTrigger") == 1)||bulletMode && !rightHand && Input.GetAxis("IndexTrigger") == -1){
			shootSE.Play();			
			StartCoroutine("DelayMethod", 0.2f);
			Instantiate (bullet, transform.position + transform.TransformDirection(new Vector3 (0, 0.12f, 0.05f)), transform.rotation);	
			bulletMode = false;		
		}
	}

	private IEnumerator DelayMethod (float waitTime) {
  		yield return new WaitForSeconds(waitTime);
		bulletMode = true;
	}


}
