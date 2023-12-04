
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 25f;

    public Transform Truck_Wheel_AR;
    public Transform Truck_Wheel_FL;
    public Transform Truck_Wheel_FR;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // Move the truck forward or backward
        transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);

        // Rotate the truck left or right
        transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime);

        // Rotate the wheels based on truck movement
        RotateWheels(moveInput, rotateInput);
    }

    void RotateWheels(float moveInput, float rotateInput)
    {
        float rotationAmount = moveInput * rotationSpeed * Time.deltaTime;

        // Rotate the front wheels around the correct axis 
        Truck_Wheel_FL.Rotate(Vector3.right * rotationAmount);
        Truck_Wheel_FR.Rotate(Vector3.right * rotationAmount);

        // Rotate the rear wheels around the correct axis
        Truck_Wheel_AR.Rotate(Vector3.right * rotationAmount);

        // Additional rotation for turning left or right
        // if (rotateInput < 0)
        // {
        //     Truck_Wheel_FL.Rotate(Vector3.up * rotationAmount);
        //     Truck_Wheel_FR.Rotate(Vector3.up * rotationAmount);
        // }
        // else if (rotateInput > 0)
        // {
        //     Truck_Wheel_FL.Rotate(Vector3.down * rotationAmount);
        //     Truck_Wheel_FR.Rotate(Vector3.down * rotationAmount);
        // }
    }
}

