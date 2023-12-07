using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableObstaclesPhysics();
        }
    }

    private void EnableObstaclesPhysics()
    {
        foreach (var obstacle in obstacles)
        {
            MeshRenderer renderer = obstacle.GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                renderer.enabled = true;
            }

            Rigidbody rigidbody = obstacle.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.useGravity = true;
            }
        }
    }
}
