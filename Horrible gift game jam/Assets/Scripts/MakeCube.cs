using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour
{
    public int cubeCount;
    private int type;
    private float x;
    private float z;

    float spawnTime = 0;

    // Update is called once per frame
    void Update()
    {
        //Press F to make a random cube to randome position
        
        if (Time.time - spawnTime > 1)
        {
            Debug.Log(transform.position);
            type = Random.Range(1, 7);
            x = Random.Range(-47f, 45f);
            z = Random.Range(-20f, 23f);
            Vector3 pos = new Vector3(x, 5f, z);
            CubeFactory.MakeCube(type, pos, Quaternion.identity);
            spawnTime = Time.time;
            cubeCount++;

            if (cubeCount == 10)
            {
                Debug.Log("You've spawned 10 cubes! wow");
            }
        }
    }
}