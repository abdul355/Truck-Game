using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speedometer : MonoBehaviour
{
    public Rigidbody truckRigidbody;
    public Text speedText;

    void Update()
    {
        if (truckRigidbody != null && speedText != null)
        {
            // Assuming the truck moves along the forward axis
            float speed = truckRigidbody.velocity.magnitude * 2.23694f; // m/s to mph
            speedText.text = "Speed: " + Mathf.Round(speed) + " mph";
        }
    }
}
