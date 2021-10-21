using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject asteroidPrefab;
    public Transform spawnOrigin;
    public float next_spawn_time;
    // Start is called before the first frame update
    void Start()
    {
         next_spawn_time = Time.time+1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > next_spawn_time)
     {
         Instantiate(asteroidPrefab, spawnOrigin.position, Quaternion.identity);
 
         //increment next_spawn_time
         next_spawn_time += 2f;
     }
        
    }
}
