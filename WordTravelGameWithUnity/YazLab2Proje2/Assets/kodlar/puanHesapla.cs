using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puanHesapla : MonoBehaviour
{
    private int puan = 0;
    private int kelimesayisi = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void puanArttir()
    {
        puan += 100;
    }

    public void puanAzalt()
    {
        puan -= 100;
    }

    public void kullaniciyaPuanTanimla()
    {
        string loginUser = PlayerPrefs.GetString("loginUser");
        string puanlar = PlayerPrefs.GetString(loginUser);
        puanlar = puanlar + "-" + puan;
        PlayerPrefs.SetString(loginUser, puanlar);
    }

    public string kullaniciPuanGetir()
    {
        string loginUser = PlayerPrefs.GetString("loginUser");
        return PlayerPrefs.GetString(loginUser);
    }

    public string getPuanToString()
    {
        return puan.ToString();
    }

    public int getPuanToInt()
    {
        return puan;
    }

    public void kelimesayisiArtir()
    {
        kelimesayisi++;
    }

    public string getbulmacaDoldumu()
    {
        return kelimesayisi.ToString();
    }

    
}
