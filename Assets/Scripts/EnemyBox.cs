using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox : MonoBehaviour {

	public GameObject enemy;

	void Start () {
		for(int i=1; i<=8; ++i){
			Instantiate(enemy, new Vector3(Random.Range(-6f,6f),Random.Range(-1f,8f),Random.Range(-2f,8f)), Quaternion.identity, transform);
		}
	}
	
}
