using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ce_wasd_idet_kuda_smotrit : MonoBehaviour
{
    public float moveSpeed = 9f;

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.Keypad6))

        //if (Input.GetKey(KeyCode.Keypad4))
    }
}