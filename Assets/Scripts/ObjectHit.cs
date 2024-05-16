using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_meshRenderer == null)
        {
            Debug.LogError($"MeshRenderer component is missing on {gameObject.name}");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandleObjectHit();
        }
    }

    private void HandleObjectHit()
    {
        if (_meshRenderer != null)
        {
            _meshRenderer.material.color = Color.red;
        }

        gameObject.tag = "Hit";
    }
}
