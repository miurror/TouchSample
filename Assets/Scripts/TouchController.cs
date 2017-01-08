using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	public OVRInput.Controller controller;
	void Update () {
		transform.localPosition = OVRInput.GetLocalControllerPosition(controller);	
		transform.localRotation = OVRInput.GetLocalControllerRotation(controller);	
	}
}
