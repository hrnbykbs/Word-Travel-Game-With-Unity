using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Kullanici : MonoBehaviour
{
    public GameObject girisyapbuton, kayitolbuton, girisbuton, kayitbuton, girispanel, kayitpanel, oyunabaslabuton, seviyelerbuton, skorlarbuton, geridonbuton, cikisbuton;
    public GameObject seviye1buton, seviye2buton, seviye3buton, musicbutton, loadingsc1, loadingsc2, loadingsc3, arkaplanpanel, anamenupanel, giriskayitpanel,skorlarpanel;
    public InputField girisad, girissifre, kayitad, kayitsifre;
    public Text kullaniciaditxt, hosgeldintxt, sestxt, hatabasarilitxt,skorlartxt;
    public GameObject[] nchu = new GameObject[4];
    public AudioSource sesler;
    public AudioClip anamenuses;
    public puanHesapla ph;
    int muziktik = 0;
    string[] k = new string[100];
    string[] s = new string[100];
    string ayrac = "-";

    string ks= "harun-ömer-sefa-altan-burak-cihan";
    string ss= "5353-2929-6161-6060-6969-5555";
    string[] kullanici = new string[100];
    string[] sifre = new string[100];
    Text skrtxt;

    String usersPrefix = "kullanici";
    String passwordPrefix = "sifre";

    void Start()
    {
        string loginUser=PlayerPrefs.GetString("loginUser");
        int puan = PlayerPrefs.GetInt(loginUser);
       
        String users = PlayerPrefs.GetString(usersPrefix);
       
        if (users.Length<=0)
        {
            PlayerPrefs.SetString(usersPrefix, ks);
            PlayerPrefs.SetString(passwordPrefix, ss);
        }
        sestxt.text = "Ses Açık";
        skorlarpanel.SetActive(false);
        girispanel.SetActive(false);
        kayitpanel.SetActive(false);
        anamenupanel.SetActive(false);
        hosgeldintxt.enabled = false;
        seviye1buton.SetActive(false);
        seviye2buton.SetActive(false);
        seviye3buton.SetActive(false);
        giriskayitpanel.SetActive(true);
        loadingsc1.SetActive(false);
        loadingsc2.SetActive(false);
        loadingsc3.SetActive(false);
    }

    void Update()
    {
    }

    public void skorlarbutontik()
    {
        anamenupanel.SetActive(false);
        skorlarpanel.SetActive(true);
        string kullaniciPuanlar=  ph.kullaniciPuanGetir();
        string[] puanlar= kullaniciPuanlar.Split('-');

        for (int i = 1; i < puanlar.Length; i++)
        {
            skorlartxt.text += PlayerPrefs.GetString("loginUser") + "               " + puanlar[i] + "       ";
        }

       /* foreach (string puan in puanlar)
        {
            //skorlartxt.text += PlayerPrefs.GetString("loginUser")+" "+puan;
            //Debug.Log("Puan: "+puan[0]);
        }*/

        //skorlartxt.text += PlayerPrefs.GetString("loginUser")+" "+max;
        //skorlartxt.text =ph.kullaniciPuanGetir();
    }

    public void girisyapbutontik()
    {
        girisyapbuton.SetActive(false);
        kayitolbuton.SetActive(false);
        girispanel.SetActive(true);
        girisad.text = "";
        girissifre.text = "";
    }

    public void kayitolbutontik()
    {
        girisyapbuton.SetActive(false);
        kayitolbuton.SetActive(false);
        kayitpanel.SetActive(true);
    }

    public void oyunabaslabutontik()
    {

        loadingsc1.SetActive(true);
        anamenupanel.SetActive(false);
    }

    public void girisbutontik()
    {
        if (girisad.text == "" || girissifre.text == "")
        {
            hatabasarilitxt.text = "Lütfen boş alanları doldurunuz!";
        }
        else
        {
            for (int i = 0; i < kullanici.Length; i++)
            {
                k[i] = PlayerPrefs.GetString(usersPrefix);
                s[i] = PlayerPrefs.GetString(passwordPrefix);
                kullanici = k[i].Split(ayrac.ToCharArray());
                sifre = s[i].Split(ayrac.ToCharArray());
                if (girisad.text == kullanici[i] && girissifre.text == sifre[i])
                {
                    hatabasarilitxt.text = "Giriş başarılı!";
                    girispanel.SetActive(false);
                    anamenupanel.SetActive(true);
                    for (int t = 0; t < nchu.Length; t++)
                    {
                        nchu[t].SetActive(false);
                    }
                    hosgeldintxt.enabled = true;
                    kullaniciaditxt.enabled = true;
                    kullaniciaditxt.text = kullanici[i] + "!";
                    PlayerPrefs.SetString("loginUser", kullanici[i]);
                    break;
                }
            }
        }

    }

    public void kayitbutontik() {

        String tempUsers = PlayerPrefs.GetString(usersPrefix);
        String tempPass = PlayerPrefs.GetString(passwordPrefix);
        tempUsers = tempUsers + "-" + kayitad.text;
        tempPass = tempPass + "-" + kayitsifre.text;
        PlayerPrefs.SetString(usersPrefix, tempUsers);
        PlayerPrefs.SetString(passwordPrefix, tempPass);
        Debug.Log(ks+" "+ss);
        Debug.Log("Kayıt Edildi");
        kayitpanel.SetActive(false);
        anamenupanel.SetActive(true);
        for (int t = 0; t < nchu.Length; t++)
        {
            nchu[t].SetActive(false);
        }
        hosgeldintxt.enabled = true;
        kullaniciaditxt.enabled = true;
        kullaniciaditxt.text = kayitad.text + "!";
    }

    public void geridonbutontik()
    {
        girisyapbuton.SetActive(true);
        kayitolbuton.SetActive(true);
        anamenupanel.SetActive(false);
        hosgeldintxt.enabled = false;
        kullaniciaditxt.enabled = false;
    }
    public void seviyelerbutontik()
    {
        seviye1buton.SetActive(true);
        seviye2buton.SetActive(true);
        seviye3buton.SetActive(true);
        anamenupanel.SetActive(false);
    }

    public void seviye1butontik()
    {
        loadingsc1.SetActive(true);
    }

    public void seviye2butontik()
    {
        loadingsc2.SetActive(true);
    }

    public void seviye3butontik()
    {
        loadingsc3.SetActive(true);
    }

    public void musicbutontik()
    {
        muziktik++;
        if (muziktik % 2 == 1)
        {
            sesler.Pause();
            sestxt.text = "Ses Kapalı";
        }
        if (muziktik % 2 == 0)
        {
            sesler.Play();
            sestxt.text = "Ses Açık";
        }

    }

 /*   public void dosyadankullaniciOku(string girisad, string girissifre)
    {
        //TextAsset kullanicilar = (TextAsset)Resources.Load("kullanicilar");
        //var kullanicilar = (Resources.Load<TextAsset>("Text/kullanicilar"));
        string kullanicilar = (Application.persistentDataPath + "\\Resources\\Text\\kullanicilar.txt");
        //string kullanicilar=(Instantiate(Resources.Load("/Resources/Text/kullanicilar"))).ToString();
        //TextAsset kullanicilar = Resources.Load<TextAsset>("kullanicilar.txt");
        //string kullanicilar = (Application.persistentDataPath + "\\" + "myFile.txt");
        //Text kullanicilar = Resources.Load<Text>("kullanicilar");
        //TextAsset kullanicilar = Resources.Load<TextAsset>("kullanicilar");
        //string json = kullanicilar.text;

        //string kullanicilar = @"C:\Users\HARUN\UnityProjects\YazLab2Proje2\Assets\Resources\Text\kullanicilar.txt";
        FileStream fs = new FileStream(kullanicilar, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        string[] satir = new string[100];
        string ayrac = " ";
        string[] kullaniciad = new string[100];
        string[] kullanicisifre = new string[100];

        #if UNITY_ANDROID
                string path = "jar:file://" + Application.dataPath + "!/assets/kullanicilar.txt";
                WWW wwwfile = new WWW(path);
                while (!wwwfile.isDone) { }
                var filepath = string.Format("{0}/{1}", Application.persistentDataPath, "kullanicilar.txt");
                File.WriteAllBytes(filepath, wwwfile.bytes);

                StreamReader wr = new StreamReader(filepath);
                string line;
                while ((line = wr.ReadLine()) != null)
                {
                    kullaniciaditxt.text=line;
                }
        #endif

        for (int i = 0; i < satir.Length; i++)
        {
            satir[i] = sr.ReadLine();
            kullaniciad = satir[i].Split(ayrac.ToCharArray());
            Debug.Log(kullaniciad[0]);
            kullanicisifre[0] = kullaniciad[1];
            Debug.Log(kullanicisifre[0]);

            if (girisad == kullaniciad[0] && girissifre == kullanicisifre[0])
            {
                Debug.Log("Giriş Yapıldı");
                girispanel.SetActive(false);
                anamenupanel.SetActive(true);
                for (int t = 0; t < nchu.Length; t++)
                {
                    nchu[t].SetActive(false);
                }
                hosgeldintxt.enabled = true;
                kullaniciaditxt.enabled = true;
                kullaniciaditxt.text = girisad + "!";
                break;
            }
            if (girisad != kullaniciad[0] && girissifre != kullanicisifre[0] && sr.EndOfStream == false)
            {
                continue;
            }
            if (girisad != kullaniciad[0] && girissifre != kullanicisifre[0] && sr.EndOfStream == true)
            {
                girisad = "";
                girissifre = "";
                Debug.Log("Hatalı Giriş.Tekrar Deneyiniz");
            }
        }
        sr.Close();
        fs.Close();
    }*/
    public void cikisbutontik()
    {
        Application.Quit();
    }

  /*  public void kayitbutontik()
    {
        string yenikayitlar = @"C:\Users\HARUN\UnityProjects\YazLab2Proje2\Assets\Resources\Text\kullanicilar.txt";
        FileStream fs = new FileStream(yenikayitlar, FileMode.Append, FileAccess.Write);
        StreamWriter sr = new StreamWriter(fs);
        sr.WriteLine(kayitad.text + " " + kayitsifre.text);
        Debug.Log("Kayıt Edildi");
        kayitpanel.SetActive(false);
        anamenupanel.SetActive(true);
        for (int t = 0; t < nchu.Length; t++)
        {
            nchu[t].SetActive(false);
        }
        hosgeldintxt.enabled = true;
        kullaniciaditxt.enabled = true;
        kullaniciaditxt.text = kayitad.text + "!";
        sr.Close();
        fs.Close();
    }*/
}
