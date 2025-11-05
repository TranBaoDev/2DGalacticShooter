using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesUreticiKod : MonoBehaviour
{
    static SesUreticiKod ins;  //static olmasi sayesinde her yerden erisebiliriz //bu sesureticikod'a bir referans olacak
   [SerializeField] List<AudioClip> _sesKlipleri;  //her bir muzik bir ses klibi olarak geciyor
   //audioclip ses dosyasi
   //audiosource calan arac
   //listener da dinleyici olarak dusunulebilir
   AudioSource _source;
   
    public enum SesTurleri{
        Ates=0,
        Patlama=1,
        Vurma=2
    }

    // Start is called before the first frame update
    void Start()
    {
        ins = this;  //start olgudunda bu deger otomatik olarak atanacak
        _source = GetComponent<AudioSource>();
    }

    public static void SesUret(SesTurleri tur){
        int index = (int)tur;

        //statik fonksiyon old icin direkt erisemiyoruz ve ins kullaniyoruz
        ins._source.clip = ins._sesKlipleri[index];
        ins._source.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
