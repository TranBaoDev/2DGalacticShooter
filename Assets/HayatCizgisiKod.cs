using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayatCizgisiKod : MonoBehaviour
{

    int _toplamYasam;
    int _kalanYasam;
    float _olcek;
    [SerializeField] GameObject _yesilBar;
    
    public int ToplamYasam{

        //baslangicta toplam yasam ile kalan yasamin degeri ayni
        get{ return _toplamYasam;}
        set{ _toplamYasam = value;
         _kalanYasam =value;
        }

    }
    public int KalanYasam{
        get{return _kalanYasam;}
       
    }


    void Start()
    {
       // ToplamYasam=8;
    }

    public void YasamAzalt(int azaltmaMiktari=1){
        _kalanYasam-= azaltmaMiktari;
        if(_kalanYasam<0)
            _kalanYasam=0;
        //barda kalan can
        _olcek= (float)_kalanYasam/ (float)_toplamYasam;
        var olcekVektoru= _yesilBar.transform.localScale;
        olcekVektoru.x=_olcek;
        _yesilBar.transform.localScale=olcekVektoru;

    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.Space)){
            YasamAzalt();
        }*/
    }
}
