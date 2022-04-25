using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_manager : MonoBehaviour
{
    private float speed = 100.0f;
    public GameObject exit;
    public GameObject helper;
    public GameObject goal_helper;
    public GameObject door;
    public GameObject door_err;
    private GameObject door_err_obj = null;

    public AudioClip col_sound;


    // Start is called before the first frame update
    void Start()
    {
        door_err_obj = (GameObject) Instantiate(door_err);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(col_sound, this.transform.position);

            helper.gameObject.SetActive(false);
            Instantiate(goal_helper);
            Instantiate(door);
            Instantiate(exit);
            Destroy(door_err_obj);
            Destroy(this.gameObject);
        }
    }
}
