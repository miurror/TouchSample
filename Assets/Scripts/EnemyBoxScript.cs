using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxScript : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		for(int i=1; i<=10; ++i){
			Instantiate(enemy, new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),Random.Range(-3f,3f)), Quaternion.identity);
		}
	}
	
}
