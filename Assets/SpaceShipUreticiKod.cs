using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spaceshipuretici, dusmanureticiden kalitim alir. oradakilere erisir. dsmanuretici zaten monobehaviourdan kalitim aliyordu.
public class SpaceShipUreticiKod : DusmanUretici
{

    [SerializeField] GameObject _dusmanSablon;
    [SerializeField] Transform _altSinir;
    [SerializeField] Transform _ustSinir;

    public override void Uret(){
        float x = _altSinir.position.x;
        float y = Random.Range(_altSinir.position.y, _ustSinir.position.y);

        var yeniDusman = Instantiate(_dusmanSablon);
        yeniDusman.transform.position=new Vector3(x,y,0);


        //print("spaceshipuretici");
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
