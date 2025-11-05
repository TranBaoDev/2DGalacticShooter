using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullet Code
public class BulletCode : MonoBehaviour // "MermiKod" means Bullet Code
{
    // Movement speed multiplier
    [SerializeField] float _movementMultiplier = 10.0f; // "HareketCarpani" means Movement Multiplier

    // The original code had these commented out, implying effects are handled by the Generator classes
    // [SerializeField] GameObject _explosionPrefab; // "PatlamaSablon"
    // [SerializeField] GameObject _hitPrefab;       // "VurmaSablon"

    // Transform marking the tip of the bullet for placing hit effects
    [SerializeField] GameObject _bulletTip; // "mermiUcu" means bullet tip

    Rigidbody2D _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        // Set the bullet's velocity to move horizontally (to the right)
        _rigidBody.velocity = new Vector2(_movementMultiplier, 0.0f);
    }

    // Called when the bullet's collider triggers another collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Collision with a generic Enemy (SpaceShip)
        if (collision.CompareTag("Enemy")) // "Dusman" means Enemy
        {
            var position = collision.transform.position;

            // Destroy the collided enemy object
            Destroy(collision.gameObject);

            // Generate an explosion effect at the enemy's position
            ExplosionGeneratorCode.GenerateExplosion(collision.transform.position); // PatlamaUreticiKod.PatlamaUret

            // Play the explosion sound
            SoundProducerCode.ProduceSound(SoundProducerCode.SoundTypes.Explosion); // SesUreticiKod.SesTurleri.Patlama

            // Destroy the bullet itself
            Destroy(gameObject);
        }

        // 2. Collision with a Meteor
        if (collision.CompareTag("Meteor")) // "Meteor" means Meteor
        {
            // Destroy the bullet immediately
            Destroy(gameObject);

            // Generate a hit effect at the bullet's tip position
            // Comment: hit effect when colliding with the meteor
            ExplosionGeneratorCode.GenerateHitEffect(_bulletTip.transform.position); // PatlamaUreticiKod.VurmaUret

            // Play the hit sound
            SoundProducerCode.ProduceSound(SoundProducerCode.SoundTypes.Hit); // SesUreticiKod.SesTurleri.Vurma
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}