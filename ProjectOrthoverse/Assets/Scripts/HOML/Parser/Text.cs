using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.Parser
{
    public class Text : ParseNode
    {
        public override GameObject parse(HtmlNode homlNode, GameObject parent)
        {
            GameObject text = new GameObject(homlNode.InnerText);
            text.AddComponent<MeshRenderer>();
            TextMesh tm = text.AddComponent<TextMesh>();
            tm.text = homlNode.InnerText;

            float x = float.Parse(homlNode.GetAttributeValue("x", "0.0f"));
            float y = float.Parse(homlNode.GetAttributeValue("y", "0.0f"));
            float z = float.Parse(homlNode.GetAttributeValue("z", "0.0f"));
            float s = float.Parse(homlNode.GetAttributeValue("size", "0.1f"));
            string color = homlNode.GetAttributeValue("color", "white");

            text.transform.parent = parent.transform;
            text.transform.Translate(new Vector3(x, y, z));
            text.transform.localScale = new Vector3(s, s, s);

            tm.color = ColorManager.Instance.getColor(color);

            DOM.Text text2 = text.AddComponent<DOM.Text>();
    
            return text;
        }
    }
}