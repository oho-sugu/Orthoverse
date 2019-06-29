using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.DOM
{
    public class ATag : Node
    {
        public string url;

        private static int count = 0;

        public override void OnSelect()
        {
            Debug.Log("Click atag" + url);
            StartCoroutine(LoadAnotherDocument(url));
        }

        IEnumerator LoadAnotherDocument(string url)
        {
            Parser.HomlParser parser = new Parser.HomlParser();

            Debug.Log(url);
            WWW www = new WWW(url);
            yield return www;

            Debug.Log(www.error);
            Debug.Log(www.text);
            Document doc = parser.Parse(www.text);

            count++;

            int z = count % 5 + 1;
            int x = (count / 5);

            doc.gameObject.transform.position = new Vector3(x, 0.0f, z);

            www.Dispose();
        }

    }

}

