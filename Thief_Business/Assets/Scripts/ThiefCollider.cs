using DG.Tweening;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCollider : MonoBehaviour
{
    public Animator businessAnim;
    public BusinessManCollider businessManCollider;
    public bool isMoneyHave = true;
    [Header("MONEY")]
    public GameManager gameManager;

    [Header("PRÝNT AREA")]
    public GameObject wheelPanel;
    private PathFollower pathFollower;
    public Transform targetPos;
    private BoxCollider boxCollider;

    [Header("COLLECT")]
    public Transform kucak;
    public GameObject money;
    public GameObject moneyBurst;
    public Projectile projectile;
    public Transform projectileTrans;
    public Animator anim;
  

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        pathFollower = GetComponent<PathFollower>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PrintArea")
        {
            if (gameManager.money<=0)
            {
                anim.SetBool("Sad", true);
                businessManCollider.StopRun();
                pathFollower.enabled = false;
                businessAnim.SetBool("Sad", true);
            }
            else
            {
                boxCollider.enabled = false;
                Invoke("Late", 3f);
                anim.SetBool("Victory", true);
                projectile.speed = 10;
                projectile.touch = true;
                projectile.isPrinter = true;
                pathFollower.enabled = false;
            }
            
            //wheelPanel.SetActive(true);
        }
        if (other.tag=="Door")
        {
            if (isMoneyHave)
            {
               
                int value = other.GetComponent<Door>().value;
                gameManager.money += value;
                gameManager.moneyText.text = gameManager.money.ToString();
                //int random = Random.Range(0,money.Length);
                if (gameManager.money>0)
                {
                    if (value > 0)
                    {
                        Vibration.Vibrate(100);
                        Instantiate(moneyBurst, kucak.position, Quaternion.identity);
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
                            obj.transform.parent = kucak;
                            projectile.listObj.Add(obj.transform);
                        }
                    }
                    else
                    {
                        Vibration.Vibrate(1000);
                    }
                    
                }
                else
                {
                   
                    foreach (var item in projectile.listObj)
                    {
                        Destroy(item.gameObject);
                    }
                    projectile.listObj.Clear();

                }

            }
           
           
        }
        if (other.tag=="Police")
        {
            if (isMoneyHave)
            {
                Vibration.Vibrate(1000);

                Invoke("StopLatePolice", 0.25f);
                other.transform.GetChild(0).GetComponent<Animator>().applyRootMotion = true;
                other.transform.GetChild(0).GetComponent<Animator>().SetBool("Punch", true);
            }
            else
            {
                other.transform.GetChild(0).GetComponent<Animator>().applyRootMotion = true;
                other.transform.GetChild(0).GetComponent<Animator>().SetBool("SideStep", true);
            }
            
        }
        if (other.tag=="Money")
        {
            isMoneyHave = true;
            gameManager.money += 5;
            gameManager.moneyText.text = gameManager.money.ToString();
            projectile.throwObj = true;
            projectile.touch = true;
            other.gameObject.SetActive(false);
            GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
            obj.transform.parent = kucak;
            projectile.listObj.Add(obj.transform);
        }
    }
    void StopLatePolice()
    {
        foreach (var item in projectile.listObj)
        {
            Destroy(item.gameObject);
        }
        projectile.listObj.Clear();
        
        anim.applyRootMotion = true;
        anim.SetBool("Fall", true);
        businessAnim.SetBool("Sad", true);
        businessManCollider.StopRun();
        pathFollower.enabled = false;
        Instantiate(moneyBurst, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
    }
    void Late()
    {
        anim.SetBool("Jump", true);
        transform.DOJump(targetPos.position, 15, 1, 1.5f, false).OnComplete(() => gameObject.SetActive(false)).SetEase(Ease.InOutQuad);
    }
}
