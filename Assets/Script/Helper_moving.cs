using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_moving : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public GameObject key;
    //public Spawn_Key sk;
    GameObject v;

    // Start is called before the first frame update
    void Start()
    {
        
        
        //key = GameObject.Find("KeyCube(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        //v = sk.getV();
        //Debug.Log(v);
        /*float distance = ((this.transform.position.x - player.transform.position.x)
            * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z)
            * (this.transform.position.z - player.transform.position.z));
        distance = Mathf.Sqrt(distance);

        if (distance < 10)
            MoveToBox();
        else
            agent.isStopped = true;*/
    }

    void MoveToBox()
    {
        //agent.isStopped = false;
        //Debug.Log(v);
        //agent.SetDestination(v.transform.position);
    }

}
