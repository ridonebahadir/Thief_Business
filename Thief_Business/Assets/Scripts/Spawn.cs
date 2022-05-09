using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] businessPlace;
    public GameObject police;
    public GameObject money;
   

    public GameObject[] thiefPlace;
    

    public int countSpawn;
    public Transform holder_bus;
    public Transform holder_thief;
    int side;
    void Start()
    {
        side = Random.Range(0, 2);
        if (side==0)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject objMoney = Instantiate(money, transform.position, Quaternion.Euler(0, 90, 0), holder_thief.GetChild(0).transform);
                objMoney.transform.localPosition = new Vector3(0, 1, 50) + new Vector3(0, 0, i * 5);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject objMoney = Instantiate(money, transform.position, Quaternion.Euler(0, 90, 0), holder_bus.GetChild(0).transform);
                objMoney.transform.localPosition = new Vector3(0, 1, 50) + new Vector3(0, 0, i * 5);
            }
        }
        

        int randomPoliceBusinessplace = Random.Range(1,holder_bus.childCount);
        GameObject objPolice = Instantiate(police, holder_bus.GetChild(randomPoliceBusinessplace).transform);
        objPolice.transform.localPosition = new Vector3(0, 5, 0);

        int randomPoliceThiefplace = Random.Range(1, holder_thief.childCount);
        GameObject objj = Instantiate(police, holder_thief.GetChild(randomPoliceThiefplace).transform);
        objj.transform.localPosition = new Vector3(0, 5, 0);

        for (int i = 1; i < holder_bus.childCount; i++)
        {
            if (i==randomPoliceBusinessplace) i++;
            if (i == holder_bus.childCount) break;
            int random = Random.Range(0, businessPlace.Length);
            GameObject obj= Instantiate(businessPlace[0],holder_bus.GetChild(i).transform);
            obj.transform.localPosition = new Vector3(0, 4, 0);
          
        }

        for (int i = 1; i < holder_thief.childCount; i++)
        {
            if (i == randomPoliceThiefplace) i++;
            if (i == holder_thief.childCount) break;
            int random = Random.Range(0,thiefPlace.Length);
            GameObject obj = Instantiate(thiefPlace[0], holder_thief.GetChild(i).transform);
            obj.transform.localPosition = new Vector3(0, 4, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
