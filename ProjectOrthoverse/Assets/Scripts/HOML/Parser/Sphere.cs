using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.Parser
{
    public class Sphere : ParseNode
    {
        public override GameObject parse(HtmlNode homlNode, GameObject parent)
        {
            PrimitiveProducer pp = GameObject.Find("PrimitiveProducer").GetComponent<PrimitiveProducer>();

            GameObject sphere = GameObject.Instantiate(pp.getSphere());
            //GameObject.CreatePrimitive(PrimitiveType.Sphere);
            float x = float.Parse(homlNode.GetAttributeValue("x", "0.0f"));
            float y = float.Parse(homlNode.GetAttributeValue("y", "0.0f"));
            float z = float.Parse(homlNode.GetAttributeValue("z", "0.0f"));
            float r = float.Parse(homlNode.GetAttributeValue("r", "0.1f"));
            string color = homlNode.GetAttributeValue("color", "white");

            sphere.transform.parent = parent.transform;
            sphere.transform.Translate(new Vector3(x, y, z));
            sphere.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Material mat = sphere.GetComponent<Renderer>().material;
            mat.color = ColorManager.Instance.getColor(color);
            mat.SetColor("_BaseColor", ColorManager.Instance.getColor(color));

            Vector3 scale = new Vector3(r, r, r);
            Vector3[] verts = sphere.GetComponent<MeshFilter>().mesh.vertices;
            Vector3[] newverts = new Vector3[verts.Length];
            int i = 0;
            foreach (Vector3 v in verts)
            {
                v.Scale(scale);
                newverts[i] = v;
                i++;
            }
            sphere.GetComponent<MeshFilter>().mesh.vertices = newverts;

            SphereCollider sc = sphere.GetComponent<SphereCollider>();
            sc.radius = r;

            DOM.Sphere sp = sphere.AddComponent<DOM.Sphere>();

            return sphere;
        }
    }
}