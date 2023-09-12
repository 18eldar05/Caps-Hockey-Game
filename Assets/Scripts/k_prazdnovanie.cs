using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_prazdnovanie : MonoBehaviour
{
    public Transform f1;
    public Transform f2;
    public Transform gk;
    public float moveSpeed = 4.5f;
    public int forwards = 1;

    void FixedUpdate()
    {
        if (forwards == 1)
        {
            f1.transform.position = Vector3.MoveTowards(f1.transform.position, gk.position, Time.deltaTime * moveSpeed);
            gk.transform.position = Vector3.MoveTowards(gk.transform.position, f1.position, Time.deltaTime * moveSpeed);
        }
        else
        {
            f1.transform.position = Vector3.MoveTowards(f1.transform.position, f2.position, Time.deltaTime * moveSpeed);
            f1.transform.position = Vector3.MoveTowards(f1.transform.position, gk.position, Time.deltaTime * moveSpeed);

            f2.transform.position = Vector3.MoveTowards(f2.transform.position, f1.position, Time.deltaTime * moveSpeed);
            f2.transform.position = Vector3.MoveTowards(f2.transform.position, gk.position, Time.deltaTime * moveSpeed);

            gk.transform.position = Vector3.MoveTowards(gk.transform.position, f1.position, Time.deltaTime * moveSpeed);
            gk.transform.position = Vector3.MoveTowards(gk.transform.position, f2.position, Time.deltaTime * moveSpeed);
        }
    }
}
