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
