using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.Parser
{
    public class Cylinder : ParseNode
    {
        public override GameObject parse(HtmlNode homlNode, GameObject parent)
        {
            PrimitiveProducer pp = GameObject.Find("PrimitiveProducer").GetComponent<PrimitiveProducer>();

            GameObject cylinder = GameObject.Instantiate(pp.getCylinder());
            //GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            float x = float.Parse(homlNode.GetAttributeValue("x", "0.0f"));
            float y = float.Parse(homlNode.GetAttributeValue("y", "0.0f"));
            float z = float.Parse(homlNode.GetAttributeValue("z", "0.0f"));
            float r = float.Parse(homlNode.GetAttributeValue("r", "0.05f"));
            float height = float.Parse(homlNode.GetAttributeValue("height", "0.1f"));
            string color = homlNode.GetAttributeValue("color", "white");

            cylinder.transform.parent = parent.transform;
            cylinder.transform.Translate(new Vector3(x, y, z));
            cylinder.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Material mat = cylinder.GetComponent<Renderer>().material;
            mat.color = ColorManager.Instance.getColor(color);
            mat.SetColor("_BaseColor", ColorManager.Instance.getColor(color));

            Vector3 scale = new Vector3(r, height, r);
            Vector3[] verts = cylinder.GetComponent<MeshFilter>().mesh.vertices;
            Vector3[] newverts = new Vector3[verts.Length];
            int i = 0;
            foreach (Vector3 v in verts)
            {
                v.Scale(scale);
                newverts[i] = v;
                i++;
            }
            cylinder.GetComponent<MeshFilter>().mesh.vertices = newverts;


            CapsuleCollider cc = cylinder.GetComponent<CapsuleCollider>();
            cc.radius = r;
            cc.height = height;

            DOM.Cylinder cyl = cylinder.AddComponent<DOM.Cylinder>();

            return cylinder;
        }
    }
}