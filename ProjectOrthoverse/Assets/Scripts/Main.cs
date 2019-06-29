using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homl;

public class Main : MonoBehaviour {
    // Use this for initialization
	void Start () {
        StartCoroutine(LoadHomeCoroutine());
    }

    IEnumerator LoadHomeCoroutine()
    {
        Homl.Parser.HomlParser parser = new Homl.Parser.HomlParser();

        WWW www = new WWW("https://gist.githubusercontent.com/oho-sugu/3c5db150242e0381e08a5288e6b40af3/raw/4ceef5b9b287b69e47bf02ea76b342755f18ab4f/index.homl");
        yield return www;

        Homl.DOM.Document doc = parser.Parse(www.text);
        doc.gameObject.transform.Translate(0.0f, 0.0f, 1.0f);
        www.Dispose();

        www = new WWW("https://gist.githubusercontent.com/oho-sugu/4cdd98cbfc8e47be090d472e8cfe6392/raw/aa064cfcb3b847c9a4d7cf9b10f0416c010e5e2d/Graph");
        yield return www;

        Homl.DOM.Document doc2 = parser.Parse(www.text);
        doc2.gameObject.transform.Translate(0.5f, 0.0f, 1.0f);
        www.Dispose();

        www = new WWW("https://gist.githubusercontent.com/oho-sugu/9e11309967917c1300f0c751f9ec3794/raw/93231417404408e6e75e52289936307fc44706c8/Weather");
        yield return www;

        Homl.DOM.Document doc3 = parser.Parse(www.text);
        doc3.gameObject.transform.Translate(-0.5f, 0.0f, 1.0f);
        www.Dispose();
        

    }
}
