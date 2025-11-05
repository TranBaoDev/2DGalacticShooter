using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanKod : MonoBehaviour
{
    //arkaplanin hareket etmesini istiyoruz
   [SerializeField] GameObject _resim1;
   [SerializeField] GameObject _resim2;
    GameObject _aktif; //hangi arkaplanin o an icinde aktif oldugu. 1 mi 2 mi
    GameObject _sag; //o an icin aktif olmayan arkaplan
    float mesafeX;
    float minX;
   [SerializeField] float _akisHizi=0.01f;    
    void Start()
    {
        _aktif = _resim1;
        _sag = _resim2;
        mesafeX = _sag.transform.position.x-_aktif.transform.position.x; //iki resim arasindaki mesafe
        minX = _aktif.transform.position.x- mesafeX; //aktif olanin gelecgi min x noktsi. eger bu noktadan biraz bile cikarsa
        //arkaplan basa sarilmali
    }

    // Update is called once per frame
    void Update()
    {
        _aktif.transform.position += new Vector3(-_akisHizi,0.0f,0.0f);
        _sag.transform.position += new Vector3(-_akisHizi,0.0f,0.0f);

        //eger arkaplan biraz bile minx in disina cikarsa, arkaplan basa sarilmali
        if(_aktif.transform.position.x < minX){
            //sagda bulunanin pozisyonuna mesafeX kadar ekleyip yeni pozisyonunu olusturduk
            _aktif.transform.position = _sag.transform.position+new Vector3(mesafeX,0.0f,0.0f); 

            //referanslari kaybetmemek icin gecici bir gameobject olusturyourz
            GameObject gecici = _aktif;
            _aktif =_sag;
            _sag = gecici;
        }
    }
}
