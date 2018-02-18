using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void Move(){
		this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (speed, 0));
	}
}
