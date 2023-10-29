using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWheat : MonoBehaviour
{
   public GameObject wheatPrefab; 
public Terrain terrain;
public int numberOfWheat = 1000; // Number of wheat instances you want to spawn

void Start()
{
    float rowDistance = 3.0f;   // Distance between each row
    float wheatSpacing = 1.0f;  // Distance between each wheat in a row

    int rows = Mathf.FloorToInt((207 + 223) / rowDistance);  // Total rows that fit in the z boundary
    int columns = Mathf.FloorToInt((470 + 101) / wheatSpacing); // Total columns that fit in the x boundary

    for (int rowIndex = 0; rowIndex < rows; rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < columns; columnIndex++)
        {
            float x = -470 + columnIndex * wheatSpacing;
            float z = -223 + rowIndex * rowDistance;

            // The rest is similar to before, sampling height and spawning the wheat
            Vector3 localPoint = terrain.transform.InverseTransformPoint(new Vector3(x, 0, z));
            float y = terrain.SampleHeight(localPoint);
            y += terrain.transform.position.y + 0.1f;

            Vector3 normal = terrain.terrainData.GetInterpolatedNormal((x + 470) / (terrain.terrainData.size.x + 369), (z + 223) / (terrain.terrainData.size.z + 430));
            Quaternion rotation = Quaternion.LookRotation(Vector3.Cross(Vector3.right, normal), normal);
            
            Instantiate(wheatPrefab, new Vector3(x, y, z), rotation);
        }
    }
}
}
