using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukMeteorKod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Mermi")){
            PatlamaUreticiKod.PatlamaUret(transform.position);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0,0,0.0f);
    }
}
