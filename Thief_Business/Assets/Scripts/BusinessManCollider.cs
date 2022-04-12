using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;
using DG.Tweening;

public class BusinessManCollider : MonoBehaviour
{
    [Header("PRÝNT AREA")]
    public Move move;
    public Printer printer;
    public GameObject wheelPanel;
    private PathFollower pathFollower;
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
            boxCollider.enabled = false;
            Invoke("Late",2f);
            anim.SetBool("Victory",true);
            printer.enabled = true;
            projectile.touch = true;
            projectile.isPrinter = true;
            move.enabled = false;
            pathFollower.enabled = false;
            //wheelPanel.SetActive(true);
        }

        if (other.tag=="Bank")
        {

            //int random = Random.Range(0,money.Length);
            Instantiate(moneyBurst, kucak.position, Quaternion.identity);
            GameObject obj = Instantiate(money, kucak.position, Quaternion.identity);
            obj.transform.parent = kucak;
            projectile.listObj.Add(obj.transform);

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
}
