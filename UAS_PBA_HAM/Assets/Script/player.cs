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
    public bool sentuhTanah = true;

    // Particle system reference
    public ParticleSystem speedParticles;  // Drag and drop your particle system here in the inspector
    private bool isParticlePlaying = false;

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
        if (Input.GetKey(KeyCode.W)) //This controls forward
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))//This controls back
        {
            rb.AddForce(-transform.forward * speed * Time.deltaTime);
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up * horizontal * rotate * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.Space) && sentuhTanah)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            sentuhTanah = false;
        }

        if (speedParticles != null)
        {
            // Speed check to trigger particles
            float currentSpeed = rb.velocity.magnitude;  // Calculate the player's speed

            if (currentSpeed >= 5f && !isParticlePlaying)
            {
                // Play particle effect when speed reaches 5
                speedParticles.Play();
                isParticlePlaying = true;  // To prevent it from playing again
            }
            else if (currentSpeed < 5f && isParticlePlaying)
            {
                // Stop particle effect when speed is below 5
                speedParticles.Stop();
                isParticlePlaying = false;  // Reset particle state
            }

        }

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
        #endregion
    }

    private void FixedUpdate()
    {

    }
}
