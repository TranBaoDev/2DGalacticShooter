using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Health Bar Code
public class HealthBarCode : MonoBehaviour // "HayatCizgisiKod" means Health Bar Code
{
    // Private fields for health management
    int _totalHealth;   // "toplamYasam" means total life/health
    int _remainingHealth; // "kalanYasam" means remaining life/health
    float _scale;       // "olcek" means scale/ratio

    // Reference to the visual green bar GameObject (the one that scales)
    [SerializeField] GameObject _greenBar; // "yesilBar" means green bar

    // Public property for Total Health
    public int TotalHealth
    {
        // Get accessor
        get { return _totalHealth; }

        // Set accessor: Initially, remaining health is the same as total health
        // Comment: initially the value of total life and remaining life are the same
        set
        {
            _totalHealth = value;
            _remainingHealth = value;
        }
    }

    // Public property for Remaining Health (Read-only)
    public int RemainingHealth
    {
        get { return _remainingHealth; }
    }


    void Start()
    {
        // ToplamYasam = 8; // Commented out example
    }

    // Function to decrease health and update the visual bar
    public void DecreaseHealth(int decreaseAmount = 1) // "YasamAzalt" means Decrease Health
    {
        // Decrease remaining health
        _remainingHealth -= decreaseAmount;

        // Ensure health does not go below zero
        if (_remainingHealth < 0)
            _remainingHealth = 0;

        // Calculate the ratio of remaining health (for scaling the bar)
        // Comment: remaining life in the bar
        _scale = (float)_remainingHealth / (float)_totalHealth;

        // Get the current scale vector of the green bar
        var scaleVector = _greenBar.transform.localScale;

        // Set the X-component of the scale vector to the calculated health ratio
        scaleVector.x = _scale;

        // Apply the new scale vector to the green bar's transform
        _greenBar.transform.localScale = scaleVector;

    }

    // Update is called once per frame
    void Update()
    {
        /* if(Input.GetKeyDown(KeyCode.Space)){
             DecreaseHealth();
         }*/
    }
}