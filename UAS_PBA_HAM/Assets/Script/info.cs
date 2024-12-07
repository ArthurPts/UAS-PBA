using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    protected Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude;
    }
}
