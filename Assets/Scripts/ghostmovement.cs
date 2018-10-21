using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostmovement : MonoBehaviour {
public Transform[] waypoints;
	int current_waypoints = 0; 

	public float speed = 0.9f;
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position != waypoints[current_waypoints].position) {
			Vector2 p = Vector2.MoveTowards(transform.position,
											waypoints[current_waypoints].position,
											speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
		// Waypoint reached, select next one
		else current_waypoints = (current_waypoints + 1) % waypoints.Length;

		if (Vector3.Distance (transform.position, waypoints[current_waypoints].position) < 0.01) 
			current_waypoints = (current_waypoints + 1) % waypoints.Length;

		// Animation
		Vector2 dir = waypoints[current_waypoints].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman")
			Destroy(co.gameObject);
	}
}
