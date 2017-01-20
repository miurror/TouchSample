using UnityEngine;

public class Grab : MonoBehaviour {


	public OVRInput.Controller controller;

    public const float THRESH_GRAB = 0.55f;
    public const float THRESH_DROP = 0.35f;

	private bool grabbing;

	public float grabRadius;
	public LayerMask grabMask;

	private GameObject grabbedObject;

	private Quaternion lastRotation, currentRotation;

	void GrabObject(){

		Collider[] hits;
//		RaycastHit[] hits;

		hits = Physics.OverlapSphere(transform.position, grabRadius, grabMask);
//		hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);

		if (hits.Length > 0){
			
			int closestHit = 0;

			for (int i = 0; i < hits.Length; i++) {
				//if ((hits[i].transform.position - transform.position).sqrMagnitude < (hits[closestHit].transform.position - transform.position).sqrMagnitude) closestHit = i;
				if (Vector3.Distance(hits[i].transform.position,transform.position) < Vector3.Distance(hits[closestHit].transform.position,transform.position)) closestHit = i;
//				if (hits[i].distance < hits[closestHit].distance) closestHit = i;
			}

			grabbing = true;
			//grabbedObject = hits[closestHit].transform.gameObject;
			grabbedObject = hits[closestHit].attachedRigidbody.gameObject;
//			grabbedObject = hits[closestHit].rigidbody.gameObject;
			grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
			grabbedObject.transform.position = transform.position;
			grabbedObject.transform.parent = transform;

			if(grabbedObject.name == "ToyGun"){
				grabbedObject.transform.rotation = transform.rotation * Quaternion.Euler(-90, 180, 0);
				grabbedObject.GetComponent<Gun>().bulletMode = true;
				if(gameObject.name == "RightHand"){
					grabbedObject.GetComponent<Gun>().rightHand = true;
				}else{
					grabbedObject.GetComponent<Gun>().rightHand = false;
				}
			}
		}
	}

	void DropObject(){

		grabbing = false;

		if (grabbedObject != null){
			
			if(grabbedObject.name == "ToyGun"){
				grabbedObject.GetComponent<Gun>().bulletMode = false;
			}

			grabbedObject.transform.parent = null;
			grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
			grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
			grabbedObject.GetComponent<Rigidbody>().angularVelocity = GetAngularVelocity();

			grabbedObject = null;
		
		}
	}
	
	Vector3 GetAngularVelocity(){
		Quaternion deltaRotation = currentRotation * Quaternion.Inverse(lastRotation);
		return new Vector3(Mathf.DeltaAngle(0, deltaRotation.eulerAngles.x), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.y), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.z));
	}

	void Update () {
	
		if (grabbedObject != null){
			lastRotation = currentRotation;
			currentRotation = grabbedObject.transform.rotation;
		}
		
		OVRInput.Update();
        
		if(!grabbing && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller) >= THRESH_GRAB) GrabObject();
        if(grabbing && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller) <= THRESH_DROP) DropObject();	
	}
}
