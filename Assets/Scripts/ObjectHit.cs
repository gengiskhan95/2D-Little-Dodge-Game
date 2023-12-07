using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HandleObjectHit();
        }
    }
    private void HandleObjectHit()
    {
        meshRenderer.material.color = Color.red;
        gameObject.tag = "Hit";
    }
}
