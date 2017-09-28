using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public string selectedstatename="";
	public bool isPinching = false;
	public int currzoomstatus=0;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		if (selectedstatename != "") {
			GameObject.Find ("Text").GetComponent<UnityEngine.UI.Text> ().text = GameObject.Find (selectedstatename).GetComponent<StateManager> ().fullname;
			GameObject.Find ("Text2").GetComponent<UnityEngine.UI.Text> ().text = GameObject.Find (selectedstatename).GetComponent<StateManager> ().confidence.ToString ();
		}
	}
}
