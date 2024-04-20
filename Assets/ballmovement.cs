using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballmovement : MonoBehaviour
{
    public float speed = 5f; // The movement speed of the ball

    private Rigidbody rb;



    public int pointValue = 10; // Points awarded for each coin collected
    public Text pointText; // Reference to the UI Text element to display the points

    private int points = 0; // Total points collected

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Increase points
            points += pointValue;

            // Update UI text
            if (pointText != null)
            {
                pointText.text = "Points: " + points.ToString();
            }

            // Destroy the collected coin
            Destroy(other.gameObject);
        }
    }


private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal input
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical input

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); // Create a movement vector

        rb.AddForce(movement * speed); // Apply the force to the Rigidbody
    }
}
