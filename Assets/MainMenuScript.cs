﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("SceneV1");
        }
        if (Input.GetKey(KeyCode.I))
        {
            SceneManager.LoadScene("SceneInstructions");
        }


    }
}
