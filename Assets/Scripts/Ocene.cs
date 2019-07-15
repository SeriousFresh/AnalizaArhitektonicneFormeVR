using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Ocene : MonoBehaviour
{
    private Atribut[] atributi;
    private int trenutni;
    
    public GameObject[] ocene;
    public GameObject[] teksovi;
    //public Image[] slikeImage;
    private int marker;

    public StringBuilder sb;

    public string nazivModela;

    public PromenaModela promenaModela;

    // Start is called before the first frame update
    void Start()
    {
        trenutni = 0;
        VratiBoje();
        initA();
        sb = new StringBuilder();



    }

    private void VratiBoje()
    {
        marker = 3;
        for (int i = 0; i < ocene.Length; i++)
            ocene[i].GetComponent<Image>().color = new Color(255, 255, 255);
        ocene[marker].GetComponent<Image>().color = new Color(0, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            VratiBoje();
            promeniObjekte();
           
        }

        if(!Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ocene[marker].GetComponent<Image>().color = new Color(255, 255, 255);
            if (marker == 0)
                marker = 6;
            else marker--;

            ocene[marker].GetComponent<Image>().color = new Color(0, 255, 0);
        }
        if(!Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.RightArrow))
        {
            ocene[marker].GetComponent<Image>().color = new Color(255, 255, 255);
            if (marker == 6)
                marker = 0;
            else marker++;
            ocene[marker].GetComponent<Image>().color = new Color(0, 255, 0);
        }
    }

    void promeniObjekte()
    {
        DodajOcenu();

        if (trenutni == 14)
        {
            //PromeniScenu();
            
            Stampaj();
            promenaModela.PromeniModel();
            trenutni = 0;
        }
        else trenutni++;

        for (int i = 0; i < 7; i++)
            ocene[i].GetComponentInChildren<Text>().text = atributi[trenutni].brojevi[i];

        teksovi[0].GetComponentInChildren<Text>().text = atributi[trenutni].levo;
        teksovi[1].GetComponentInChildren<Text>().text = atributi[trenutni].desno;

    }

    private void Stampaj()
    {
        

        string directory = Application.dataPath + "/Ocene/";
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        string path = directory + nazivModela + ".txt";

        if(!File.Exists(path))
        {
            File.WriteAllText(path, "Model " + nazivModela + " ocene:\n");
        }

        string vreme = "Trenutak stampanja ocene: " + System.DateTime.Now + "\n";

        string linije = "------------------------------------------\n";

        StringBuilder s = new StringBuilder();
        s.Append(linije);
        s.Append(vreme);
        s.Append(sb.ToString());

        File.AppendAllText(path, s.ToString());

        sb.Clear();
    }

    private void PromeniScenu()
    {
        throw new NotImplementedException();
    }

    private void DodajOcenu()
    {
        sb.Append(atributi[trenutni].levo);
        sb.Append(" - ");
        sb.Append(atributi[trenutni].desno);
        sb.Append(": ");
        sb.Append(ocene[marker].GetComponentInChildren<Text>().text);     
        sb.Append("\n");
    }


    void initA()
    {
        atributi = new Atribut[15];

        for (int i = 0; i < 15; i++)
        {
            atributi[i] = new Atribut();
            switch (i)
            {
                case 0:
                    atributi[i].setMinus();
                    atributi[i].levo = "Neprijatno";
                    atributi[i].desno = "Prijatno";
                    break;
                case 1:
                    atributi[i].setMinus();
                    atributi[i].levo = "Obicno";
                    atributi[i].desno = "Neobicno";
                    break;
                case 2:
                    atributi[i].setMinus();
                    atributi[i].levo = "Ruzno";
                    atributi[i].desno = "Lepo";
                    break;
                case 3:
                    atributi[i].setMinus();
                    atributi[i].levo = "Nametiljivo";
                    atributi[i].desno = "Nenametiljvo";
                    break;
                case 4:
                    atributi[i].setMinus();
                    atributi[i].levo = "Napeto";
                    atributi[i].desno = "Opusteno";
                    break;
                case 5:
                    atributi[i].setMinus();
                    atributi[i].levo = "Bolesno";
                    atributi[i].desno = "Zdravo";
                    break;
                case 6:
                    atributi[i].setMinus();
                    atributi[i].levo = "Nesredjeno";
                    atributi[i].desno = "Sredjeno";
                    break;
                case 7:
                    atributi[i].setMinus();
                    atributi[i].levo = "Neupecatljivo";
                    atributi[i].desno = "Upecatljivo";
                    break;
                case 8:
                    atributi[i].setMinus();
                    atributi[i].levo = "Strogo";
                    atributi[i].desno = "Blago";
                    break;
                case 9:
                    atributi[i].setMinus();
                    atributi[i].levo = "Nepravilno";
                    atributi[i].desno = "Pravilno";
                    break;
                case 10:
                    atributi[i].setMinus();
                    atributi[i].levo = "Nemastovito";
                    atributi[i].desno = "Mastovito";
                    break;
                case 11:
                    atributi[i].setMinus();
                    atributi[i].levo = "Nejasno";
                    atributi[i].desno = "Jasno";
                    break;
                case 12:
                    atributi[i].setPlus();
                    atributi[i].levo = "";
                    atributi[i].desno = "Opcinjavajuce";
                    break;
                case 13:
                    atributi[i].setPlus();
                    atributi[i].levo = "";
                    atributi[i].desno = "Izuzetno";
                    break;
                case 14:
                    atributi[i].setPlus();
                    atributi[i].levo = "";
                    atributi[i].desno = "Neodoljivo";
                    break;

            }
        }
    }
}
