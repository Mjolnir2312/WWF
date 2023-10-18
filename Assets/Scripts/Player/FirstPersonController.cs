using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSensitivity = 10f;

    private bool reverseRotate;
    private float dragDistance;
    //private ValidateMove _validateMove;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            RotationController();
        }
        //RotationController();

    }

    public void RotationController()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        transform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.left * mouseY);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

        //CheckRotate();
        //CheckRotate();
        //Debug.Log("Rotate y = " + transform.eulerAngles.y);
    }

    private void CheckRotate()
    {
        if(reverseRotate == false)
        {
            dragDistance += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            if(dragDistance > 80)
            {
                reverseRotate = true;
            }
        }
        else
        {
            dragDistance += -Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            if (dragDistance < -80)
            {
                reverseRotate = false;
            }
        }
        transform.rotation = Quaternion.Euler(0f,dragDistance,0f);
    }
}
