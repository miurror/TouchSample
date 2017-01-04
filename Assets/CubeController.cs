using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Debug.Log("Hello Unity.");	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f,0f,0.1f);
	}
}
