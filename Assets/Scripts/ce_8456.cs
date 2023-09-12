using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ce_8456 : MonoBehaviour
{
    public float moveSpeed = 9f;
    private float k;

    void FixedUpdate()
    {
        if (((Input.GetKey(KeyCode.Keypad8)) && (Input.GetKey(KeyCode.Keypad6))) || ((Input.GetKey(KeyCode.Keypad8)) && (Input.GetKey(KeyCode.Keypad4)))
           || ((Input.GetKey(KeyCode.Keypad5)) && (Input.GetKey(KeyCode.Keypad6))) || ((Input.GetKey(KeyCode.Keypad5)) && (Input.GetKey(KeyCode.Keypad4))))
        {
            k = 0.5f;
        }
        else { k = 1f; }

        if (Input.GetKey(KeyCode.Keypad8))
            //transform.Translate(-transform.right * moveSpeed);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.Keypad5))
            //transform.Translate(transform.right * moveSpeed);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(100, 0, -11.2065f), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.Keypad6))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, 100), Time.deltaTime * moveSpeed * k);

        if (Input.GetKey(KeyCode.Keypad4))
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5731f, 1, -100), Time.deltaTime * moveSpeed * k);
    }
}
