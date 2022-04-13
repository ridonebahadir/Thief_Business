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
                Invoke("Late", 2f);
                anim.SetBool("Victory", true);
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
                gameManager.money += other.GetComponent<Door>().value;
                gameManager.moneyText.text = gameManager.money.ToString();
                //int random = Random.Range(0,money.Length);
                if (gameManager.money>0)
                {
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
                Invoke("StopLatePolice", 0.5f);
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
    void StopLatePolice()
    {
        anim.applyRootMotion = true;
        anim.SetBool("Fall", true);
        businessAnim.SetBool("Sad", true);
        businessManCollider.StopRun();
        pathFollower.enabled = false;
    }
    void Late()
    {
        anim.SetBool("Jump", true);
        transform.DOJump(targetPos.position, 15, 1, 3f, false).OnComplete(() => gameObject.SetActive(false));
    }
}
