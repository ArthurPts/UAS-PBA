using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public Vector3 force;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
