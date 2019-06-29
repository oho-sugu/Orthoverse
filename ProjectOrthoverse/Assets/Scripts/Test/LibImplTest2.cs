using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HtmlAgilityPack;

public class LibImplTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var doc = new HtmlAgilityPack.HtmlDocument();

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
