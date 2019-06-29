using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;


public class LibImplTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Script.RunString("print(1+1)");

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
