using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy_move : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public AudioClip col_sound;
    private GameObject player;
    private Text t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(player == null)
         //   player = Spawn_Key.Splayer;

        //if (t == null)
        //    t = Spawn_Key.Shp_msg;

        this.transform.LookAt(Spawn_Key.Splayer.transform);

        float distance = ((this.transform.position.x - Spawn_Key.Splayer.transform.position.x)
            * (this.transform.position.x - Spawn_Key.Splayer.transform.position.x))
            + ((this.transform.position.z - Spawn_Key.Splayer.transform.position.z)
            * (this.transform.position.z - Spawn_Key.Splayer.transform.position.z));
        distance = Mathf.Sqrt(distance);

        if(distance < 10)
            MoveToTarget();
    }

    void MoveToTarget()
    {
        agent.SetDestination(Spawn_Key.Splayer.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(col_sound, this.transform.position);
            Character_Moving.hp -= 1;
            Destroy(this.gameObject);
        }
        Spawn_Key.Shp_msg.text = "HP : " + Character_Moving.hp;

        if(Character_Moving.hp < 1)
        {
            Character_Moving.hp = 10;
            SceneManager.LoadScene("dead");
        }
    }
}
