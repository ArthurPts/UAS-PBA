using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tembok : MonoBehaviour
{
    public float minSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision penabrak)
    {
        if (penabrak.gameObject.tag != "Ground") {
            Rigidbody rb = penabrak.rigidbody;

            Debug.Log("Collision detected with: " + rb.velocity.magnitude);
            if (rb != null)
            {
                // Periksa kecepatan objek
                float speed = rb.velocity.magnitude;

                if (speed >= minSpeed)
                {
                    // Hancurkan objek ini
                    Destroy(gameObject);
                }
            }
        }
    }

}
