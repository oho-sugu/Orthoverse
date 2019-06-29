using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.Parser
{
    public class ATag : ParseNode
    {
        public override GameObject parse(HtmlNode homlNode, GameObject parent)
        {
            GameObject a = new GameObject(homlNode.GetAttributeValue("href", "atag"));
            a.transform.parent = parent.transform;
            a.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            a.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));

            DOM.ATag at = a.AddComponent<DOM.ATag>();
            at.url = homlNode.GetAttributeValue("href", "atag");

            return a;
        }
    }
}

