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
    public GameObject done;
    public Text paraMiktari;
    public Button wheelButton;

    [Header("CLOSE")]
    public GameObject[] closeObj;
    public void WheelButton()
    {
        human.gameObject.transform.GetChild(0).DOScale(new Vector3(13, 13, 13), 0.2f).SetEase(Ease.InSine);
        human.gameObject.transform.GetChild(1).DOScale(new Vector3(13, 13, 13), 0.2f).SetEase(Ease.InSine);
        foreach (var item in closeObj)
        {
            item.SetActive(false);
        }
        wheelButton.interactable = false;
        run = false;
        anim.enabled = false;
      
        float zRotation = rectTransform.localEulerAngles.z;
        if (Mathf.Clamp(zRotation, 180, 216) == zRotation) gameManager.money *= 3;
        if (Mathf.Clamp(zRotation, 216, 252) == zRotation) gameManager.money *= 4;
        if (Mathf.Clamp(zRotation, 252, 288) == zRotation) gameManager.money *= 5;
        if (Mathf.Clamp(zRotation, 288, 324) == zRotation) gameManager.money *= 3;
        if (Mathf.Clamp(zRotation, 324, 360) == zRotation) gameManager.money *= 4;
        gameManager.moneyText.text = gameManager.money.ToString()+"M";
        humanAnim.SetBool("Stop", true);
        Invoke("Late", 2f);
    }
    bool run = true;
    private void Update()
    {
        if (run)
        {
            float zRotation = rectTransform.localEulerAngles.z;

            if (Mathf.Clamp(zRotation, 180, 216) == zRotation) { int possible = gameManager.money; possible *= 3; paraMiktari.text = possible.ToString()+"M"; }
            if (Mathf.Clamp(zRotation, 216, 252) == zRotation) { int possible = gameManager.money; possible *= 4; paraMiktari.text = possible.ToString()+ "M"; }
            if (Mathf.Clamp(zRotation, 252, 288) == zRotation) { int possible = gameManager.money; possible *= 5; paraMiktari.text = possible.ToString()+ "M"; }
            if (Mathf.Clamp(zRotation, 288, 324) == zRotation) { int possible = gameManager.money; possible *= 4; paraMiktari.text = possible.ToString()+ "M"; }
            if (Mathf.Clamp(zRotation, 324, 360) == zRotation) { int possible = gameManager.money; possible *= 3; paraMiktari.text = possible.ToString()+ "M"; }
        }
        else
        {
            paraMiktari.text = gameManager.moneyText.text;
        }
       
    }
    void Late()
    {
        whellPanel.SetActive(false);
        human.Map();
        dynamicJoystick.AxisOptions = AxisOptions.Both;
        mainCamera.transform.DOLocalMove(new Vector3(0,35,-20), 1.5f).OnComplete(() => End());
        mainCamera.transform.DOLocalRotate(new Vector3(45,0,0), 1.5f);

       
       
        
    }

    void End()
    {
        done.SetActive(true);
        Destroy(whellPanel.gameObject);
    }
}
