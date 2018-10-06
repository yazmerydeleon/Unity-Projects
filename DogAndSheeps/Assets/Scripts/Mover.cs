using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour {

    private Vector3 goal;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;

        goal = transform.position;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        goal = transform.position
            + Vector3.right * Input.GetAxis("Horizontal")
            + Vector3.forward * Input.GetAxis("Vertical");

        agent.destination = goal;
	}
}
