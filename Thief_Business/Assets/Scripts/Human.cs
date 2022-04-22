using DG.Tweening;
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
    public bool map;
    public Transform humanCharacter;
    [Header("BORDER")]
    private float minX = -10;
    private float maxX = 10;
     float minZ;
    float maxZ = 500;
    bool border;
    bool moveFirst = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (border)
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
            transform.localPosition = newPosition;
        }
        if (moveFirst)
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
           
            transform.localPosition = newPosition;
        }


        if (!nextStep)
        {
            transform.DOMove(transform.position + new Vector3( dynamicJoystick.Horizontal * speed * Time.deltaTime, 0, speed * Time.deltaTime), 0.1f);

        }
        if (map)
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
                anim.SetBool("Walk",true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("Walk", false);
            }
        }

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
            moveFirst = false;
            other.gameObject.SetActive(false);
            anim.SetBool("Victory",true);
            nextStep = true;
            wheelPanel.SetActive(true);
            minX = -1000;
            maxX = 1000;
            minZ =85;
            
        }
        if (other.tag=="BorderVertical")
        {
            border = true;
            if (other.transform.position.x>0)
            {
                maxX = transform.localPosition.x;
            }
            else
            {
                minX = transform.localPosition.x;
            }
        }
        if (other.tag=="BorderHorizontal")
        {
            border = true;
            maxZ = transform.localPosition.z;
        }

    }
    
}
