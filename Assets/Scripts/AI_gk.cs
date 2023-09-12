using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AI_gk : MonoBehaviour
{
    public Transform gate;
    public Transform puck;
    public Transform start_position;
    public Transform gate_end_1;
    public Transform gate_end_2;
    float end_1;
    float end_2;
    float height;

    float a2 = 0.99684f;//выступ из ворот
    float y0, y1, y3, real_y3, x0, x1, x3, a, b, c, b2, c2;
    float speed = 9f;
    bool ce = false;

    void Start()
    {
        y0 = gate.transform.position.z;
        x0 = gate.transform.position.x;
        end_1 = gate_end_1.transform.position.z;
        end_2 = gate_end_2.transform.position.z;
        height = start_position.transform.position.y;
        if (start_position.transform.position.x < gate.transform.position.x) { ce = true; }
        real_y3 = start_position.transform.position.z;
    }

    void FixedUpdate()
    {
        y1 = puck.transform.position.z;
        x1 = puck.transform.position.x;
        a = Math.Abs(x0 - x1);
        b = Math.Abs(y0 - y1);
        b2 = a2 * b / a;
        if (ce) { x3 = x0 - a2; }
        else { x3 = x0 + a2; }
        if (y1 < y0) { y3 = y0 - b2; }
        else { y3 = y0 + b2; }
        if ((y3 > end_1) && (y3 < end_2)) { real_y3 = y3; }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x3, height, real_y3), Time.deltaTime * speed);
    }
}