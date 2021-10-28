using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform playerBody;
    private float mouseX, mouseY;
    private float xRotation = 0;
    public static bool CCenabled = true;

    // Start is called before the first frame update
    void Start()
    {
        if (CCenabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CCenabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            playerBody.Rotate(Vector3.up * mouseX);

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
