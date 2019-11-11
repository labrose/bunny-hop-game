using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBounds : MonoBehaviour
{
    private BoxCollider groundBC;

    private float xbound;
    private float zbound;

    // Start is called before the first frame update
    void Start()
    {
        groundBC = GameObject.Find("Ground").GetComponent<BoxCollider>();

        xbound = groundBC.size.x;
        zbound = groundBC.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xbound)
        {
            transform.position = new Vector3(xbound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xbound)
        {
            transform.position = new Vector3(-xbound, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zbound);
        }

        if (transform.position.z < -zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zbound);
        }
    }
}
