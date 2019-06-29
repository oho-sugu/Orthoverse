using System;
using System.Collections;
using System.Collections.Generic;
using HtmlAgilityPack;
using UnityEngine;

namespace Homl.Parser
{
    public class Homl : ParseNode
    {
        public override GameObject parse(HtmlNode homlNode, GameObject parent)
        {
            return parent;
        }
    }
}
