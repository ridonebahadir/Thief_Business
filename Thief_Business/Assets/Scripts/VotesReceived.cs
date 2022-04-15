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
    public bool fill;
    float bolum;
    void Start()
    {
        bolum = 1/manyBuild;
        image = GetComponent<Image>();
        amount = PlayerPrefs.GetFloat("Vote"+id,0f);
        image.fillAmount = amount;
        
    }
    private void Update()
    {
        if (fill)
        {
            StartCoroutine(FillAmount());
            
        }
    }
    public float elapsedTime = 0;
    IEnumerator FillAmount()
    {
        amount = PlayerPrefs.GetFloat("Vote" + id, 0f);

        float duration = 3f;
           

        while (elapsedTime < duration)
        {
            image.fillAmount = Mathf.Lerp(amount, amount+ bolum, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
       

    }
    public void AgainRun()
    {
        PlayerPrefs.SetFloat("Vote" + id, amount + bolum);
    }
}
