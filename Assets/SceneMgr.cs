﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void ChangeScene(string sceneName) {
		Application.LoadLevel (sceneName); 
	}
}

