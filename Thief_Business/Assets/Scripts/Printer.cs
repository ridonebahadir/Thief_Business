using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    int count = 20;
    public float speed;
    public float arcHeight;
    public GameObject banner;
    private Vector3 nextPos;
    public Transform targetPos;
    

    void Start()
    {

       


        StartCoroutine(TargetChange());
    }
    
   

    // Update is called once per frame
    void Update()
    {

        


    }
    public float[] numbers;
    IEnumerator TargetChange()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(banner,transform.position,Quaternion.identity);
            banner = obj;
            float random = Random.Range(-3,3);
            //int randomIndex = Random.Range(0, 3);
            //float randomFloatFromNumbers = numbers[randomIndex];

            targetPos.localPosition = new Vector3(random,0, i+10);
            banner.transform.DOJump(new Vector3(targetPos.position.x, targetPos.position.y, targetPos.position.z), 15, 1, 0.5f, false);
            yield return new WaitForSeconds(0.5f);
        }
           
        
        
    }

    
}
