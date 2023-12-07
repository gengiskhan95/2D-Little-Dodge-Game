using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int hits;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        Debug.Log("You've collided with an object this many times: " + hits);
    }
}
