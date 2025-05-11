
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField] private List<GameObject> environmentalObjects;
    [SerializeField] private int MAX_ENVIRONMENTAL_OBJECTS;
    private float MIN_Y = 0;
    private float MAX_Y = 9.6f;
    private float MIN_X = -8.8f;
    private float MAX_X = 8.8f;
    
    void Start()
    {
        setupMap();
    }

    private void setupMap()
    {
        int numberOfEnvironmentalObjects = Random.Range(0, MAX_ENVIRONMENTAL_OBJECTS);

        for (int i = 0; i < numberOfEnvironmentalObjects; i++)
        {
            float y = Random.value * MAX_Y;
            float x = ( Random.value * MAX_X * 2 ) + MIN_X;
            int objIndex = Random.Range(0, environmentalObjects.Count);
            
            Instantiate(environmentalObjects[objIndex], new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}