using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class omnomnom : MonoBehaviour
{
    public Transform Puck;
    public Transform Gate;
    bool kas = false;

    void Start()
    {
        
    }

    //сделать чтоб двигался к точке на пересечении прямой(через ворота и шайбу) и окружности вокруг шайбы
    // и чтоб потом бил(типо шёл) к воротам
    void FixedUpdate()
    {
        if (!kas)
        {
            transform.position = Vector3.MoveTowards(transform.position, Puck.position, Time.deltaTime);
            Debug.Log("Idu k shaybe");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Gate.position, Time.deltaTime);
            Debug.Log("Vedu k vorotam");
        }
    }

    void OnCollisionStay(Collision other)
    {
        print(other.gameObject.name);
        if (other.gameObject.name == "Puck")
        {
            print("yeeees");
            kas = true;
        }
        else { kas = false; }
    }
}
