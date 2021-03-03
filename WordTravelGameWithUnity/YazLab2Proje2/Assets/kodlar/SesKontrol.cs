using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip anamenuses, oyunicises, kazandınızses, kaybettinizses, dogruses, yanlisses, butonlarses, sureekleses;
    AudioSource ses;
    void Start()
    {
        ses = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void anamenusescal()
    {
        ses.PlayOneShot(anamenuses);
    }

    public void oyunicisescal()
    {
        //ses.PlayOneShot(oyunicises);
        //ses.playOnAwake = true;
    }

    public void kazandınızsescal()
    {
        ses.PlayOneShot(kazandınızses);
    }

    public void kaybettinizsescal()
    {
        ses.PlayOneShot(kaybettinizses);
    }

    public void dogrusescal()
    {
        ses.PlayOneShot(dogruses);
    }

    public void yanlissescal()
    {
        ses.PlayOneShot(yanlisses);
    }

    public void butonlarsescal()
    {
        ses.PlayOneShot(butonlarses);
    }

    public void sureeklesescal()
    {
        ses.PlayOneShot(sureekleses);
    }
}
