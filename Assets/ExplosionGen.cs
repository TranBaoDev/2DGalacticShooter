using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics; // Commented out in the original code
using UnityEngine;

// Explosion Generator Code
public class ExplosionGeneratorCode : MonoBehaviour // "PatlamaUreticiKod" means Explosion Generator Code
{
    // Prefabs for explosion and hit effects, set in the Inspector
    [SerializeField] GameObject _explosionPrefab; // "patlamaSablon" means explosion template/prefab
    [SerializeField] GameObject _hitPrefab;       // "vurmaSablon" means hit template/prefab

    // This static reference allows us to access the class's non-static elements from within a static function. 
    // However, the objects of ExplosionGeneratorCode are not yet assigned to this reference. 
    // We can do this assignment in the Start function.
    static ExplosionGeneratorCode instance; // "referans" means reference/instance

    void Start()
    {
        // Assign 'this' object instance to the static reference when the scene starts.
        instance = this; // "referans=this"
    }

    // If a class's function is static, static functions cannot access the non-static members of the class they are defined in.
    // Static functions can only access static elements (unless they use an instance reference).
    public static void GenerateExplosion(Vector3 position) // "PatlamaUret" means Produce/Generate Explosion
    {
        // Instantiate is used for creating new objects at runtime (such as explosion)
        // We use 'instance' to access the non-static _explosionPrefab field.
        var explosion = Instantiate(instance._explosionPrefab); // "patlama" means explosion
        explosion.transform.position = position;
    }

    public static void GenerateHitEffect(Vector3 position) // "VurmaUret" means Produce/Generate Hit
    {
        // We use 'instance' to access the non-static _hitPrefab field.
        var hitEffect = Instantiate(instance._hitPrefab); // "vurma" means hit effect
        hitEffect.transform.position = position;
    }


    // Update is called once per frame
    void Update()
    {

    }
    /*
        // Internal static void PatlamaUret(UnityEngine.Vector3 position)
        // {
        //     throw new NotImplementedException();
        // }
    */
}