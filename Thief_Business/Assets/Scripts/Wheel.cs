using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class Wheel : MonoBehaviour
{
    public Animator anim;
    public RectTransform rectTransform;

    private void Start()
    {
        
    }
    void Update()
    {
        float zRotation = rectTransform.localEulerAngles.z;
       
        

        if (Input.GetMouseButton(0))
        {
            anim.enabled=false;

            if (Mathf.Clamp(zRotation, 180, 210)==zRotation) Debug.Log("1x");
            if (Mathf.Clamp(zRotation, 210, 240)==zRotation) Debug.Log("2x");
            if (Mathf.Clamp(zRotation, 240, 270)==zRotation) Debug.Log("3x");
            if (Mathf.Clamp(zRotation, 270, 300)==zRotation) Debug.Log("4x");
            if (Mathf.Clamp(zRotation, 300, 330)==zRotation) Debug.Log("5x");
            if (Mathf.Clamp(zRotation, 330, 360)==zRotation) Debug.Log("6x");


        }
    }
}
