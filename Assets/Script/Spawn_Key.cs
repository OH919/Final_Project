using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Key : MonoBehaviour
{
    public GameObject cube;
    public Text msg;
    public Text hp_msg;
    public GameObject checkpoint;
    public GameObject goal_helper;

    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    private int k = 0;
    private float distance = 0.0f;
    private bool check = true;

    private GameObject cube_obj;

    public static GameObject Splayer;
    public static Text Smsg;
    public static Text Shp_msg;

    Vector3[] v =
    {
        new Vector3(390, 0.5f, -80),
        new Vector3(-285, 0.5f, -215),
        new Vector3(400, 0.5f, -375)
    };


    // Start is called before the first frame update
    void Start()
    {
        Splayer = player;
        Smsg = msg;
        Shp_msg = hp_msg;

        k = Random.Range(0, 3);
        cube_obj = Instantiate(cube, v[k], cube.transform.rotation);

        msg.text = "���� ������ ã������!!";
        msg.text += "\nKEY : " + v[k];
        
    }

    // Update is called once per frame
    void Update()
    {

        distance = ((this.transform.position.x - player.transform.position.x)
            * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z)
            * (this.transform.position.z - player.transform.position.z));
        distance = Mathf.Sqrt(distance);
        if (cube_obj == null)
        {
            //gameObject.SetActive(false);
            /*msg.text = "KEY ȹ��!! �ⱸ�� ã�� Ż���ϼ���!!";
            msg.text += "\n�÷��̾� ��ġ : " + player.transform.position;
            msg.text += "\n�ⱸ ��ġ : (115.8, 0, 202)";*/
        }
        


        if (distance < 10)
            MoveToBox();
        else
            agent.isStopped = true;

    }
    void MoveToBox()
    {
        agent.isStopped = false;
        if (k == 1)
        {
            if(check)
                agent.SetDestination(checkpoint.transform.position);
            else
                agent.SetDestination(cube_obj.transform.position);
        }
        else if (cube_obj == null)
        {
            agent.isStopped = true;
        }
        else if (check)
            agent.SetDestination(cube_obj.transform.position);

    }
    
    void OnTriggerEnter(Collider other)
    {
        //helper ĳ������ ���忡�� üũ�˴ϴ�
        if (other.gameObject.name == "checkpoint")
        {
            check = false;
        }
        if (other.gameObject.tag == "Key")
        {
            check = false;
            cube_obj = null;
            this.GetComponent<Renderer>().enabled = false;
            agent.isStopped = true;
            //gameObject.SetActive(false);
        }
    }

}
