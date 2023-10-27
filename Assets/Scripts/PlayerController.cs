using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 500.0f;

    public float zUpperBound = 140.0f;
    public float zLowerBound = -154.0f;
    public float xBound = 100.0f;
    
    private Rigidbody playerRb; 
    private Terrain terrain;  // Reference to the terrain
    private TerrainData terrainData;  // Reference to the terrain data


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;  // Ensure physics doesn't affect rotation

        terrain = GameObject.FindWithTag("Terrain").GetComponent<Terrain>();
        terrainData = terrain.terrainData;


    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void FixedUpdate()
{
    MovePlayer();
    ConstrainPlayerToTerrain();
}

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float rotation = horizontalInput * rotationSpeed * 5 * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);

        // Forward movement
        if (verticalInput > 0)
        {
            Vector3 forwardMovement = transform.forward * verticalInput * speed;
            transform.Translate(forwardMovement * Time.deltaTime, Space.World);
        }
        // Backward movement
        else if (verticalInput < 0)
        {
            Vector3 backwardMovement = -transform.forward * -verticalInput * speed;
            transform.Translate(backwardMovement * Time.deltaTime, Space.World);
        }

        ConstrainPlayerPosition();
    }

 void ConstrainPlayerToTerrain()
    {
        float terrainHeight = GetTerrainHeightAtPlayerPosition();
        Vector3 newPosition = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        playerRb.MovePosition(newPosition);
    }

float GetTerrainHeightAtPlayerPosition()
    {
        // Get normalized terrain coordinates based on the player's position
        float terrainX = (transform.position.x - terrain.transform.position.x) / terrainData.size.x;
        float terrainZ = (transform.position.z - terrain.transform.position.z) / terrainData.size.z;

        // Convert normalized coordinates to terrain coordinates
        int heightmapX = Mathf.Clamp(Mathf.FloorToInt(terrainX * terrainData.heightmapResolution), 0, terrainData.heightmapResolution - 1);
        int heightmapZ = Mathf.Clamp(Mathf.FloorToInt(terrainZ * terrainData.heightmapResolution), 0, terrainData.heightmapResolution - 1);

        // Get the height from the terrain's heightmap data
        float[,] heights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
        float terrainHeight = heights[heightmapX, heightmapZ] * terrainData.size.y;

        return terrainHeight;
    }
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zUpperBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpperBound);
        }
        else if (transform.position.z < zLowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerBound);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

}
