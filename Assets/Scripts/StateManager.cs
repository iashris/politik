using UnityEngine;
using System.Collections;
using System.Diagnostics;
public class StateManager : MonoBehaviour {

	Color startcolor;
	public string fullname;
	int timespressed=0;
	int currzoom;
	float zooma;
	Stopwatch stopwatch;
	Bounds stateBounds;
	void Start(){
		startcolor=Random.ColorHSV(0f, 0f, 0f, 0f, 0.85f, 1f);
		GetComponent<Renderer>().material.color = startcolor;
		GetComponent<cakeslice.Outline> ().enabled = false;
		stateBounds = GetComponent<MeshFilter>().mesh.bounds;
		zooma = stateBounds.max.y;
		stopwatch = new Stopwatch();
	}
	void Update(){
		
		if (gameObject.transform.name == GameObject.Find ("Managers").GetComponent<GameManager>().selectedstatename) {
			GetComponent<cakeslice.Outline>().enabled = true;
			//if tapped again, zoom in
		} else {
			GetComponent<cakeslice.Outline>().enabled = false;
		}
	}

	void OnMouseDown(){
		if (Input.GetTouch (0).tapCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).phase != TouchPhase.Moved && Input.GetTouch(0).deltaPosition.x<10f && Input.GetTouch(0).deltaPosition.y<100f) {
			GameObject.Find ("Managers").GetComponent<GameManager> ().selectedstatename = name;
		}
	}
}
