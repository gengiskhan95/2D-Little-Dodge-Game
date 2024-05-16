using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PrintInstructions();
    }

    void Update()
    {
        MovePlayer();
    }

    private void PrintInstructions()
    {
        Debug.Log("Welcome to the game! Here's how to play:");
        Debug.Log("Use WASD keys to control your character's movement.");
        Debug.Log("Be careful not to collide with the walls!");
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Eğer herhangi bir tuşa basılmamışsa hareket etmeyecek
        if (horizontalInput == 0 && verticalInput == 0)
        {
            rb.isKinematic = true; // Fiziksel etkilerden korunur
        }
        else
        {
            rb.isKinematic = false; // Fiziksel etkiler geri gelir
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}
