using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    public Transform gate;
    public Transform puck;
    //public Transform teammate;
    public Transform cap_sp;
    //public Transform point;

    float r = 0.574219f;
    float y0, y1, y2, x0, x1, x2, a, b, c, a1, b1, c1, sinb;
    double cd, a1d;
    float speed = 9f;
    float dist;
    float tm_dist;
    float height;
    //float time = 0;

    void Start()
    {
        y0 = gate.transform.localPosition.z;
        x0 = gate.transform.localPosition.x;
        height = cap_sp.transform.localPosition.y;
    }

    void FixedUpdate()
    {
        y1 = puck.transform.localPosition.z;
        x1 = puck.transform.localPosition.x;
        a = Math.Abs(x0 - x1);
        b = Math.Abs(y0 - y1);
        cd = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        c = (float)cd;
        sinb = b / c;
        c1 = c + 2 * r;
        b1 = c1 * sinb;
        a1d = Math.Sqrt(Math.Pow(c1, 2) - Math.Pow(b1, 2));
        a1 = (float)a1d;
        if (x0 > x1) { x2 = x0 - a1; }
        else { x2 = x0 + a1; }
        if (y0 > y1) { y2 = y0 - b1; }
        else { y2 = y0 + b1; }

        //dist = Vector3.Distance(transform.position, puck.transform.position);
        //tm_dist = Vector3.Distance(teammate.transform.position, puck.transform.position);

        //if (dist >= tm_dist)
        //{
        //if (dist > 4)
        //{
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(x2, 3.730925f, y2), Time.deltaTime * speed);
        //}
        //else { transform.position = Vector3.MoveTowards(transform.position, gate.transform.position, Time.deltaTime * speed); }
        //print("nope");
        //}
        //else
        //{
        //point.transform.localPosition = new Vector3(x2, height, y2);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(x2, height, y2), Time.deltaTime * speed);
        //transform.localPosition = Vector3.MoveTowards(transform.localPosition, point.transform.localPosition, Time.deltaTime * speed);
        //}

        if (transform.localPosition == /*point.transform.localPosition*/new Vector3(x2, height, y2))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, puck.transform.localPosition, Time.deltaTime * speed);
        }

        //if (time > 0) { time -= 0.02f; }

        //if (transform.position == new Vector3(x2, 3.730925f, y2))
        //{
        //    time = 0.2f;
        //}

        //if (time > 0) { transform.position = Vector3.MoveTowards(transform.position, puck.transform.position, Time.deltaTime * speed); }
        //else { transform.position = Vector3.MoveTowards(transform.position, new Vector3(x2, 3.730925f, y2), Time.deltaTime * speed); }
    }

    //void OnCollisionStay(Collision other)
    //{
    //    if (other.gameObject.name == teammate.name)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, teammate.transform.position, -Time.deltaTime * speed);
    //    }
    //}
}
