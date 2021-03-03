using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Seviye3Script : MonoBehaviour
{
    public Text[] butontxt = new Text[7];
    public GameObject tebriklerpanel,kaybettinizpanel,ipucupanel;
    public Button[] butons = new Button[7];
    List<Button> tiklananbutonlar = new List<Button>();
    public puanHesapla puanObject, sureObject;
    public Button sürebutonu, puanbutonu,tkrroyna,anamnu, ipucubuton, sureeklebuton;
    public Text sürebutonutxt, puanbutonutxt, kelimetxt;
    public Text[] bulmacatxt = new Text[22];
    public int kelimesayisi = 0;
    public TimeManager3 tm3;
    public puanHesapla bulmaca;
    public SesKontrol sesler;

    string k = "ABİDE-ADALE-BİDON-İNANÇ-UCUBE";
    string h = "A-B-C-Ç-D-E-İ-L-N-O-U";
    string[] harfler = new string[11];
    string[] kelimeler = new string[5];
    string[] b = new string[11];
    string[] m = new string[11];
    string ayrac = "-";
    int ipucutik = 0;

    void Start()
    {
        PlayerPrefs.SetString("harfler", h);
        PlayerPrefs.SetString("kelimeler", k);
        sesler.oyunicisescal();
        kaybettinizpanel.SetActive(false);
        ipucupanel.SetActive(false);
        puanbutonutxt.text = "Puan: 0";
        tebriklerpanel.SetActive(false);
        for (int i = 0; i < 22; i++)
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
        int rastsayi = rastgele.Next(0, 11);
        for (int i = 0; i < harfler.Length; i++)
        {
            b[i] = PlayerPrefs.GetString("harfler");
            harfler = b[i].Split(ayrac.ToCharArray());
        }

        for (int j = 0; j < 7; j++)
        {
            butontxt[j].text = harfler[rastsayi];
            rastsayi = rastgele.Next(0, 11);
        }

    }

    public void sureekle()
    {
        tm3.sureArttir();
        sürebutonutxt.text = "Süre: " + tm3.getSureToString();
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

    public void tekraroyna()
    {
        Application.LoadLevel("Seviye3");
    }
    public void anamenu()
    {
        Application.LoadLevel("AnaMenu");
    }

    public void kelimeoku()
    {
        for (int i = 0; i < kelimeler.Length; i++)
        {
            m[i] = PlayerPrefs.GetString("kelimeler");
            kelimeler = m[i].Split(ayrac.ToCharArray());
            if (kelimeler[i] == kelimetxt.text)
            {
                char[] kelimeayir = kelimeler[i].ToCharArray();
                bulmacaDoldur(kelimeayir);
                if (bulmaca.getbulmacaDoldumu() == 6.ToString())
                {
                    sesler.kazandınızsescal();
                    tebriklerpanel.SetActive(!tebriklerpanel.activeSelf);
                    Time.timeScale = (tebriklerpanel.activeSelf) ? 0 : 1;
                }
                kelimetxt.text = "";
                break;
            }
            if (kelimeler[i] != kelimetxt.text && i == 4)
            {
                puanObject.puanAzalt();
                sesler.yanlissescal();
                tm3.yanlissureAzalt();
                puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
                kelimetxt.text = "";
                break;
            }
            if (kelimeler[i] != kelimetxt.text && i != 4)
            {
                continue;
            }
        }
    }

    /*  public void harfokuyaz()
      {
          string harflerdosyasi = (Application.dataPath + "/Resources/Text/seviye3harfler.txt");
          //string harflerdosyasi = @"C:\Users\HARUN\UnityProjects\YazLab2Proje2\Assets\Resources\Text\seviye3harfler.txt";
          FileStream fs = new FileStream(harflerdosyasi, FileMode.Open, FileAccess.Read);
          StreamReader sr = new StreamReader(fs);
          string[] harfler = new string[11];
          System.Random rastgele = new System.Random();
          int rastsayi = rastgele.Next(0, 11);
          int i = 0;
          while (sr.EndOfStream != true)
          {
              harfler[i] = sr.ReadLine();
              i += 1;
          }
          for (int j = 0; j < 7; j++)
          {
              butontxt[j].text = harfler[rastsayi];
              rastsayi = rastgele.Next(0, 11);
          }
          sr.Close();
          fs.Close();
      }*/
    /*   public void dosyadankelimeOku()
       {
           string kelimelerdosyasi = (Application.dataPath + "/Resources/Text/kelimeler.txt");
           //string kelimelerdosyasi = @"C:\Users\HARUN\UnityProjects\YazLab2Proje2\Assets\Resources\Text\kelimeler.txt";
           FileStream fs = new FileStream(kelimelerdosyasi, FileMode.Open, FileAccess.Read);
           StreamReader sr = new StreamReader(fs);
           string[] yazi = new string[7100];

           for (int i = 0; i < yazi.Length; i++)
           {
               yazi[i] = sr.ReadLine();

               if (yazi[i] == kelimetxt.text)
               {
                   char[] harf = yazi[i].ToCharArray();
                   bulmacaDoldur(harf);
                   if (bulmaca.getbulmacaDoldumu() == 6.ToString())
                   {
                       tebriklerpanel.SetActive(true);
                       sesler.kazandınızsescal();
                       tm.sureDurdur();
                   }
                   kelimetxt.text = "";
                   break;
               }
               if (yazi[i] != kelimetxt.text && sr.EndOfStream == true)
               {
                   puanObject.puanAzalt();
                   sesler.yanlissescal();
                   tm.yanlissureAzalt();
                   puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
                   kelimetxt.text = "";
                   break;
               }

               if (yazi[i] != kelimetxt.text && sr.EndOfStream != true)
               {
                   continue;
               }
           }
           sr.Close();
           fs.Close();
       }*/
    public void bulmacaDoldur(char[] harf)
    {
        if (harf[0].ToString() == bulmacatxt[0].text && harf[1].ToString() == bulmacatxt[1].text && harf[2].ToString() == bulmacatxt[2].text && harf[3].ToString() == bulmacatxt[3].text && harf[4].ToString() == bulmacatxt[4].text)
        {
            bulmacatxt[0].enabled = true;
            bulmacatxt[1].enabled = true;
            bulmacatxt[2].enabled = true;
            bulmacatxt[3].enabled = true;
            bulmacatxt[4].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[1].text && harf[1].ToString() == bulmacatxt[5].text && harf[2].ToString() == bulmacatxt[6].text && harf[3].ToString() == bulmacatxt[7].text && harf[4].ToString() == bulmacatxt[8].text)
        {
            bulmacatxt[1].enabled = true;
            bulmacatxt[5].enabled = true;
            bulmacatxt[6].enabled = true;
            bulmacatxt[7].enabled = true;
            bulmacatxt[8].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[9].text && harf[1].ToString() == bulmacatxt[6].text && harf[2].ToString() == bulmacatxt[10].text && harf[3].ToString() == bulmacatxt[11].text && harf[4].ToString() == bulmacatxt[12].text)
        {
            bulmacatxt[9].enabled = true;
            bulmacatxt[6].enabled = true;
            bulmacatxt[10].enabled = true;
            bulmacatxt[11].enabled = true;
            bulmacatxt[12].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[13].text && harf[1].ToString() == bulmacatxt[8].text && harf[2].ToString() == bulmacatxt[14].text && harf[3].ToString() == bulmacatxt[15].text && harf[4].ToString() == bulmacatxt[16].text)
        {
            bulmacatxt[13].enabled = true;
            bulmacatxt[8].enabled = true;
            bulmacatxt[14].enabled = true;
            bulmacatxt[15].enabled = true;
            bulmacatxt[16].enabled = true;
            puanObject.puanArttir();
            puanbutonutxt.text = "Puan: " + puanObject.getPuanToString();
            sesler.dogrusescal();
            bulmaca.kelimesayisiArtir();
        }

        else if (harf[0].ToString() == bulmacatxt[17].text && harf[1].ToString() == bulmacatxt[18].text && harf[2].ToString() == bulmacatxt[19].text && harf[3].ToString() == bulmacatxt[20].text && harf[4].ToString() == bulmacatxt[21].text)
        {
            bulmacatxt[17].enabled = true;
            bulmacatxt[18].enabled = true;
            bulmacatxt[19].enabled = true;
            bulmacatxt[20].enabled = true;
            bulmacatxt[21].enabled = true;
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
        if (kelimetxt.text.Length == 5)
        {
            kelimeoku();
            harfleriaktar();
        }
    }
    public void tikla2()
    {
        kelimetxt.text += butontxt[1].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 5)
        {
            kelimeoku();
            harfleriaktar();
        }
    }
    public void tikla3()
    {
        kelimetxt.text += butontxt[2].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 5)
        {
            kelimeoku();
            harfleriaktar();
        }
    }
    public void tikla4()
    {
        kelimetxt.text += butontxt[3].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 5)
        {
            kelimeoku();
            harfleriaktar();
        }
    }
    public void tikla5()
    {
        kelimetxt.text += butontxt[4].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 5)
        {
            kelimeoku();
            harfleriaktar();
        }
    }

    public void tikla6()
    {
        kelimetxt.text += butontxt[5].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 5)
        {
            kelimeoku();
            harfleriaktar();
        }
    }

    public void tikla7()
    {
        kelimetxt.text += butontxt[6].text;
        sesler.butonlarsescal();
        if (kelimetxt.text.Length == 5)
        {
            kelimeoku();
            harfleriaktar();
        }
    }
}
