using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float rotateX = 0, rotateY = 0, rotateZ = 0;

    void Update()
    {
        if (Time.timeScale == 1)
        {
            transform.Rotate(rotateX, rotateY, rotateZ);
        }
    }
}
