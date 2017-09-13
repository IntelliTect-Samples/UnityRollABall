using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float Speed;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Equals)) {
			Speed++;
		}
		if (Input.GetKeyDown (KeyCode.Minus)) {
			Speed--;
			if (Speed < 0)
				Speed = 0;
		}

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float jump= 0.0f;

		if (Input.GetKeyDown (KeyCode.Space) && rb.position.y == .5) {
			jump = 50;
		}

		Vector3 movement = new Vector3 (moveHorizontal, jump, moveVertical);

		rb.AddForce (movement * Speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
		}
	}

}
