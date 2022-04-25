using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_manager : MonoBehaviour
{
    public Text msg;
    public Transform player;
    public Transform sp_point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //
        this.transform.LookAt(player);

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(this.transform.position, fwd * 5, out hit, 5) == false
            || hit.collider.gameObject.tag != "Player")
            return;

        //Moving (rotating)

    }

}
