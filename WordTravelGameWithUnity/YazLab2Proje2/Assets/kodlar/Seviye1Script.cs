﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Seviye1Script : MonoBehaviour
{
    public Text[] butontxt = new Text[5];
    public GameObject tebriklerpanel,kaybettinizpanel,ipucupanel;
    public Button[] butons = new Button[5];
    List<Button> tiklananbutonlar = new List<Button>();
    public puanHesapla puanObject, sureObject;
    public Button sürebutonu, puanbutonu,sureeklebuton;
    public Text sürebutonutxt, puanbutonutxt,kelimetxt;
    public Text[] bulmacatxt = new Text[14];
    public int kelimesayisi = 0;
    public TimeManager1 tm1;
    public puanHesapla bulmaca;
    public SesKontrol sesler;
    public Button dgrsvy, tkrroyna, anamenuyedon,ipucubuton;
    public Kullanici kk;
    string ks = "harun-ömer-sefa-altan-burak-cihan";
    string k="ABA-ASA-ARA-ARI-AZI-BOR";
    string h = "A-B-I-O-R-S-Z";
    string[] harfler=new string[8];
    string[] kelimeler = new string[6];
    string[] b=new string[8];
    string[] m=new string[8];
    string ayrac = "-";
    int ipucutik = 0;

    void Start()
    {
        PlayerPrefs.SetString("harfler", h);
        PlayerPrefs.SetString("kelimeler", k);
        //PlayerPrefs.SetInt("harun", 0);
        sesler.oyunicisescal();
        puanbutonutxt.text = "Puan: 0";
        ipucupanel.SetActive(false);
        tebriklerpanel.SetActive(false);
        kaybettinizpanel.SetActive(false);
        for (int i = 0; i < 14; i++)
        {
            bulmacatxt[i].enabled = false;
        }
        harfleriaktar();
    }

    void Update()
    {

    }

    public void harfleriaktar()
    {
        System.Random rastgele = new System.Random();
        int rastsayi = rastgele.Next(0, 7);
        for (int i = 0; i < harfler.Length; i++)
        {
            b[i] = PlayerPrefs.GetString("harfler");
            harfler= b[i].Split(ayrac.ToCharArray());
        }

        for (int j = 0; j < 5; j++)
        {
            butontxt[j].text = harfler[rastsayi];
            rastsayi = rastgele.Next(0, 7);
        }

    }

    public void sureekle()
    {
        tm1.sureArttir();
        sürebutonutxt.text = "Süre: " + tm1.getSureToString();
        sesler.sureeklesescal();
        sureeklebuton.enabled = false;
    }

    public void ipucubutontik()
    {
        ipucutik++;
        if (ipucutik % 2 == 1)
        {
            ipucupanel.SetActive(true);
        }
        if (ipucutik % 2 == 0)
        {
            ipucupanel.SetActive(false);
        }
    }

    public void harfleridegistir()
    {
        harfleriaktar();
    }

    public void kelimeoku()
    {
        for (int i = 0; i < kelimeler.Length; i++)
        {
            m[i]=PlayerPrefs.GetString("kelimeler");
            kelimeler= m[i].Split(ayrac.ToCharArray());
            if (kelimeler[i]==kelimetxt.text) {
                char[] kelimeayir = kelimeler[i].ToCharArray();
                bulmacaDoldur(kelimeayir);
                if (bulmaca.getbulmacaDoldumu() == 6.ToString())
                {
                    sesler.kazandınızsescal();
                    tebriklerpanel.SetActive(!tebriklerpanel.activeSelf);
                    Time.timeScale = (tebriklerpanel.activeSelf) ? 0 : 1;
                    puanObject.kullaniciyaPuanTanimla();
                }
                kelimetxt.text = "";
                break;
            }
            if (kelimeler[i] != kelimetxt.text && i == 5)
            {
                puanObject.puanAzalt();
                sesler.yanlissescal();
                tm1.yanlissureAzalt();
                puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
                kelimetxt.text = "";
                break;
            }
            if (kelimeler[i] != kelimetxt.text && i != 5)
            {
                continue;
            }
        }
    }

    public void digerseviyeyegec()
    {
        Application.LoadLevel("Seviye2");
    }
    public void tekraroyna()
    {
        Application.LoadLevel("Seviye1");
    }
    public void anamenu()
    {
        Application.LoadLevel("AnaMenu");
    }

    public void bulmacaDoldur(char[] harf)
    {
        if (harf[0].ToString() == bulmacatxt[0].text && harf[1].ToString() == bulmacatxt[1].text && harf[2].ToString() == bulmacatxt[2].text)
        {
            bulmacatxt[0].enabled = true;
            bulmacatxt[1].enabled = true;
            bulmacatxt[2].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[1].text && harf[1].ToString() == bulmacatxt[3].text && harf[2].ToString() == bulmacatxt[5].text)
        {
            bulmacatxt[1].enabled = true;
            bulmacatxt[3].enabled = true;
            bulmacatxt[5].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[4].text && harf[1].ToString() == bulmacatxt[5].text && harf[2].ToString() == bulmacatxt[6].text)
        {
            bulmacatxt[4].enabled = true;
            bulmacatxt[5].enabled = true;
            bulmacatxt[6].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[7].text && harf[1].ToString() == bulmacatxt[8].text && harf[2].ToString() == bulmacatxt[9].text)
        {
            bulmacatxt[7].enabled = true;
            bulmacatxt[8].enabled = true;
            bulmacatxt[9].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[9].text && harf[1].ToString() == bulmacatxt[10].text && harf[2].ToString() == bulmacatxt[13].text)
        {
            bulmacatxt[9].enabled = true;
            bulmacatxt[10].enabled = true;
            bulmacatxt[13].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[11].text && harf[1].ToString() == bulmacatxt[12].text && harf[2].ToString() == bulmacatxt[13].text)
        {
            bulmacatxt[11].enabled = true;
            bulmacatxt[12].enabled = true;
            bulmacatxt[13].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }
        else
        {
            puanObject.puanAzalt();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.yanlissescal();
        }
    }
    public void tikla1()
    {
        kelimetxt.text += butontxt[0].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length==3)
            {
                kelimeoku();
                harfleriaktar();
            }
    }

    public void tikla2()
    {
        kelimetxt.text += butontxt[1].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 3)
            {
                kelimeoku();
                harfleriaktar();
            }
    }

    public void tikla3()
    {
        kelimetxt.text += butontxt[2].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 3)
            {
                kelimeoku();
                harfleriaktar();
            }
    }

    public void tikla4()
    {
        kelimetxt.text += butontxt[3].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 3)
            {
                kelimeoku();
                harfleriaktar();
            }
    }

    public void tikla5()
    {
        kelimetxt.text += butontxt[4].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 3)
            {
                kelimeoku();
                harfleriaktar();
            }
    }
}
