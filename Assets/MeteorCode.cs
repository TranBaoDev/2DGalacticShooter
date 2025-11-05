using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Meteor Code
public class MeteorCode : MonoBehaviour
{

    // serialized field, exists for Unity to recognize the private variable, and to be accessible within Unity.
    [SerializeField] HealthBarCode _healthBar; // "HayatCizgisiKod" means HealthBarCode; We don't need the object, we are talking to the code anyway
    [SerializeField] Transform _sprite;
    [SerializeField] GameObject _smallMeteorPrefab; // "kucukMeteorSablon" means small Meteor Template/Prefab

    void Start()
    {

    }


    // PREFABS DO NOT CALL START AT THE BEGINNING. THEY CALL AWAKE.
    private void Awake()
    {
        // Set the total health for this meteor
        _healthBar.TotalHealth = 5; // "ToplamYasam" means Total Health
    }


    // even if the rigidbody is on the parent, it takes the reference of the collider we are colliding with.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        { // "Mermi" means Bullet
          // Decrease health when hit by a bullet
            _healthBar.DecreaseHealth(); // "YasamAzalt" means Decrease Health

            // Check if the meteor is destroyed
            if (_healthBar.RemainingHealth == 0)
            { // "KalanYasam" means Remaining Health
                Destroy(gameObject); // Destroy the current meteor
                                     // Generate the explosion effect
                ExplosionGeneratorCode.GenerateExplosion(transform.position); // "PatlamaUreticiKod.PatlamaUret"
                                                                              // Spawn smaller meteors
                GenerateSmallMeteors(); // "KucukMeteorUret"
            }
        }
    }

    // Function to create two smaller meteors flying in opposite directions
    public void GenerateSmallMeteors()
    {
        var kUp = Instantiate(_smallMeteorPrefab); // "kYukari" means kUp
        var kDown = Instantiate(_smallMeteorPrefab); // "kAsagi" means kDown

        kUp.transform.position = transform.position;
        kDown.transform.position = transform.position;

        // Define initial velocity vector
        Vector2 velocity = new Vector2(-10.0f, 5.0f); // "hiz" means velocity

        // Apply velocity to the upward meteor
        kUp.GetComponent<Rigidbody2D>().velocity = velocity;

        // Invert the Y component for the downward meteor
        velocity.y = -velocity.y;

        // Apply velocity to the downward meteor
        kDown.GetComponent<Rigidbody2D>().velocity = velocity;
    }


    // Update is called once per frame
    void Update()
    {
        // Rotate the sprite for a visual effect
        _sprite.Rotate(0.0f, 0.0f, 0.4f);
    }
}