using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromenaModela : MonoBehaviour
{
    public GameObject[] modeli;
    private bool[] predjeni;
    private int trenutni;
    // Start is called before the first frame update
    void Start()
    {
        predjeni = new bool[modeli.Length];
        trenutni = Random.Range(0, modeli.Length);
        predjeni[trenutni] = true;
        modeli[trenutni].SetActive(true);
    }

    private bool SviPredjeni()
    {
        foreach(bool b in predjeni)
        {
            if (!b) return false;

        }
        return true;
    }

    // Update is called once per frame
    public void PromeniModel()
    {
        modeli[trenutni].SetActive(false);
        
        if(!SviPredjeni())
        {
            do
            {
                trenutni = Random.Range(0, 10);
            } while (predjeni[trenutni]);
            predjeni[trenutni] = true ;
            modeli[trenutni].SetActive(true);
        }
        else
        {
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;

        

        }

    }
}
