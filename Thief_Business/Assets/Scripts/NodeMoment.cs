using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMoment : MonoBehaviour
{
    public Transform connectedNode;
   
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x,connectedNode.position.x,Time.deltaTime*20), 
            transform.position.y, 
            connectedNode.transform.position.z);
    }
}
