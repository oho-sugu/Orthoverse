using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScroll : MonoBehaviour
{
    Material mat;
    float u=0f;

    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetTextureOffset("_BaseMap", new Vector2(u, 0.0f));
        u -= 0.003f;
        if (u < -0.5f) u = 0.5f;
    }
}
