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
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!nextStep)
        {
            transform.DOMove(transform.position + new Vector3(1 * dynamicJoystick.Horizontal * speed * 30 * Time.deltaTime, 0, 30 * speed * Time.deltaTime), 2f).SetEase(Ease.OutSine);

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
            if (Input.GetMouseButtonDown(0))
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
            anim.SetBool("Victory",true);
            nextStep = true;
            wheelPanel.SetActive(true);
            
        }
    }
}
