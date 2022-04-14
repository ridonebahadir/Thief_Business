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
    public Human human;
    public DynamicJoystick dynamicJoystick;
    public Animator humanAnim;
    public Transform mainCamera;
   
    public void WheelButton()
    {
       
        anim.enabled = false;
        float zRotation = rectTransform.localEulerAngles.z;
        if (Mathf.Clamp(zRotation, 180, 216) == zRotation) gameManager.money *= 3;
        if (Mathf.Clamp(zRotation, 216, 252) == zRotation) gameManager.money *= 4;
        if (Mathf.Clamp(zRotation, 252, 288) == zRotation) gameManager.money *= 5;
        if (Mathf.Clamp(zRotation, 288, 324) == zRotation) gameManager.money *= 3;
        if (Mathf.Clamp(zRotation, 324, 360) == zRotation) gameManager.money *= 4;
        gameManager.moneyText.text = gameManager.money.ToString();
        humanAnim.SetBool("Stop", true);
        Invoke("Late", 2f);
    }
    void Late()
    {
        whellPanel.SetActive(false);
        human.map = true;
        dynamicJoystick.AxisOptions = AxisOptions.Both;
        mainCamera.transform.DOLocalMove(new Vector3(0,25,-10), 1.5f).OnComplete(() => End());
        mainCamera.transform.DOLocalRotate(new Vector3(30,0,0), 1.5f);

       
       
        
    }
    void End()
    {
        Destroy(whellPanel.gameObject);
    }
}
