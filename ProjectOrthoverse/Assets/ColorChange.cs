using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Material mat;
    float f;
    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        mat.SetColor("_BaseColor", new Color(1.0f, f, 0.0f));
        f = f + 0.05f;
        if (f > 1.0f) f = 0.0f;
    }
}
