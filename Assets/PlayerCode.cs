using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Code
public class PlayerCode : MonoBehaviour
{
    // Private references to components on the same GameObject
    Animator _animator;
    Rigidbody2D _rigidBody;

    // Serialized fields to be set in the Inspector
    [SerializeField] float _movementMultiplier = 10.0f; // "HareketCarpani" means Movement Multiplier
    [SerializeField] GameObject _firePrefab; // "AtesSablon" means Fire/Bullet Template/Prefab

    // Start is called before the first frame update
    void Start()
    {
        // Get the required components
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement input
        Move(); // "HareketEt" means Move

        // Check for the fire/shoot input (Space bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the bullet/fire object
            var fire = Instantiate(_firePrefab);
            // Set the bullet's starting position to the player's position
            fire.transform.position = transform.position;

            // We want the sound to play when the player shoots.
            // "SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Ates)" means SoundProducerCode.ProduceSound(SoundProducerCode.SoundTypes.Fire)
            SoundProducerCode.ProduceSound(SoundProducerCode.SoundTypes.Fire);
        }
    }

    // Function to handle movement logic
    void Move() // "HareketEt" means Move
    {
        // Get input values from the input axes (typically WASD or Arrow Keys)
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Logic to determine movement direction for animation parameters
        bool isDownPressed = false; // "asagiBasildiMi" means Is Down Pressed?
        bool isUpPressed = false;   // "yukariBasildiMi" means Is Up Pressed?

        if (y < 0)
        {
            isDownPressed = true;
        }
        else if (y > 0)
        {
            isUpPressed = true;
        }

        // Set the Animator boolean parameters based on movement direction
        _animator.SetBool("AsagiBasildi", isDownPressed);   // "AsagiBasildi" means Down Pressed
        _animator.SetBool("YukariBasildi", isUpPressed);       // "YukariBasildi" means Up Pressed

        // Apply velocity to the Rigidbody2D for movement
        _rigidBody.velocity = new Vector2(x * _movementMultiplier, y * _movementMultiplier);
    }
}