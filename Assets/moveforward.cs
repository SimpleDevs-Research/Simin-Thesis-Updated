using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforward : MonoBehaviour
{
    public float thrust=0.1f;
    private float init_thrust = 0.1f;
    private Rigidbody rb;
    public GameObject wall = null;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
       // init_thrust = Random.Range(0.07f, 0.15f);
    }

    void FixedUpdate()
    {
        if (wall != null && !wall.activeSelf)
            wall = null;

        if (wall == null)
            thrust = init_thrust;
        else
            thrust = 0;

        transform.Translate(Vector3.forward * thrust, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == gameObject)
            return;
        if (other.tag == "block" )
        {
            if (other.transform.forward==transform.forward)
            {
                wall = other.gameObject;
            }
        }

        if (other.tag == "carback")
        {
            wall = other.gameObject;
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other == gameObject)
            return;
        if (other.tag == "block")
        {
            if (other.transform.forward == transform.forward)
            {
                wall = other.gameObject;
            }
        }

        if (other.tag == "carback")
        {
            wall = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "carback")
        {
            wall = null;
        }
    }

    /*private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "block" || col.tag == "car")
        {
            Debug.Log("Hit");
            thrust = 0;
        }

    }

    private void OnTriggerExit(Collider col)
    {


        if (col.tag == "block")
        {
            Debug.Log("COlor");
            thrust = 0.1f;
        }

    }*/


}
