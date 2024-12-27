using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    //untuk player gerak
    private Rigidbody rb;
    public float speed;
    public float rotate;
    public float jumpForce;

    public bool sentuhTanah = true;
    Vector3 moveDirection;
    float verticalInput;
    float horizontalInput;
    public float forceMagnitude;

    // Particle system reference
    public ParticleSystem ParticlesPower;
    public ParticleSystem ParticlesBuff1;
    public ParticleSystem ParticlesBuff2;
    public ParticleSystem ParticlesBuff3;
    public bool isParticlePlaying;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //lompat
        if (collision.gameObject.tag == "Ground")
        {
            sentuhTanah = true;
        }

        //buff
        if (collision.gameObject.tag == "Buff")
        {
            ParticlesPower.Play();
            isParticlePlaying = true;
        }
        else if (collision.gameObject.tag == "BuffPush1")
        {
            ParticlesBuff2.Stop();
            ParticlesBuff3.Stop();

            ParticlesBuff1.Play();
            isParticlePlaying = true;
            forceMagnitude = 150f;

        }
        else if (collision.gameObject.tag == "BuffPush2")
        {
            ParticlesBuff1.Stop();
            ParticlesBuff3.Stop();

            ParticlesBuff2.Play();
            isParticlePlaying = true;
            forceMagnitude = 100f;

        }
        else if (collision.gameObject.tag == "BuffPush3")
        {
            ParticlesBuff1.Stop();
            ParticlesBuff2.Stop();

            ParticlesBuff3.Play();
            isParticlePlaying = true;
            forceMagnitude = 75f;

        }

        //untuk rintangan 2
        if (collision.gameObject.tag != "Wall")
        {
            Rigidbody rb = collision.collider.attachedRigidbody;

            if (rb != null)
            {
                Vector3 forceDirect = collision.gameObject.transform.position - transform.position;
                forceDirect.y = 0;
                forceDirect.Normalize();

                rb.AddForceAtPosition(forceDirect * forceMagnitude, transform.position, ForceMode.Impulse);
            }

        }
    }
   
    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && sentuhTanah)
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        moveDirection = transform.forward * verticalInput;
        if (sentuhTanah)
        {
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Impulse);
        }
        else if (!sentuhTanah)
        {
            rb.AddForce(moveDirection.normalized * speed * 0.4f, ForceMode.Impulse);

        }
        transform.Rotate(transform.up * horizontalInput * rotate);

    }

    private void SpeedControl()
    {
        Vector3 kecepatanNow = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (kecepatanNow.magnitude > speed)
        {
            Vector3 setMaksimal = kecepatanNow.normalized * speed;
            rb.velocity = new Vector3(setMaksimal.x, rb.velocity.y, setMaksimal.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce , ForceMode.Impulse);
        sentuhTanah = false;
    }
}
