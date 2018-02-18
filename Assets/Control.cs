﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
	public int movement;
	public int movementSpeed;
	void Update () {
		ControllPlayer();
	}


	void ControllPlayer(){
		
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);


		transform.Translate (movement * movementSpeed * Time.deltaTime, Space.World);
	}
}
