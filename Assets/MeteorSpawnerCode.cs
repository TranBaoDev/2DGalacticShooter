using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Meteor Code/Class (Kod)
// Inherits from Enemy Spawner (DusmanUretici)
public class MeteorSpawnerCode : EnemySpawner
{

    // Serialized fields to be assigned in the Unity Inspector
    [SerializeField] GameObject _meteorPrefab; // "Sablon" means template/prefab
    [SerializeField] Transform _bottomLimit; // "AltSinir" means Bottom Limit
    [SerializeField] Transform _upperLimit;  // "UstSinir" means Upper Limit
    [SerializeField] Transform _player;

    // Overrides the base Uret() method ("Uret" means Produce/Spawn)
    public override void Spawn()
    {
        // Get the x-position from the bottom limit (assuming meteors spawn from the side)
        float x = _bottomLimit.position.x;

        // Randomly choose a y-position between the bottom and upper limits
        float y = Random.Range(_bottomLimit.position.y, _upperLimit.position.y);



        // Instantiate the meteor prefab
        var meteor = Instantiate(_meteorPrefab);
        // Set the meteor's starting position
        meteor.transform.position = new Vector3(x, y, 0);

        // We need to generate a velocity vector to make it go towards the player.
        // If we subtract the meteor's spawn point from the player's position, we get a velocity vector pointing in that direction.
        Vector3 velocity = _player.position - meteor.transform.position;

        // We added the resulting velocity vector to the Rigidbody2D's velocity.
        // Velocity defines the direction of the movement of the body or the object.
        // normalized makes the speed 1 unit long (i.e., slows it down to a unit vector for direction only)
        meteor.GetComponent<Rigidbody2D>().velocity = velocity.normalized * 10.0f;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}