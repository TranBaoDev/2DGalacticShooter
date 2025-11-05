using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteor : MonoBehaviour
{
    void Start()
    {
        // Initialization if needed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When hit by a bullet
        if (collision.CompareTag("Bullet"))
        {
            // Create an explosion effect at the meteor's position
            ExplosionGeneratorCode.GenerateExplosion(transform.position);

            // Destroy this meteor
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Rotate the meteor (currently zero rotation — can adjust for animation)
        transform.Rotate(0f, 0f, 0.0f);
    }
}
