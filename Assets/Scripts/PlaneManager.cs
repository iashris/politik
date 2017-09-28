using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if (Input.GetTouch (0).tapCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began) {
			GameObject.Find ("Managers").GetComponent<GameManager> ().selectedstatename = "";
		}
	}
}
