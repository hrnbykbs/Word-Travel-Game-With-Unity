using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenCode1 : MonoBehaviour {

    public float sayi;
    public Text sayiyazi;
    public Text yukleniyor;
    public GameObject bar;
    void Start() {

    }
	void Update () {

        if (sayi < 100) {
        sayi+=Time.deltaTime*10;

        }

        if (sayi >= 100)
        {
            StartCoroutine(Wait());
            sayi = 100;

        }
        
        sayiyazi.text = "" + (int)sayi + "%";
        bar.transform.localScale=new Vector3(sayi/100,1,1);
	}

    IEnumerator Wait() {

        yukleniyor.text = "Tamamlandı!";
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("Seviye1");
    }
}
