using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private GameManager _gameManager;
    private bool isInside = false;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("No GameManager object was found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;
            Debug.Log("Player entered the trigger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = false;
            Debug.Log("Player exited the trigger.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collider triggerCollider = GetComponent<Collider>();
            Collider playerCollider = other;

            if (IsPlayerCompletelyInside(triggerCollider, playerCollider))
            {
                Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.velocity = Vector3.zero;
                    playerRigidbody.angularVelocity = Vector3.zero;
                    playerRigidbody.isKinematic = true;  // Player objesini tamamen durdurur
                }

                if (_gameManager != null)
                {
                    _gameManager.FinishGame();
                    Debug.Log("Player is completely inside the trigger. Game finished!");
                }
            }
        }
    }

    private bool IsPlayerCompletelyInside(Collider triggerCollider, Collider playerCollider)
    {
        // Player objesinin tamamen trigger alanının içinde olup olmadığını kontrol et
        Bounds triggerBounds = triggerCollider.bounds;
        Bounds playerBounds = playerCollider.bounds;

        return triggerBounds.Contains(playerBounds.min) && triggerBounds.Contains(playerBounds.max);
    }
}
