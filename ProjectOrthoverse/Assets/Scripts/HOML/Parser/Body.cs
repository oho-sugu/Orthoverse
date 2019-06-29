using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.Parser
{
    public class Body : ParseNode
    {
        public override GameObject parse(HtmlNode homlNode, GameObject parent)
        {
            PrimitiveProducer pp = GameObject.Find("PrimitiveProducer").GetComponent<PrimitiveProducer>();
            
            GameObject bound = GameObject.Instantiate(pp.getCube());
            bound.layer = 2;

            Material mat = bound.GetComponent<Renderer>().material;
            mat.color = new Color(0.6f, 0.6f, 0.6f, 0.3f);
            mat.SetColor("_BaseColor", new Color(0.6f, 0.6f, 0.6f, 0.3f));

            float wx = float.Parse(homlNode.GetAttributeValue("wx", "0.1f"));
            float wy = float.Parse(homlNode.GetAttributeValue("wy", "0.1f"));
            float wz = float.Parse(homlNode.GetAttributeValue("wz", "0.1f"));

            bound.transform.parent = parent.transform;
            bound.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Vector3 scale = new Vector3(wx, wy, wz);
            Vector3[] verts = bound.GetComponent<MeshFilter>().mesh.vertices;
            Vector3[] newverts = new Vector3[verts.Length];
            int i = 0;
            foreach (Vector3 v in verts)
            {
                v.Scale(scale);
                newverts[i] = v;
                i++;
            }
            bound.GetComponent<MeshFilter>().mesh.vertices = newverts;

            BoxCollider bc = bound.GetComponent<BoxCollider>();
            bc.size = scale;

            DOM.Body bd = bound.AddComponent<DOM.Body>();

            return bound;
        }
    }
}
