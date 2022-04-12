using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] businessPlace;
   

    public GameObject[] thiefPlace;
    

    public int countSpawn;
    public Transform holder_bus;
    public Transform holder_thief;
    void Start()
    {
        for (int i = 1; i < holder_bus.childCount; i++)
        {
           
            GameObject obj= Instantiate(businessPlace[0],holder_bus.GetChild(i).transform);
           

            

            obj.transform.localPosition = new Vector3(0, 4, 0);
          
        }

        for (int i = 1; i < holder_thief.childCount; i++)
        {

            GameObject obj = Instantiate(thiefPlace[0], holder_thief.GetChild(i).transform);
            

            //int valueRandom = Random.Range(0, 2) == 0 ? -10 : 10;
            //obj.transform.GetChild(0).GetComponent<Door>().value = valueRandom;
            //obj.transform.GetChild(2).GetComponent<TextMesh>().text = valueRandom.ToString();

            obj.transform.localPosition = new Vector3(0, 4, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
