using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorKod : MonoBehaviour
{

    //serialized field, unitynin private variablei tanimasi icin, unity icerisinde erisilebilir olmasi icin var.
    [SerializeField] HayatCizgisiKod _hayatCizgisi; //nesneye ihityacimiz yok kod ile konusuyoruz zaten diye
    [SerializeField] Transform _sprite;
    [SerializeField] GameObject _kucukMeteorSablon;
    void Start()
    {
        
    }


    //PREFABLER BASLANGICTA STARTI CAGIRMAZLAR. AWAKE I CAGIRIRLAR.
    private void Awake(){
        _hayatCizgisi.ToplamYasam=5;
    }


    //rigidbody ebeveynde bile olsa, carpistigimiz collider kimse o nesnenin referansini alir
    private void OnTriggerEnter2D(Collider2D collision){
       if(collision.CompareTag("Mermi")){
        _hayatCizgisi.YasamAzalt();
        if(_hayatCizgisi.KalanYasam==0){
            Destroy(gameObject);
            PatlamaUreticiKod.PatlamaUret(transform.position);
            KucukMeteorUret();
        }
       }
    }

    public void KucukMeteorUret(){
        var kYukari= Instantiate(_kucukMeteorSablon);
        var kAsagi= Instantiate(_kucukMeteorSablon);
        kYukari.transform.position=transform.position;
        kAsagi.transform.position=transform.position;
        Vector2 hiz= new Vector2(-10.0f,5.0f);
        kYukari.GetComponent<Rigidbody2D>().velocity=hiz;
        hiz.y = -hiz.y;
        kAsagi.GetComponent<Rigidbody2D>().velocity=hiz;
    }


    // Update is called once per frame
    void Update()
    {
        _sprite.Rotate(0.0f,0.0f,0.4f);
    }
}
