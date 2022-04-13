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
            
            Invoke("Late",2f);
            StopRun();
            anim.SetBool("Victory",true);
            printer.enabled = true;
            projectile.touch = true;
            projectile.isPrinter = true;
           
            //wheelPanel.SetActive(true);
        }

        if (other.tag=="Door")
        {
            if (isMoneyHave)
            {
                gameManager.money += other.GetComponent<Door>().value;
                gameManager.moneyText.text = gameManager.money.ToString();
                //int random = Random.Range(0,money.Length);
                if (gameManager.money>0)
                {
                    Instantiate(moneyBurst, kucak.position, Quaternion.identity);
                    for (int i = 0; i <3; i++)
                    {
                        GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
                        obj.transform.parent = kucak;
                        projectile.listObj.Add(obj.transform);
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
                police = true;
                Invoke("StopRun", 0.5f);
                other.transform.GetChild(0).GetComponent<Animator>().applyRootMotion = true;
                other.transform.GetChild(0).GetComponent<Animator>().SetBool("Punch", true);
            }
            else
            {
                other.transform.GetChild(0).GetComponent<Animator>().applyRootMotion = true;
                other.transform.GetChild(0).GetComponent<Animator>().SetBool("SideStep", true);
            }
        }

    }
   
    void Late()
    {
        projectile.enabled = false;
        anim.SetBool("Jump", true);
        transform.DOJump(targetPos.position, 15, 1, 3f, false).OnComplete(() => End());
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
            anim.applyRootMotion = true;
            anim.SetBool("Fall",true);
            thiefAnim.SetBool("Sad", true);
            pathFollowerThief.enabled = false;
        }
       
        boxCollider.enabled = false;
        move.enabled = false;
        pathFollower.enabled = false;
        
    }
   
}
