using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placesss : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).GetChild(0).gameObject.GetComponent<Place>().id = i;
        }
        
    }
}
