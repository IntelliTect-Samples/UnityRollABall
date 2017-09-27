using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float Speed;
	private int count;
	public Text CountText;
	public Text Success;
	public Text Failure;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		UpdateText ();	
		Input.gyro.enabled = true;
	}

	void UpdateText (){
		CountText.text = "Count: " + count.ToString ();
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
		float moveHorizontal = Input.GetAxis ("Horizontal") + Input.acceleration.x;
		float moveVertical = Input.GetAxis ("Vertical") + Input.acceleration.y;
		float jump= 0.0f;

		if (Input.GetKeyDown (KeyCode.Space) && rb.position.y == .5) {
			jump = 50;
		}

		//Quaternion gyroQ = Input.gyro.attitude;
		//Vector3 gyroV3 = gyroQ.eulerAngles;

		Vector3 movement = new Vector3 (
			moveHorizontal,
			jump, 
			moveVertical
		);

		rb.AddForce (movement * Speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			UpdateText ();
			// Show the congratulatory message
			if (count == 12) {
				Success.gameObject.SetActive (true);
			}
		}
		else if (other.gameObject.CompareTag ("Enemy")) {
			count--;
			UpdateText ();
			// Show the game over
			if (count <= 0) {
				Failure.gameObject.SetActive (true);
			}
		}
	}

}
