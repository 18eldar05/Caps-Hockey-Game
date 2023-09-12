using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_start_position : MonoBehaviour
{
    public Transform f1;
    public Transform f2;
    public Transform gk;
    public Transform spf1;
    public Transform spf2;
    public Transform spgk;
    public float moveSpeed = 5f;
    public int forwards = 1;

    void Update()
    {
        if (forwards == 1)
        {
            f1.transform.position = Vector3.MoveTowards(f1.transform.position, spf1.position, Time.deltaTime * moveSpeed);
            gk.transform.position = Vector3.MoveTowards(gk.transform.position, spgk.position, Time.deltaTime * moveSpeed);
        }
        else
        {
            f1.transform.position = Vector3.MoveTowards(f1.transform.position, spf1.position, Time.deltaTime * moveSpeed);
            f2.transform.position = Vector3.MoveTowards(f2.transform.position, spf2.position, Time.deltaTime * moveSpeed);
            gk.transform.position = Vector3.MoveTowards(gk.transform.position, spgk.position, Time.deltaTime * moveSpeed);
        }
    }
}
