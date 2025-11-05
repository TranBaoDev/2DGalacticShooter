using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // We want the background to move continuously
    [SerializeField] GameObject _image1;
    [SerializeField] GameObject _image2;

    GameObject _active; // The currently active background (which one is on screen — 1 or 2)
    GameObject _right;  // The background that is currently inactive (off-screen)
    float distanceX;    // The horizontal distance between the two images
    float minX;         // The minimum X position before looping
    [SerializeField] float _scrollSpeed = 0.01f;

    void Start()
    {
        _active = _image1;
        _right = _image2;

        // Calculate the distance between the two background images
        distanceX = _right.transform.position.x - _active.transform.position.x;

        // Calculate the minimum X position the active image can reach before resetting
        minX = _active.transform.position.x - distanceX;
        // If the background moves past this point, it should loop back to the start
    }

    void Update()
    {
        // Move both background images to the left at the scroll speed
        _active.transform.position += new Vector3(-_scrollSpeed, 0.0f, 0.0f);
        _right.transform.position += new Vector3(-_scrollSpeed, 0.0f, 0.0f);

        // If the active background goes slightly past minX, loop it back
        if (_active.transform.position.x < minX)
        {
            // Move the active background to the right side of the other background
            _active.transform.position = _right.transform.position + new Vector3(distanceX, 0.0f, 0.0f);

            // Swap references so we don’t lose track of which background is active
            GameObject temp = _active;
            _active = _right;
            _right = temp;
        }
    }
}
