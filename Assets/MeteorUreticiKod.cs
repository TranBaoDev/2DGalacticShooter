using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorUreticiKod : DusmanUretici
{
  
    [SerializeField] GameObject _meteorSablon;
    [SerializeField] Transform _altSinir;
    [SerializeField] Transform _ustSinir;
    [SerializeField] Transform _player;

    public override void Uret(){
        float x = _altSinir.position.x;
        float y = Random.Range(_altSinir.position.y, _ustSinir.position.y);


       
        var meteor = Instantiate(_meteorSablon);
        meteor.transform.position=new Vector3(x,y,0);
         //playera dogru gidecegi cn bir hiz vektoru de uretmemiz gerek.
         //meteorun uretildgi noktadan playera giden nktayı cikarirsak o tarafa dogru giden bi hiz vektoru elde ederiz
        Vector3 hiz= _player.position - meteor.transform.position;
        //elde ettigimiz hiz vektorunu velocitye ekledik
        meteor.GetComponent<Rigidbody2D>().velocity = hiz.normalized*10.0f; //Velocity defines the direction of the movement of the body or the object
     //normalized hizi 1 birim uzatir yani yavaslatir
    } 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
