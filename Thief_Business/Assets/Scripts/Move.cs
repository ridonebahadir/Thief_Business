using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    
   
    // Update is called once per frame
    void Update()
    {
       
            transform.position += Vector3.forward * speed * Time.deltaTime;
        
        //transform.position = loook.position;
        //transform.eulerAngles = new Vector3(transform.rotation.x,loook.rotation.y, transform.rotation.z);

         //transform.LookAt(loook);
        
    }
}
