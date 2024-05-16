using UnityEngine;

public class Spinner : MonoBehaviour
{
    [Header("Rotation Settings")]

    [Tooltip("Rotation speed around the X axis.")]
    [SerializeField] private float rotationSpeedX = 0f;

    [Tooltip("Rotation speed around the Y axis.")]
    [SerializeField] private float rotationSpeedY = 150f;

    [Tooltip("Rotation speed around the Z axis.")]
    [SerializeField] private float rotationSpeedZ = 0f;

    void Update()
    {
        if (Time.timeScale == 1)
        {
            RotateObject();
        }
    }

    private void RotateObject()
    {
        Vector3 rotation = new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime;
        transform.Rotate(rotation);
    }
}
