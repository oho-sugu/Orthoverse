using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveProducer : MonoBehaviour {
    public GameObject Cube;
    public GameObject Sphere;
    public GameObject Cylinder;
    public GameObject Quad;
    public GameObject Capsule;

    public GameObject getCube()
    {
        return Cube;
    }

    public GameObject getSphere()
    {
        return Sphere;
    }

    public GameObject getCylinder()
    {
        return Cylinder;
    }

    public GameObject getQuad()
    {
        return Quad;
    }

    public GameObject getCapsule()
    {
        return Capsule;
    }
}
