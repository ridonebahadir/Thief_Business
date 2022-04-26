using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public int count;
    public float speed;
    public float arcHeight;
    public GameObject banner;
    private Vector3 nextPos;
    public Transform targetPos;
    public GameManager gameManager;

    void Start()
    {
        count = gameManager.money/2;
        StartCoroutine(TargetChange());
       
    }
    
   

   

    
    IEnumerator TargetChange()
    {
        for (int i = 0; i < count; i++)
        {
            float random = Random.Range(-3, 3);
            GameObject obj = Instantiate(banner);
            banner = obj;
            targetPos.localPosition = new Vector3(random, 0, i + 10);
            banner.transform.position = targetPos.position;
            banner.transform.DOPunchScale(new Vector3(2, 2, 2), .05f);
            //int randomIndex = Random.Range(0, 3);
            //float randomFloatFromNumbers = numbers[randomIndex];


            //banner.transform.DOJump(new Vector3(targetPos.position.x, targetPos.position.y, targetPos.position.z), 15, 1, 0.8f, false);
            yield return new WaitForSeconds(0.1f);
        }
           
        
        
    }

    
}
