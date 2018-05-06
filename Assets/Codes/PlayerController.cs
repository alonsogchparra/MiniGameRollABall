using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int speed;
	public Text countText, winText;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		count = 0;
		winText.text = "";
		SetCountText();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
			
	}

	void OnTriggerEnter(Collider other) {

		if(other.gameObject.CompareTag("Pick Up")) {
			
			other.gameObject.SetActive(false);
			count++;
			SetCountText();

			if(count >= 12) {
				winText.text = "YOU WIN!!!";
			}

		}

	}


	void SetCountText() {
		countText.text = "Count: " + count;
	}

}
