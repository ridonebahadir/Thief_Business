using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    private int costBuild;
    private int startCost;
    
    public GameManager gameManager;
    public GameObject[] build;
    private int updateCost;
    public int[] upgradeCost;
    private Renderer color;
    public TextMesh valueUpgradeText;

    float count;
    bool pay;
    bool onePlayTÝme;
    int remainingMoney;
    private void Start()
    {
        color = GetComponent<Renderer>();
        for (int i = 0; i < upgradeCost.Length; i++)
        {
            startCost += upgradeCost[i];
        }
        
        costBuild = PlayerPrefs.GetInt("CostBuild", startCost);
       
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
                if (!onePlayTÝme)
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
                onePlayTÝme = false;
                pay = true;
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

        
        
            
            costBuild -= updateCost;
            textBool = true;
            DOTween.To(() => gameManager.money, x => gameManager.money = x, remainingMoney, 3f)
           .OnComplete(() => End());

        
        onePlayTÝme = true;
    }
    void End()
    {


        color.material.color = Color.red;
        textBool = false;
        UpGrade();

        PlayerPrefs.SetInt("CostBuild", costBuild);
    }
   
    void UpGrade()
    {
       
        updateCost = upgradeCost[0];
        if (costBuild <= startCost - upgradeCost[0])
        {
            updateCost = upgradeCost[1];
            build[0].SetActive(true);
            
        }
        if (costBuild <= startCost - upgradeCost[1])
        {
            updateCost = upgradeCost[2];
            build[0].SetActive(true);
            build[1].SetActive(true);
        }
        if (costBuild <= startCost - upgradeCost[2])
        {
           
            build[0].SetActive(true);
            build[1].SetActive(true);
            build[2].SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
        valueUpgradeText.text = updateCost.ToString();
    }
}
