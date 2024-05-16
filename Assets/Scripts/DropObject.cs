using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class DropObject : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidBody;
    [SerializeField] private float timeToWait = 0f;
    private bool _hasDropped = false;

    private void Awake()
    {
        InitializeComponents();
        DisableObject();
    }

    private void InitializeComponents()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void DisableObject()
    {
        _meshRenderer.enabled = false;
        _rigidBody.useGravity = false;
    }

    private void Update()
    {
        if (ShouldDropObject())
        {
            DropObjectNow();
        }
    }

    private bool ShouldDropObject()
    {
        return Time.time > timeToWait && !_hasDropped && timeToWait > 0f;
    }

    private void DropObjectNow()
    {
        _meshRenderer.enabled = true;
        _rigidBody.useGravity = true;
        _hasDropped = true;
    }
}