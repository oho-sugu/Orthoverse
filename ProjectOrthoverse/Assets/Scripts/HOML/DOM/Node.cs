using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

namespace Homl.DOM
{
    public abstract class Node : MonoBehaviour
    {
        public virtual void OnSelect()
        {
            Debug.Log("OnSelect" + this);
            getParent().OnSelect();
        }

        public Node getParent(){
            if(gameObject != null){
                return gameObject.transform.parent.GetComponent<Node>();
            }
            return null; 
        }
        //Attribute
        //Style
        //EventHandler
        // Utility funcs such...
        //  getChilds
        //  getParent
        //  attributes accessor
        // Check can util methods call from NLua?
        
    }
}
