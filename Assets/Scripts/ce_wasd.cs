using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ce_wasd : MonoBehaviour
{
    public float moveSpeed = 9f;
    private float k;

    void FixedUpdate()
    {
        if (((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D))) || ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
           || ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D))) || ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A))))
        {
            k = 0.5f;
        }
        else { k = 1f; }

        if (Input.GetKey(KeyCode.W))
            //transform.Translate(-transform.right * moveSpeed);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.S))
            //transform.Translate(transform.right * moveSpeed);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.D))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, 100), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.A))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, -100), Time.deltaTime * moveSpeed * k);
    }
    
    /*
    public GameObject puck;
    bool kas = false;
    public float str = 7f;
    bool up = false;
    bool down = false;
    bool right = false;
    bool left = false;

    void FixedUpdate()
    {
        if (((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D))) || ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
           || ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D))) || ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A))))
        {
            k = 0.5f;
        }
        else { k = 1f; }

        if (Input.GetKey(KeyCode.W))
        {
            up = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);
        }
        else { up = false; }
        
        if (Input.GetKey(KeyCode.S))
        {
            down = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);
        }
        else { down = false; }

        if (Input.GetKey(KeyCode.D))
        {
            right = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, 100), Time.deltaTime* moveSpeed * k);
        }
        else { right = false; }

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, -100), Time.deltaTime * moveSpeed * k);
        }
        else { left = false; }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == puck.name)
        {
            //print("yeeees");
            kas = true;
        }
        else { kas = false; }

        if (kas)
        {
            if ((up) && (down) && (right) && (left)) { print("kek"); }
            else if ((up) && (down) && (right)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, str); }
            else if ((up) && (down) && (left)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -str); }
            else if ((up) && (right) && (left)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str, 0, 0); }
            else if ((down) && (right) && (left)) { puck.GetComponent<Rigidbody>().velocity = new Vector3(str, 0, 0); }
            else if ((up) && (down)) { print("kek"); }
            else if ((right) && (left)) { print("kek"); }

            else if (up)
            {
                if (right) { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str * 0.5f, 0, str * 0.5f); }
                else if (left) { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str * 0.5f, 0, -str * 0.5f); }
                else { puck.GetComponent<Rigidbody>().velocity = new Vector3(-str, 0, 0); }
            }
            else if (down)
            {
                if (right) { puck.GetComponent<Rigidbody>().velocity = new Vector3(str * 0.5f, 0, str * 0.5f); }
                else if (left) { puck.GetComponent<Rigidbody>().velocity = new Vector3(str * 0.5f, 0, -str * 0.5f); }
                else { puck.GetComponent<Rigidbody>().velocity = new Vector3(str, 0, 0); }
            }
            else if (right) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, str); }
            else if (left) { puck.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -str); }
        }
    }*/
}