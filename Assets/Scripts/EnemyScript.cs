using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public Rigidbody Player;
	private Rigidbody enemy;
	public float Speed;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Vector3 movement = Player.position - enemy.position;
		enemy.AddForce (movement.normalized * Speed);
	}
}
