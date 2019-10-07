using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    private string robotType;

    public int health;
    public int range;
    public float fireRate;

    public Transform missileFireSpot;
    UnityEngine.AI.NavMeshAgent agent;

    private Transform player;
    private float timeLastFired;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //1
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //2
        if (isDead)
        {
            //3
            transform.LookAt(player);

            //4
            agent.SetDestination(player.position);

            //5
            if(Vector3.Distance(transform.position, player.position) < range && Time.time - timeLastFired > fireRate)
            {
                //6 
                timeLastFired = Time.time;
                fire();
            }
        }
    }

    private void fire()
    {
        Debug.Log("Fire");
    }
}
