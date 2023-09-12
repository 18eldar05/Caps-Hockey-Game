using UnityEngine;
using System;

public class nice_going : MonoBehaviour
{
    public float speed = 10f;
    public float sensitiveX = 3f;
    public float sensitiveY = 3f;
    float rotX = 0f;
    float rotY = 0f;

    float px, py;
    float ak = 0.00001f;
    float bk = 0.00001f;

    bool up = false;
    bool down = false;
    bool right = false;
    bool left = false;
    
    void FixedUpdate()
    {
        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        if (0 < Input.GetAxis("Mouse Y") * sensitiveY)
        {
            up = true;
            down = false;
            if ((Input.GetAxis("Mouse Y") * sensitiveY != 0) && (Input.GetAxis("Mouse X") * sensitiveX != 0)) { bk = Input.GetAxis("Mouse Y") * sensitiveY; }
        }
        if (0 > Input.GetAxis("Mouse Y") * sensitiveY)
        {
            down = true;
            up = false;
            if ((Input.GetAxis("Mouse Y") * sensitiveY != 0) && (Input.GetAxis("Mouse X") * sensitiveX != 0)) { bk = -Input.GetAxis("Mouse Y") * sensitiveY; }
        }
        if (0 < Input.GetAxis("Mouse X") * sensitiveX)
        {
            right = true;
            left = false;
            if ((Input.GetAxis("Mouse X") * sensitiveX != 0) && (Input.GetAxis("Mouse Y") * sensitiveY != 0)) { ak = Input.GetAxis("Mouse X") * sensitiveX; }
        }
        if (0 > Input.GetAxis("Mouse X") * sensitiveX)
        {
            left = true;
            right = false;
            if ((Input.GetAxis("Mouse X") * sensitiveX != 0) && (Input.GetAxis("Mouse Y") * sensitiveY != 0)) { ak = -Input.GetAxis("Mouse X") * sensitiveX; }
        }

        px = ak / (bk + ak);
        py = 1 - px;

        if (up) { transform.position = Vector3.MoveTowards(transform.position, new Vector3(-100, 0, -11.2065f), Time.deltaTime * speed * py); }
        
        if (down) { transform.position = Vector3.MoveTowards(transform.position, new Vector3(100, 0, -11.2065f), Time.deltaTime * speed * py); }
        
        if (right) { transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, /*1*/0, 100), Time.deltaTime * speed * px); }
        
        if (left) { transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, /*1*/0, -100), Time.deltaTime * speed * px); }
    }
}
