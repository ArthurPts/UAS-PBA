using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tembok : MonoBehaviour
{
    public player dataPenabrak;

    private void OnCollisionEnter(Collision penabrak)
    {
        if (penabrak.gameObject.tag == "Player" && dataPenabrak != null) 
        {
            if (dataPenabrak.isParticlePlaying == true)
            {
                dataPenabrak.ParticlesPower.Stop();
                dataPenabrak.isParticlePlaying = false;
                Destroy(gameObject);
            }
        }
        else if (penabrak.gameObject.tag == "Break")
        {
            Destroy(gameObject);
        }
    }

}
