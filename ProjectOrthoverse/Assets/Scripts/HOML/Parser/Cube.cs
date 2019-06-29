using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.Parser
{
    public class Cube : ParseNode
    {
        public override GameObject parse(HtmlNode homlNode, GameObject parent)
        {
            PrimitiveProducer pp = GameObject.Find("PrimitiveProducer").GetComponent<PrimitiveProducer>();
            GameObject cube = GameObject.Instantiate(pp.getCube());
            float x = float.Parse(homlNode.GetAttributeValue("x", "0.0f"));
            float y = float.Parse(homlNode.GetAttributeValue("y", "0.0f"));
            float z = float.Parse(homlNode.GetAttributeValue("z", "0.0f"));
            float s = float.Parse(homlNode.GetAttributeValue("size", "0.1f"));
            string color = homlNode.GetAttributeValue("color", "white");

            cube.transform.parent = parent.transform;
            cube.transform.Translate(new Vector3(x, y, z));
            cube.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Material mat = cube.GetComponent<Renderer>().material;
            mat.color = ColorManager.Instance.getColor(color);
            mat.SetColor("_BaseColor", ColorManager.Instance.getColor(color));

            Vector3 scale = new Vector3(s, s, s);
            Vector3[] verts = cube.GetComponent<MeshFilter>().mesh.vertices;
            Vector3[] newverts = new Vector3[verts.Length];
            int i = 0;
            foreach (Vector3 v in verts)
            {
                v.Scale(scale);
                newverts[i] = v;
                i++;
            }
            cube.GetComponent<MeshFilter>().mesh.vertices = newverts;


            BoxCollider bc = cube.GetComponent<BoxCollider>();
            bc.size = scale;

            DOM.Cube cb = cube.AddComponent<DOM.Cube>();

            return cube;
        }
    }
}