using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VotesReceived : MonoBehaviour
{
    public int id;
    private Image image;
    public float amount;
    public float manyBuild;
    //public bool fill;
    float bolum;
   
    public int colorValue;
    public Place place;
    void Start()
    {
        image = GetComponent<Image>();
        colorValue = PlayerPrefs.GetInt("Color" + id,2);
        image.color = place.votesColor[colorValue];
        bolum = 1/manyBuild;
       
        amount = PlayerPrefs.GetFloat("Vote"+id,0f);
        image.fillAmount = amount;
        
    }
    private void Update()
    {
        //if (fill)
        //{
            
        //    StartCoroutine(FillAmount());
            
        //}
    }
    public void Fill()
    {
        amount = PlayerPrefs.GetFloat("Vote" + id, 0f);

        
        DOTween.To(() => amount, x => amount = x, amount + bolum, 6f)
           .OnUpdate(() => { image.fillAmount = amount; });
        //image.fillAmount = Mathf.Lerp(amount, amount + bolum, elapsedTime / duration);
        //StartCoroutine(FillAmount());
        //elapsedTime = 0;
    }
    public float elapsedTime = 0;
    float duration = 10f;
    //IEnumerator FillAmount()
    //{
    //    amount = PlayerPrefs.GetFloat("Vote" + id, 0f);

        


    //    while (fill)
    //    {
            
    //        image.fillAmount = Mathf.Lerp(amount, amount+ bolum, elapsedTime / duration);
    //        elapsedTime += Time.deltaTime;
    //        if (amount>=amount+bolum)
    //        {
    //            fill = false;
    //        }
    //        yield return null;
    //    }
       
    //}
    public void AgainRun()
    {
        colorValue = PlayerPrefs.GetInt("votesColor");
        PlayerPrefs.SetInt("Color" + id, colorValue);
        PlayerPrefs.SetFloat("Vote" + id, amount);
    }
}
