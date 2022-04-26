using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;
using DG.Tweening;

public class BusinessManCollider : MonoBehaviour
{
    public bool isMoneyHave = false;
    public Animator thiefAnim;
    [Header("MONEY")]
    public GameManager gameManager;
    [Header("PRÝNT AREA")]
    public Move move;
    public Printer printer;
    public GameObject wheelPanel;
    private PathFollower pathFollower;
    public PathFollower pathFollowerThief;
    public Transform targetPos;
    private BoxCollider boxCollider;
    public GameObject Human;
    public GameObject moveobj;

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
        if (other.tag=="PrintArea")
        {
            if (gameManager.money<=0)
            {
                anim.SetBool("Sad", true);
                thiefAnim.SetBool("Sad", true);
            }
            else
            {
                boxCollider.enabled = false;
                if (isMoneyHave)
                {
                    Invoke("Late", 3f);
                    anim.SetBool("Victory", true);
                }

                else
                {
                    anim.SetBool("Sad", true);
                }
                projectile.speed = 10;
                printer.enabled = true;
                projectile.touch = true;
                projectile.isPrinter = true;
                

            }
            StopRun();

            //wheelPanel.SetActive(true);
        }

        if (other.tag=="Door")
        {
            if (isMoneyHave)
            {
                other.transform.GetChild(0).gameObject.SetActive(true);
                int value = other.GetComponent<Door>().value;
                gameManager.money += value;
                gameManager.moneyText.text = gameManager.money.ToString()+"M";
               
                //int random = Random.Range(0,money.Length);
                if (gameManager.money>0)
                {
                    if (value>0)
                    {
                        gameManager.MoneyCanvasPunch(true,0.15f);
                        Vibration.Vibrate(100);
                        //Instantiate(moneyBurst, kucak.position, Quaternion.identity);
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
                            obj.transform.parent = kucak;
                            projectile.listObj.Add(obj.transform);
                        }
                    }
                    else
                    {
                        gameManager.MoneyBackColorBad();
                        gameManager.MoneyCanvasPunch(true,0.15f);
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
        if (other.tag == "Police")
        {
            if (isMoneyHave)
            {
                gameManager.MoneyCanvasPunch(false, 0.15f);
                gameManager.money = 0;
                gameManager.moneyText.text = gameManager.money.ToString()+"M";
                Vibration.Vibrate(1000);
                police = true;
                Invoke("StopRun", 0.25f);
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
            gameManager.MoneyCanvasPunch(true,0.05f);
            isMoneyHave = true;
            gameManager.money += 5;
            gameManager.moneyText.text = gameManager.money.ToString()+"M";
            projectile.throwObj = false;
            projectile.touch = true;
            other.gameObject.SetActive(false);
            GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
            obj.transform.parent = kucak;
            projectile.listObj.Add(obj.transform);
            
        }

    }
   
    void Late()
    {
        projectile.enabled = false;
        anim.SetBool("Jump", true);
        transform.DOJump(targetPos.position, 15, 1, 1.5f, false).OnComplete(() => End()).SetEase(Ease.InOutQuad);
    }
    void End()
    {
        projectileTrans.gameObject.SetActive(false);
        moveobj.transform.parent = Human.transform;
        //move.enabled = true;
        Human.SetActive(true);
        gameObject.SetActive(false);

    }
    bool police;
    public void StopRun()
    {
        if (police)
        {
            foreach (var item in projectile.listObj)
            {
                Destroy(item.gameObject);
            }
            projectile.listObj.Clear();
           
            anim.applyRootMotion = true;
            anim.SetBool("Fall",true);
            thiefAnim.SetBool("Sad", true);
            pathFollowerThief.enabled = false;
            Instantiate(moneyBurst, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        }
       
        boxCollider.enabled = false;
        move.enabled = false;
        pathFollower.enabled = false;
        
    }
   
}
