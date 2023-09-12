using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_8456 : MonoBehaviour
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

        if (Input.GetKey(KeyCode.Keypad5))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.Keypad8))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.Keypad4))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, 100), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.Keypad6))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, -100), Time.deltaTime * moveSpeed * k);
    }
}