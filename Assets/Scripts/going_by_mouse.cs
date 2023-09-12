using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class going_by_mouse : MonoBehaviour
{
    public GameObject puck;

    bool kas = false;

    public float str = 7f;

    public float speed = 9f;

    public float sensitiveX = 3f;
    public float sensitiveY = 3f;

    private float rotX = 0f;
    private float rotY = 0f;

    private float px;
    private float py;
    private float a = 0.00001f;
    private float b = 0.00001f;

    bool up = false;
    bool down = false;
    bool right = false;
    bool left = false;

    //void OnCollisionStay(Collision other)
    //{
    //    if (other.gameObject.name == "Puck")
    //    {
    //        print("yeeees");
    //        kas = true;
    //    }
    //    else { kas = false; }
    //}

        void FixedUpdate()
    {
        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        if (0 < Input.GetAxis("Mouse Y") * sensitiveY)
        {
            up = true;
            down = false;
            if ((Input.GetAxis("Mouse Y") * sensitiveY != 0) && (Input.GetAxis("Mouse X") * sensitiveX != 0)) { b = Input.GetAxis("Mouse Y") * sensitiveY; }
        }
        if (0 > Input.GetAxis("Mouse Y") * sensitiveY)
        {
            down = true;
            up = false;
            if ((Input.GetAxis("Mouse Y") * sensitiveY != 0) && (Input.GetAxis("Mouse X") * sensitiveX != 0)) { b = -Input.GetAxis("Mouse Y") * sensitiveY; }
        }
        if (0 < Input.GetAxis("Mouse X") * sensitiveX)
        {
            right = true;
            left = false;
            if ((Input.GetAxis("Mouse X") * sensitiveX != 0) && (Input.GetAxis("Mouse Y") * sensitiveY != 0)) { a = Input.GetAxis("Mouse X") * sensitiveX; }
        }
        if (0 > Input.GetAxis("Mouse X") * sensitiveX)
        {
            left = true;
            right = false;
            if ((Input.GetAxis("Mouse X") * sensitiveX != 0) && (Input.GetAxis("Mouse Y") * sensitiveY != 0)) { a = -Input.GetAxis("Mouse X") * sensitiveX; }
        }


        px = a / (b + a);
        py = 1 - px;


        if (up)
        {
            //print("Up");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-100, 0, -11.2065f), Time.deltaTime * speed * py);
            //if (kas)
            //{
            //    if (right) { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str * py, 0, str * px); }
            //    if (left) { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str * py, 0, -str * px); }
            //}
        }
        if (down)
        {
            //print("Down");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(100, 0, -11.2065f), Time.deltaTime * speed * py);
            //if (kas)
            //{
            //    if (right) { puck.GetComponent<Rigidbody>().velocity = new Vector3(str * py, 0, str * px); }
            //    if (left) { puck.GetComponent<Rigidbody>().velocity = new Vector3(str * py, 0, -str * px); }
            //}
        }
        if (right)
        {
            //print("right");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, /*1*/0, 100), Time.deltaTime * speed * px);
            //if ((kas) && (!up) && (!down)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, str * px); }
        }
        if (left)
        {
            //print("left");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, /*1*/0, -100), Time.deltaTime * speed * px);
            //if ((kas) && (!up) && (!down)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -str * px); }
        }

        //print("Mouse X" + rotX);
        //print("Mouse Y" + rotY);

        //print("Mouse X " + px);
        //print("Mouse Y " + py);

        
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == puck.name/*"Puck"*/)
        {
            //print("yeeees");
            kas = true;
        }
        else { kas = false; }

        if (kas)
        {
            if (up)
            {
                if (right) { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str * py, 0, str * px); }
                else if (left) { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str * py, 0, -str * px); }
                else { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str * py, 0, 0); }
            }
            if (down)
            {
                
                if (right) { puck.GetComponent<Rigidbody>().velocity = new Vector3(str * py, 0, str * px); }
                else if (left) { puck.GetComponent<Rigidbody>().velocity = new Vector3(str * py, 0, -str * px); }
                else { puck.GetComponent<Rigidbody>().velocity = new Vector3(str * py, 0, 0); }

            }
            if (right)
            {
                if ((!up) && (!down)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, str * px); }
            }
            if (left)
            {
                if ((!up) && (!down)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -str * px); }
            }
        }
    }
}
