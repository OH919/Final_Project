using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_helper : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        player = Spawn_Key.Splayer;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = ((this.transform.position.x - player.transform.position.x)
            * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z)
            * (this.transform.position.z - player.transform.position.z));
        distance = Mathf.Sqrt(distance);


        if (distance < 10)
            MoveToGoal();
        else
            agent.isStopped = true;
    }
    void MoveToGoal()
    {
        agent.isStopped = false;
        agent.SetDestination(goal.transform.position);
    }
}
