﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		winText.text = "";
		UpdateCountText();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			++count;
			UpdateCountText();
		}
	}

	void UpdateCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 4) {
			winText.text = "You Win!";
		}
	}
}
