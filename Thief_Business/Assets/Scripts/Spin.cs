using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.PickerWheelUI;
public class Spin : MonoBehaviour
{
    public Button spinButton;
    public Button spinStopButton;
    public Text spinText;
    public PickerWheel pickerWheel;
    void Start()
    {
        spinButton.onClick.AddListener(() => {
            spinButton.interactable = false;
            spinText.text = "Spinning";
            pickerWheel.OnSpinStart(()=> {
                Debug.Log("Spin started");
            });

            pickerWheel.OnSpinEnd(wheelPiece => {
                Debug.Log("Spin end:"+wheelPiece.Label+"Amount:"+wheelPiece.Amount);
               spinText.text = "Spin";
            });

            pickerWheel.Spin();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
