using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform tankBody; // The tank body, for gun to stick to
    private Camera mainCamera;
    //public float angleOffset = -90f; // Adjust this value if needed

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure no change in Z position

        // Calculate the direction from the gun to the mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle for the rotation, adding an offset if needed
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270f;


        // Rotate the gun towards the mouse
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Keep the gun attached to the tank
        transform.position = tankBody.position;
    }
}
