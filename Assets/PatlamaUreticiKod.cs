using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PatlamaUreticiKod : MonoBehaviour
{
    [SerializeField] GameObject _patlamaSablon;
    [SerializeField] GameObject _vurmaSablon;
    static PatlamaUreticiKod referans; //bu referans sayesinde static fonksiyon icerisinden de sinifin 
    //elemanlarina erisebiliriz. ancak su an patlamaUreticiKod'un nesneleri bu referansa atanmis degil.
    //bu atanayi start fonksiyonunda yapabilriz.
    void Start()
    {
        referans=this;
    }

    //eger bir sinifin fonksiyonu static ise, static fonksiyonlar tanimlandikleri sinifin uyelerine erisemezler
    //static fonksiyonlar sadece static elemanlara erisebilirler
    public static void PatlamaUret(Vector3 konum){
        //instantiate is used for creating new objects at runtime (((such as explosion)))
        var patlama= Instantiate(referans._patlamaSablon);
        patlama.transform.position= konum;
    }
    public static void VurmaUret(Vector3 konum){
        var vurma= Instantiate(referans._vurmaSablon);
        vurma.transform.position = konum;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
/*
    internal static void PatlamaUret(UnityEngine.Vector3 position)
    {
        throw new NotImplementedException();
    }*/
}
