﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text WinText;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		count = 0;
		setCountText ();
		WinText.text = "";
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//For desktop
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);

		//For Mobile Devices
		//Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
		//rb.velocity = movement * speed;


	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
			if (count >= 11)
				WinText.text = "You Win";
		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}
