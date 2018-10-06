using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepMover : MonoBehaviour
{
    private Vector3 goal;
    private NavMeshAgent agent;
    private int frame;
    public int frameInterval;
    public GameObject cubeTarget;
    private float walkingSpeed;
    private float runningSpeed;


    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;

        agent = GetComponent<NavMeshAgent>();
        frame = 0;
        walkingSpeed = agent.speed + Random.Range(0, 0.5f);
        runningSpeed = agent.speed * 8;
       // Debug.Log("agent.speed: " + agent.speed);

    }
    // Moverse random desde su position de inicio

    // Update is called once per frame
    void Update()
    {
        frame++;
        if (frame == frameInterval)
        {
            agent.speed = walkingSpeed;
           // Debug.Log("agent.speed: " + agent.speed);
            frameInterval += Random.Range(-80, 80);

            var zDestination = (this.transform.position.z >= -9.5 && this.transform.position.z <= 2.5)
                             ? Random.Range(-9.5f, 2.5f)
                             : Random.Range(3.5f, 9.5f);
            agent.destination = new Vector3(Random.Range(-9.5f, 9.5f), 0, zDestination);

            cubeTarget.transform.position = agent.destination;
            frame = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //agent.destination = this.transform.position - other.transform.position; //new Vector3(Random.Range(-9.5f, 9.5f), 0, Random.Range(2.5f, -9.5f));
            //cubeTarget.transform.position = agent.destination;
            //Debug.Log("Ayyy! el perro ");

            Vector3 dir = (this.transform.position - other.transform.position).normalized;
            Debug.Log("dir: " + dir);
            var destination = this.transform.position + (dir * Random.Range(5f, 7f));
            agent.destination = new Vector3(destination.x, 0, destination.z);
            Debug.DrawLine(this.transform.position, agent.destination, Color.red, 5);
            agent.speed = runningSpeed;
            //Debug.Log("agent.speed: " + agent.speed);
            cubeTarget.transform.position = agent.destination;
        }
    }

}
