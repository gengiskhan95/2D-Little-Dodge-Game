using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int _hitCount;
    private HashSet<GameObject> collidedObjects;

    private void Start()
    {
        collidedObjects = new HashSet<GameObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Eğer daha önce bu obje ile çarpıştıysanız sayma
        if (collidedObjects.Contains(collision.gameObject))
        {
            Debug.Log($"Collision detected with {collision.gameObject.name}, but it has already been counted before.");
            return;
        }

        // İlk kez çarpışılan objeyi kaydedin
        collidedObjects.Add(collision.gameObject);

        // Çarpışma sayısını artır
        _hitCount++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        Debug.Log($"You've collided with an object this many times: {_hitCount}");
    }

    public int GetHitCount()
    {
        return _hitCount;
    }

    public void ResetHitCount()
    {
        _hitCount = 0;
        collidedObjects.Clear();
        UpdateScoreDisplay();
    }
}
