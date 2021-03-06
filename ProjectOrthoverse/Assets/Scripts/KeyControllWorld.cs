﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControllWorld : MonoBehaviour
{
    public GameObject center;

    public Material defaultMat;
    public Material depthOnly;
    public GameObject cityData;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition += new Vector3(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += new Vector3(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition += new Vector3(0f, 0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition += new Vector3(0f, 0f, -0.1f);
        }
        if (Input.GetKey(KeyCode.U))
        {
            transform.localPosition += new Vector3(0f, 0.1f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(0f, -0.1f, 0f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.RotateAround(center.transform.position, Vector3.up, 0.1f);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.RotateAround(center.transform.position, Vector3.up, -0.1f);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            cityData.GetComponent<Renderer>().material = defaultMat;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            cityData.GetComponent<Renderer>().material = depthOnly;
        }

    }
}
