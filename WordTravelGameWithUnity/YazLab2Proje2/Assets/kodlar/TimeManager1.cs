using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager1 : MonoBehaviour
{
    public Text surebtntxt;
    public float sure;
    public SesKontrol sesler;
    public Seviye1Script sv1;
    void Start()
    {
        sure = 60;
    }
    void Update()
    {
        sureAzalt();
        surebtntxt.text = "Süre: "+getSureToString();
        
    }

    public void sureArttir()
    {
        sure += 5;
    }

    public void yanlissureAzalt()
    {
        sure -= 5;
    }

    public void sureAzalt()
    {
        sure -= Time.deltaTime;
        if (sure <= 0)
        {
            sure = 0;
            sesler.kaybettinizsescal();
            sv1.kaybettinizpanel.SetActive(true);
        }
    }

    public string getSureToString()
    {
        return sure.ToString("f0");
    }
}
