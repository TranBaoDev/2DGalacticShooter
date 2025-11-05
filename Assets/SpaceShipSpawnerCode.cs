using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SpaceShip Spawner, inherits from Enemy Spawner. It accesses its members. Enemy Spawner already inherits from MonoBehaviour.
public class SpaceShipSpawnerCode : EnemySpawner // "SpaceShipUreticiKod" means SpaceShip Spawner Code
{

    // Serialized fields to be set in the Unity Inspector
    [SerializeField] GameObject _enemyPrefab; // "DusmanSablon" means Enemy Template/Prefab
    [SerializeField] Transform _bottomLimit; // "AltSinir" means Bottom Limit
    [SerializeField] Transform _upperLimit;  // "UstSinir" means Upper Limit

    // Overrides the base Uret() method ("Uret" means Produce/Spawn)
    public override void Spawn()
    {
        // Get the x-position from the bottom limit (assuming enemies spawn from the side)
        float x = _bottomLimit.position.x;

        // Randomly choose a y-position between the bottom and upper limits
        float y = Random.Range(_bottomLimit.position.y, _upperLimit.position.y);

        // Instantiate the new enemy prefab
        var newEnemy = Instantiate(_enemyPrefab); // "yeniDusman" means new Enemy
        // Set the enemy's starting position
        newEnemy.transform.position = new Vector3(x, y, 0);

        // print("spaceshipuretici"); // This line was commented out in the original code
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