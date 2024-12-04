using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //untuk player gerak
    public float rotate;
    public float speed;

    //untuk batas terrain
    public Terrain terrain;  
    private Vector3 minBounds;
    private Vector3 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
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
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up * horizontal * rotate * Time.deltaTime);

        float vertical = Input.GetAxis("Vertical");
        transform.position += transform.forward * vertical * speed * Time.deltaTime;
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
}
