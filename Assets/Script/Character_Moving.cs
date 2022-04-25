using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Moving : MonoBehaviour
{
    private float char_speed = 5.0f;
    private float rot_speed = 80.0f;
    public Transform bam;
    public GameObject bam_spawn;
    //public Text HpText;

    private float timeSet;
    //private float jumpTime;
    private bool check;
    
    public static int hp = 10;
    //public static Text CHpText;

    // Start is called before the first frame update
    void Start()
    {
        timeSet = 0.0f;
        //jumpTime = 0.0f;
        check = false;
        //hp = 10;
        //CHpText = HpText;
    }

    // Update is called once per frame
    void Update()
    {
        timeSet -= Time.deltaTime;
        //jumpTime -= Time.deltaTime;
        float distance = char_speed * Time.deltaTime;
        float degree = rot_speed * Time.deltaTime;

        float moving = Input.GetAxis("Vertical");
        float angle = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.forward * moving * distance);
        this.transform.Rotate(0.0f, angle * degree, 0.0f);
        /*
        if (Input.GetButtonDown("Jump"))
        {
            if(jumpTime < 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 5.0f, 0);
                jumpTime = 1.0f;
            }
        }*/

        if(Input.GetKey(KeyCode.LeftShift))
        {
            char_speed = 10.0f;
            rot_speed = 120.0f;
        } else
        {
            char_speed = 5.0f;
            rot_speed = 80.0f;
        }

        if(Input.GetButtonDown("Fire1") && timeSet < 0)
        {
            Transform prefab_bam = Instantiate(bam, bam_spawn.transform.position, bam_spawn.transform.rotation);
            prefab_bam.GetComponent<Rigidbody>().AddForce(bam_spawn.transform.forward * 1000.0f);
            timeSet = 1.0f;
        }

        if(check)
        {
            Spawn_Key.Smsg.text = "KEY 획득!! 출구를 찾아 탈출하세요!!";
            Spawn_Key.Smsg.text += "\n플레이어 위치 : " + this.transform.position;
            Spawn_Key.Smsg.text += "\n출구 위치 : (115.8, 0, 202)";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();
        }
        if(other.gameObject.tag == "Key")
        {
            check = true;
        }
    }
}
