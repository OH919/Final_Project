using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper_spawn : MonoBehaviour
{
    public GameObject helper;
    public Text msg;
    GameObject helper_obj;

    static Vector3 loc;
    static int k;
    Vector3[] v =
    {
        new Vector3(-12, 0, -237),
        new Vector3(160, 0, -246)
    };

    
    // Start is called before the first frame update
    void Start()
    {
        helper_obj = Instantiate(helper, v[k], helper.transform.rotation);

        msg.text = "Hello world!";
        msg.text += "\nKEY : " + loc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
