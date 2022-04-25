using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bam_ctrl : MonoBehaviour
{
    public AudioClip col_sound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        AudioSource.PlayClipAtPoint(col_sound, this.transform.position);
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            
        }
        Destroy(this.gameObject, 0.2f);
    }
}
