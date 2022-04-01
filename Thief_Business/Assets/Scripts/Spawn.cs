using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] place;
    public int countSpawn;
    void Start()
    {
        for (int i = 1; i <= countSpawn; i++)
        {
            float a = Random.Range(0, 2) == 0 ? -5 : 5;
            GameObject obj= Instantiate(place[0], new Vector3(transform.position.x+a,transform.position.y,transform.position.z+i*20), Quaternion.identity);
            obj.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
