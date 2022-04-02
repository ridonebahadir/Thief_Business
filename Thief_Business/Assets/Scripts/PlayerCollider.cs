using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    public Transform kucak;
    public GameObject[] money;
    public GameObject moneyBurst;
    public Projectile projectile;
    public Transform projectileTrans;
   
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Bank")
        {

            int random = Random.Range(0,money.Length);
            Instantiate(moneyBurst, kucak.position, Quaternion.identity);
            GameObject obj = Instantiate(money[random], kucak.position, Quaternion.identity);
            obj.transform.parent = projectileTrans;
            projectile.listObj.Add(obj.transform);

            
            
            



        }
    }
}
