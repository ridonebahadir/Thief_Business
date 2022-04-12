using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOMove(transform.position + new Vector3(1 * dynamicJoystick.Horizontal * speed * 30 * Time.deltaTime, 0,30*speed*Time.deltaTime) , 2f).SetEase(Ease.OutSine);
    }
}
