using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    public Transform kucak;
    public GameObject money;
    public Projectile projectile;
    public Transform projectileTrans;
    public bool turn;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Bank")
        {
            
            if (turn)
            {
                GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
                obj.transform.parent = projectileTrans;
                projectile.listObj.Add(obj.transform);

            }
            
            



        }
    }
}
