using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles = null;

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
            if (obstacle.TryGetComponent(out MeshRenderer renderer))
            {
                renderer.enabled = true;
            }

            if (obstacle.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.useGravity = true;
            }
        }
    }
}