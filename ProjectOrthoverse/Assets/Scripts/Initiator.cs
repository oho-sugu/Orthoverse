using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initiator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
	}
}
