using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    public player dataPenabrak;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (dataPenabrak.ParticlesBuff1.isPlaying)
            {
                this.gameObject.tag = "Break";
            }
            else
            {
                this.gameObject.tag = "Untagged";
            }
            dataPenabrak.ParticlesBuff1.Stop();
            dataPenabrak.ParticlesBuff2.Stop();
            dataPenabrak.ParticlesBuff3.Stop();
            dataPenabrak.isParticlePlaying = false;
            dataPenabrak.forceMagnitude = 0f;
            
        }
        else if(collision.gameObject.tag == "Wall" && this.gameObject.tag == "Break")
        {
            Destroy(this.gameObject);
        }
        
    }


}
