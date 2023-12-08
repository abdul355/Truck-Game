using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TruckController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 25f;

    public Transform Truck_Wheel_AR;
    public Transform Truck_Wheel_FL;
    public Transform Truck_Wheel_FR;

    [System.Serializable]
    public class TruckData
    {
        public float positionX;
        public float positionY;
        public float positionZ;
        public float rotationY;
    }

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

        // Save truck data to JSON file
        SaveTruckData();
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

    void SaveTruckData()
    {
        
        TruckData truckData = new TruckData
        {
            positionX = transform.position.x,
            positionY = transform.position.y,
            positionZ = transform.position.z,
            rotationY = transform.rotation.eulerAngles.y
        };

       
        string json = JsonUtility.ToJson(truckData);

       
        string filePath = Application.dataPath + "Assets/Resources/truckData.json";

      
        File.WriteAllText(filePath, json);
    }
}




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TruckController : MonoBehaviour
// {
//     public float speed = 10f;
//     public float rotationSpeed = 25f;

//     public Transform Truck_Wheel_AR;
//     public Transform Truck_Wheel_FL;
//     public Transform Truck_Wheel_FR;

//     void Update()
//     {
//         float moveInput = Input.GetAxis("Vertical");
//         float rotateInput = Input.GetAxis("Horizontal");

//         // Move the truck forward or backward
//         transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);

//         // Rotate the truck left or right
//         transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime);

//         // Rotate the wheels based on truck movement
//         RotateWheels(moveInput, rotateInput);
//     }

//     void RotateWheels(float moveInput, float rotateInput)
//     {
//         float rotationAmount = moveInput * rotationSpeed * Time.deltaTime;

//         // Rotate the front wheels around the correct axis 
//         Truck_Wheel_FL.Rotate(Vector3.right * rotationAmount);
//         Truck_Wheel_FR.Rotate(Vector3.right * rotationAmount);

//         // Rotate the rear wheels around the correct axis
//         Truck_Wheel_AR.Rotate(Vector3.right * rotationAmount);

//         // Additional rotation for turning left or right
//         // if (rotateInput < 0)
//         // {
//         //     Truck_Wheel_FL.Rotate(Vector3.up * rotationAmount);
//         //     Truck_Wheel_FR.Rotate(Vector3.up * rotationAmount);
//         // }
//         // else if (rotateInput > 0)
//         // {
//         //     Truck_Wheel_FL.Rotate(Vector3.down * rotationAmount);
//         //     Truck_Wheel_FR.Rotate(Vector3.down * rotationAmount);
//         // }
//     }
// }

