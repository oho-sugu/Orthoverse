using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.Parser
{
    public class ParseNode
    {
        public virtual GameObject parse(HtmlNode homlNode, GameObject parent) { throw new System.NotImplementedException(); }
        
        // Vector3 parser
        // Color parser
        // Parse all attribute and store them to dictionary
        // Script
        // External files read
        // DeSingleton how to?
        // can parse be public static and overrideable?
    }
}
