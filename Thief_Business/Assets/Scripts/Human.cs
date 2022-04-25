using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameManager gameManager;
    public DynamicJoystick dynamicJoystick;
    public float speed;
    bool nextStep;
    public GameObject wheelPanel;
    public Animator anim;
    //public bool map;
    public Transform humanCharacter;
    [Header("BORDER")]
    public float minX = -10;
    public float maxX = 10;
    public float minZ;
    public float maxZ = 500;
    public bool movement;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
        transform.localPosition = newPosition;




        if (!nextStep)
        {
            transform.DOMove(transform.position + new Vector3( dynamicJoystick.Horizontal * speed * Time.deltaTime, 0, speed * Time.deltaTime), 0.1f);

        }
       
        if (movement)
        {
            float horizontalInput = dynamicJoystick.Horizontal;
            float verticalInput = dynamicJoystick.Vertical;

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);




            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                humanCharacter.transform.rotation = Quaternion.RotateTowards(humanCharacter.transform.rotation, toRotation, 720 * Time.deltaTime);
            }
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("Walk", true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("Walk", false);
            }
        }

    }

    private void End()
    {
        movement = true;
        minZ = 85;

    }
    public void Map()
    {
        transform.DOLocalMove(new Vector3(0, -15, 110), 1f).OnComplete(() => End());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Banner")
        {
            gameManager.money += 3;
            other.gameObject.SetActive(false);
            gameManager.moneyText.text = gameManager.money.ToString();
        }
        if (other.tag=="Wheel")
        {
          
            other.gameObject.SetActive(false);
            anim.SetBool("Victory",true);
            nextStep = true;
            wheelPanel.SetActive(true);
            minX = -100;
            maxX = 100;
           
            
        }
      
       

    }
    
}
