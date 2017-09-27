using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour {
	public Rigidbody Player;
	private NavMeshAgent enemy;
	public float Speed;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		enemy.destination = Player.position;
	}
}
