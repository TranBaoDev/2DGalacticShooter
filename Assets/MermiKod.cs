using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKod : MonoBehaviour
{
    [SerializeField] float _hareketCarpani =10.0f;
   // [SerializeField] GameObject _PatlamaSablon;
   // [SerializeField] GameObject _VurmaSablon;
    [SerializeField] GameObject _mermiUcu;
    Rigidbody2D _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody=GetComponent<Rigidbody2D>();
        _rigidBody.velocity=new Vector2(_hareketCarpani,0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Dusman")){
            var position=collision.transform.position;
            Destroy(collision.gameObject);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            //var patlama= Instantiate(_PatlamaSablon);
           // patlama.transform.position = position;
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Patlama);
            Destroy(gameObject);
        }
          if(collision.CompareTag("Meteor")){
             Destroy(gameObject);

             //meteora carpinca vurma efekti
              PatlamaUreticiKod.VurmaUret(_mermiUcu.transform.position);
           // var vurulma= Instantiate(_VurmaSablon);
           // vurulma.transform.position = _mermiUcu.transform.position;
             SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
