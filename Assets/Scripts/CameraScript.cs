using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Rigidbody rb;


    public GameObject target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = target.transform.position + new Vector3(0, 2.0f, -5f);

        if (Input.GetKey(KeyCode.D))
        {
            //rb.angularVelocity = new Vector3(0, 0, 5f);
            transform.RotateAround(target.transform.position, Vector3.up, 5f);
            //transform.Rotate(new Vector3(0, 5, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //rb.angularVelocity = new Vector3(0, 0, -5f);
            transform.RotateAround(target.transform.position, Vector3.up, -5f);
            //transform.Rotate(new Vector3(0, -5, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            //rb.angularVelocity = new Vector3(0, 0, -5f);
            transform.RotateAround(target.transform.position, Vector3.left, 5f);
            //transform.Rotate(new Vector3(0, -5, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //rb.angularVelocity = new Vector3(0, 0, -5f);
            transform.RotateAround(target.transform.position, Vector3.left, -5f);
            //transform.Rotate(new Vector3(0, -5, 0));
        }
        else
        {
            this.transform.LookAt(this.target.transform);
            //transform.position = target.transform.position + new Vector3(-2, 2, -5f);
            //transform.rotation = transform.rotation;
        }
    }
}
