using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    /// <summary>
    /// Store the physics body of the Hero Ship
    /// </summary>
    private Rigidbody2D shipPhysics;

    /// <summary>
    /// Multiplier for the forces applied to the Hero ship. Input values are too low to properly move the ship
    /// </summary>
    public float moveSpeed = 30f;

    public GameObject firingProjectile;

    // Start is called before the first frame update
    void Start()
    {
        shipPhysics = GetComponent<Rigidbody2D>();

        if (shipPhysics == null)
        {
            Debug.Log("No rigidbody found for Hero ship");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();

        Movement();

        Rotation();

        //////////////////////////////////////////////////////////////////////////////////
        //// Ei toimivaa hiiren liikkeestä
        //shipPhysics.MoveRotation(Quaternion.Euler(new Vector3(0f, 0f, rotationDirection)));
    }

    private void Rotation()
    {
        Vector2 stickVector = new Vector3(Input.GetAxis("RightStick Horizontal"), Input.GetAxis("RightStick Vertical"));


        if (stickVector.magnitude > 0)
        {
            Vector3 currentRotation = Vector3.left * stickVector.x + Vector3.up * stickVector.y;
            shipPhysics.SetRotation(Quaternion.LookRotation(currentRotation, Vector3.forward));
        }
    }

    private void Movement()
    {
        Vector2 leftStickInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if (leftStickInput.magnitude > 0)
        {
            shipPhysics.MovePosition(shipPhysics.position + leftStickInput * moveSpeed * Time.deltaTime);
        }
    }

    private void Shooting()
    {
        if (Input.GetAxis("Fire1") > 0 || Input.GetAxis("Xbox RightTrigger") > 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Instantiate a projectile from prefab, place it on players position and rotate it to player heading
        GameObject bullet = Instantiate(firingProjectile, gameObject.transform.position, transform.rotation);
    }

    ///// Juicing tips:
    /// EASING 
    /// TWEENING
    /// STRETCHING
    /// SCALING
}