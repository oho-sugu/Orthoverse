using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using HtmlAgilityPack;
using Homl.DOM;
using System.Reflection;

namespace Homl.Parser
{
    public class HomlParser
    {
        public static Dictionary<string, ParseNode> nodeTemplates;

        public HomlParser()
        {
            if(nodeTemplates == null)
            {
                nodeTemplates = new Dictionary<string, ParseNode>();

                // 手抜き
                nodeTemplates.Add("a-scene", new Body());
                nodeTemplates.Add("a-box", new Cube());
                nodeTemplates.Add("a-cylinder", new Cylinder());
                nodeTemplates.Add("a-sphere", new Sphere());
                nodeTemplates.Add("a-link", new ATag());
                nodeTemplates.Add("a-text", new Text());
                nodeTemplates.Add("homl", new Homl());
            }
        }

        public Document Parse()
        {
            string homl = "<homl><head><title>TestHoloML</title></head><body wx=0.2 wy=0.2 wz=0.2><cube size=0.1 x=0 y=0 z=0 color=blue><cylinder height=0.05 r=0.02 x=0.1 y=0.1 z=0.1 color=red /><sphere r=0.05 x=-0.1 y=-0.1 z=-0.1 color=green /><text size=0.1 x=0 y=0 z=0 color=blue>ABCDEF</text></cube><a href=”test2.hlml”><cube size=0.1 x=0.1 y=-0.1 z=0.1 color=white /></a></body></homl>";
            return Parse(homl);
        }

        public Document Parse(string homl)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(homl);

            GameObject documentGO = new GameObject("Document");
            Document document = documentGO.AddComponent<Document>();
            BoxCollider bc = documentGO.AddComponent<BoxCollider>();
//            documentGO.AddComponent<HUX.Interaction.BoundingBoxTarget>();
//            HUX.Interaction.ManipulationManager.Instance.ActiveBoundingBox.Target = documentGO;

            walkinChild(htmlDoc.DocumentNode.ChildNodes, documentGO);

            bc.size = new Vector3(0.3f, 0.3f, 0.3f);
            return document;
        }

        private void walkinChild(HtmlAgilityPack.HtmlNodeCollection nodes, GameObject parent)
        {
            foreach (HtmlAgilityPack.HtmlNode node in nodes)
            {
                GameObject nodeObject = null;
                Debug.Log(node.Name);

                if (nodeTemplates.ContainsKey(node.Name))
                {
                    nodeObject = nodeTemplates[node.Name].parse(node, parent);
                } else
                {
                    nodeObject = parent;
                }

                if (node.HasChildNodes)
                {
                    walkinChild(node.ChildNodes, nodeObject);
                }

            }
        }
    }
}