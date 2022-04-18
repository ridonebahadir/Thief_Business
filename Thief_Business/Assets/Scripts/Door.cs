using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int value;
    public bool manOrThief;

    public string[] manPozitive;
    public string[] manNegative;

    public string[] thiefPozitive;
    public string[] thiefNegative;

    private Renderer rd;
    public Material materialPositive; 
    public Material materialNegative; 
    void Start()
    {
        rd = GetComponent<Renderer>();
        int valueRandom = Random.Range(-5, 15);
        if (valueRandom==0)
        {
            valueRandom = 3;
        }
        
        if (manOrThief)
        {
            if (valueRandom>0)
            {
                rd.material = materialPositive;
                int random = Random.Range(0, manPozitive.Length);
                transform.parent.GetChild(1).GetComponent<TextMesh>().text = manPozitive[random];
                
            }
            else
            {
                rd.material= materialNegative;
                int random = Random.Range(0, manNegative.Length);
                transform.parent.GetChild(1).GetComponent<TextMesh>().text = manNegative[random];
            }
        }
        else
        {
            if (valueRandom>0)
            {
                rd.material = materialPositive;
                int random = Random.Range(0, thiefPozitive.Length);
                transform.parent.GetChild(1).GetComponent<TextMesh>().text = thiefPozitive[random];
            }
            else
            {
                rd.material = materialNegative;
                int random = Random.Range(0, thiefNegative.Length);
                transform.parent.GetChild(1).GetComponent<TextMesh>().text = thiefNegative[random];
            }
        }
        transform.parent.GetChild(0).GetComponent<Door>().value = valueRandom;
        transform.parent.GetChild(2).GetComponent<TextMesh>().text = valueRandom.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
