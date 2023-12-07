using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Rigidbody rigidBody;
    [SerializeField] float timeToWait = 0;
    private bool hasDropped = false;

    void Start()
    {
        InitializeComponents();
        DisableObject();
    }
    private void InitializeComponents()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();
    }
    private void DisableObject()
    {
        meshRenderer.enabled = false;
        rigidBody.useGravity = false;
    }

    void Update()
    {
        if (Time.time > timeToWait && timeToWait != 0 && !hasDropped)
        {
            DropObjectNow();
        }

    }
    private void DropObjectNow()
    {
        meshRenderer.enabled = true;
        rigidBody.useGravity = true;
        hasDropped = true;
    }
}
