using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    public Human human;
    public GameObject flash;
    private int costBuild;
    private int startCost;
    
    public GameManager gameManager;
    public GameObject[] build;
    private int updateCost;
    public int[] upgradeCost;
    private Renderer color;
    private TextMesh valueUpgradeText;
    
    float count;
    bool pay;
    bool onePlayT�me;
    int remainingMoney;
    public int id;

    public Transform voteStates;
    private Animator humanAnim;
    private void Start()
    {
        humanAnim = human.GetComponent<Animator>();
        valueUpgradeText = transform.parent.GetChild(1).GetComponent<TextMesh>();
        color = GetComponent<Renderer>();
        for (int i = 0; i < upgradeCost.Length; i++)
        {
            startCost += upgradeCost[i];
        }
        
        costBuild = PlayerPrefs.GetInt("CostBuild"+id, startCost);
       
        UpGrade();
       
    }
    bool textBool;
    private void Update()
    {
       

        if (textBool)
        {
            gameManager.moneyText.text = gameManager.money.ToString();
        }
        if (pay)
        {
            count += 1 * Time.deltaTime;
            if (count>2)
            {
               
                if (!onePlayT�me)
                {
                    
                    Pay();

                }
                
            }
        }
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Human")
        {
             remainingMoney = gameManager.money - updateCost;
            if (remainingMoney > 0)
            {
                color.material.color = Color.green;
                onePlayT�me = false;
                pay = true;
                voteStates.GetComponent<VotesReceived>().amount = PlayerPrefs.GetFloat("Vote" + id, 0f);
                
            }
            else
            {
                color.material.color = Color.red;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Human")
        {
           
             color.material.color = Color.white;
            pay = false;
            count = 0;
        }
        
    }
    void Pay()
    {
        human.transform.DOMove(transform.position, 1.5f).OnComplete(() => humanAnim.SetBool("Talk", true)); flash.SetActive(true);
        human.transform.GetChild(0).DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        human.map = false;
        voteStates.GetComponent<VotesReceived>().fill = true;
        

        costBuild -= updateCost;

        DOTween.To(() => updateCost, x => updateCost = x, 0, 6f)
        .OnUpdate(() => { 
            valueUpgradeText.text = updateCost.ToString(); 
            Vibration.Vibrate(50);
            
        });

        textBool = true;
            DOTween.To(() => gameManager.money, x => gameManager.money = x, remainingMoney, 6f)
           .OnComplete(() => End());
            

        onePlayT�me = true;
    }
    void End()
    {
        flash.SetActive(false);
        humanAnim.SetBool("Talk", false);
        human.map = true;
        voteStates.GetComponent<VotesReceived>().fill = false;
        voteStates.GetComponent<VotesReceived>().elapsedTime = 0;
        voteStates.GetComponent<VotesReceived>().AgainRun();

        color.material.color = Color.red;
        textBool = false;
        UpGrade();

        PlayerPrefs.SetInt("CostBuild" + id, costBuild);
    }
   
    void UpGrade()
    {
       
        updateCost = upgradeCost[0];
        if (costBuild <= startCost - upgradeCost[0])
        {
           
            updateCost = upgradeCost[1];
            ObjActive(0);

        }
        if (costBuild <= startCost - upgradeCost[1])
        {
          
            updateCost = upgradeCost[2];
            ObjActive(1);
        }
        if (costBuild <= startCost - upgradeCost[2])
        {
            
            ObjActive(2);
            transform.parent.gameObject.SetActive(false);
            
        }
        valueUpgradeText.text = updateCost.ToString();

        
    }

    
    void ObjActive(int value)
    {
        
            for (int i = 0; i <= value; i++)
            {
                build[i].SetActive(true);
            }
        
       
        

        build[value].transform.DOPunchScale(new Vector3(2, 2, 2), .25f);
    }

}
