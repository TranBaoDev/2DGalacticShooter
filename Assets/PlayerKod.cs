using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKod : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigidBody;
    [SerializeField] float _hareketCarpani= 10.0f;
    [SerializeField] GameObject _atesSablon;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HareketEt();
       if(Input.GetKeyDown(KeyCode.Space)){
        var ates = Instantiate(_atesSablon);
        ates.transform.position=transform.position;

         //ates ettigi zaman ses calsin istiyoruz
          SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Ates);
       }

      
    }

    void HareketEt(){
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        bool asagiBasildiMi=false;
        bool yukariBasildiMi = false;
        if(y<0){
            asagiBasildiMi=true;
        }
        else if(y>0){
            yukariBasildiMi=true;
        }
        _animator.SetBool("AsagiBasildi",asagiBasildiMi);
        _animator.SetBool("YukariBasildi",yukariBasildiMi);

        _rigidBody.velocity = new Vector2(x*_hareketCarpani,y*_hareketCarpani);
    }
}
