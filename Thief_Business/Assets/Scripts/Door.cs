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
    void Start()
    {
        int valueRandom = Random.Range(-5, 15);

        if (manOrThief)
        {
            if (valueRandom>0)
            {
                int random = Random.Range(0, manPozitive.Length);
                transform.parent.GetChild(1).GetComponent<TextMesh>().text = manPozitive[random];
            }
            else
            {
                int random = Random.Range(0, manNegative.Length);
                transform.parent.GetChild(1).GetComponent<TextMesh>().text = manNegative[random];
            }
        }
        else
        {
            if (valueRandom>0)
            {
                int random = Random.Range(0, thiefPozitive.Length);
                transform.parent.GetChild(1).GetComponent<TextMesh>().text = thiefPozitive[random];
            }
            else
            {
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
