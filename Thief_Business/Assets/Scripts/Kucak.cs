using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kucak : MonoBehaviour
{
    public Projectile projectile;
    public int asd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MoneyStash")
        {
            Vibration.Vibrate(25);
        }
    }


   //IEnumerator vibrationMoney()
   // {
   //     for (int i = 0; i < projectile.listObj.Count; i++)
   //     {
   //         Vibration.Vibrate(10);
   //         yield return new WaitForSeconds(0.05f);
   //     }
   // }
}
