using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    //untuk player gerak
    //public Vector3 gerak;
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
    public ParticleSystem ParticlesPower;  // Drag and drop your particle system here in the inspector
    public ParticleSystem ParticlesBuff1;
    public ParticleSystem ParticlesBuff2;
    public ParticleSystem ParticlesBuff3;

    public bool isParticlePlaying;

    //untuk batas terrain
    public Terrain terrain;  
    private Vector3 minBounds;
    private Vector3 maxBounds;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        #region Batas Terrain
        // Get the terrain's position and size
        TerrainCollider terrainCollider = terrain.GetComponent<TerrainCollider>();
        minBounds = terrain.transform.position; // Position of terrain's bottom-left corner
        maxBounds = minBounds + new Vector3(terrain.terrainData.size.x, 0, terrain.terrainData.size.z);  // Top-right corner
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        #region Player Control
        MyInput();
        SpeedControl();
        #endregion

        #region Batas Terrain
        // Get the current position of the player
        Vector3 playerPosition = transform.position;

        // Clamp the player's position within the terrain bounds
        playerPosition.x = Mathf.Clamp(playerPosition.x, minBounds.x, maxBounds.x);
        playerPosition.z = Mathf.Clamp(playerPosition.z, minBounds.z, maxBounds.z);

        // Update the player's position
        transform.position = playerPosition;
        #endregion 

    }

    private void OnCollisionEnter(Collision collision)
    {
        #region lompat
        if (collision.gameObject.tag == "Ground")
        {
            sentuhTanah = true;
        }

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

        #endregion
    }
    //private void OnCollisionStay(Collision hit)
    //{
    //    Rigidbody rb = hit.collider.attachedRigidbody;

    //    if (rb != null)
    //    {
    //        Vector3 forceDirect = hit.gameObject.transform.position - transform.position;
    //        forceDirect.y = 0;
    //        forceDirect.Normalize();

    //        rb.AddForceAtPosition(forceDirect * forceMagnitude, transform.position, ForceMode.Impulse);
    //    }
    //}

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
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce , ForceMode.Impulse);
        sentuhTanah = false;
    }
}
