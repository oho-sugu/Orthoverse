using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HtmlAgilityPack;

public class LibImplTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        var context = new NLua.Lua();

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
