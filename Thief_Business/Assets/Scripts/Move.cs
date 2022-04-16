using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = loook.position;
        //transform.eulerAngles = new Vector3(transform.rotation.x,loook.rotation.y, transform.rotation.z);

         //transform.LookAt(loook);
        transform.position += Vector3.forward* speed*Time.deltaTime;
    }
}
