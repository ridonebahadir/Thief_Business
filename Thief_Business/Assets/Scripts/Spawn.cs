using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] place;
    public int countSpawn;
    public Transform holder_bus;
    public Transform holder_thief;
    void Start()
    {
        for (int i = 1; i < holder_bus.childCount; i++)
        {
           
            GameObject obj= Instantiate(place[0],holder_bus.GetChild(i).transform);
            obj.transform.localPosition = new Vector3(-5, 0, 0);
          
        }

        for (int i = 1; i < holder_thief.childCount; i++)
        {

            GameObject obj = Instantiate(place[0], holder_thief.GetChild(i).transform);
            obj.transform.localPosition = new Vector3(-5, 0, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
