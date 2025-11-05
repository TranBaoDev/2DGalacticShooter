using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanYoneticiKod : MonoBehaviour
{
   [SerializeField] List<DusmanUretici> _ureticiler;

   float _dusmanUretmeAraligi = 1.0f;
   float _dusmanUretmeSayaci = 0.0f;

    void Start()
    {
        //dusmanuretici listesi getirir
        var liste = FindObjectsByType<DusmanUretici>(FindObjectsSortMode.None);

       foreach(var siradaki in liste){
        _ureticiler.Add(siradaki);
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(_dusmanUretmeSayaci>= _dusmanUretmeAraligi){
            int indeks= Random.Range(0, _ureticiler.Count); //0 ile üretici sayisi arasinda random bir deger uretecek
            _ureticiler[indeks].Uret(); //rastgele dusman uretilmesini sagladik bu sekilde
            _dusmanUretmeSayaci=0.0f;

        }
        else{
            _dusmanUretmeSayaci+= Time.deltaTime; //updateler per frame cagrildigi icin time.deltatime kullaniyoruz
        }
    }
}
