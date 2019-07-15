using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atribut : MonoBehaviour
{
    public string levo;
    public string desno;
    public string[] brojevi;
    //public bool tipMinus;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setMinus()
    {
        brojevi = new string[7];
        brojevi[0] = "-3";
        brojevi[1] = "-2";
        brojevi[2] = "-1";
        brojevi[3] = "0";
        brojevi[4] = "1";
        brojevi[5] = "2";
        brojevi[6] = "3";
    }

    public void setPlus()
    {
        brojevi = new string[7];
        brojevi[0] = "1";
        brojevi[1] = "2";
        brojevi[2] = "3";
        brojevi[3] = "4";
        brojevi[4] = "5";
        brojevi[5] = "6";
        brojevi[6] = "7";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
