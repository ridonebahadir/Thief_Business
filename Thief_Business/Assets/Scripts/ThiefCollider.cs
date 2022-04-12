using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCollider : MonoBehaviour
{
    
    public Transform kucak;
    public GameObject money;
    public GameObject moneyBurst;
    public Projectile projectile;
    public Transform projectileTrans;
    public GameObject wheelPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wheel")
        {
            wheelPanel.SetActive(true);
        }
        if (other.tag=="Bank")
        {

            //int random = Random.Range(0,money.Length);
            Instantiate(moneyBurst, kucak.position, Quaternion.identity);
            GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
            obj.transform.parent = kucak;
            projectile.listObj.Add(obj.transform);
           
        }
    }
}
