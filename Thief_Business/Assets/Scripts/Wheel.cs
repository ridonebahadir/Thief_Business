using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class Wheel : MonoBehaviour
{
    public GameManager gameManager;
    public Animator anim;
    public RectTransform rectTransform;
    public GameObject whellPanel;
    private void Start()
    {
        
    }
    void Update()
    {
        float zRotation = rectTransform.localEulerAngles.z;
       
        

        if (Input.GetMouseButtonDown(0))
        {
            anim.enabled=false;

            if (Mathf.Clamp(zRotation, 180, 216)==zRotation) gameManager.money *= 3;
            if (Mathf.Clamp(zRotation, 216, 252)==zRotation) gameManager.money *= 4;
            if (Mathf.Clamp(zRotation, 252, 288)==zRotation) gameManager.money *= 5;
            if (Mathf.Clamp(zRotation, 288, 324)==zRotation) gameManager.money *= 3;
            if (Mathf.Clamp(zRotation, 324, 360)==zRotation) gameManager.money *= 4;
            gameManager.moneyText.text = gameManager.money.ToString();
            Invoke("Late",2f);

        }
    }
    void Late()
    {
        whellPanel.SetActive(false);
    }
}
