using UnityEngine;
using System.Collections;
public class StateManager : MonoBehaviour {

	public string fullname;
	public int constituencies;
	public int population;
	public int gdp;
	public float poverty;
	public float hindus;
	public float muslims;
	public float christians;
	public float urbanization;
	public float literacy;
	public string[] neighbors;
	public float turnout;


	int timespressed=0;
	int currzoom;
	float zooma;
	int countah=0;
	bool isSpilt;
	Color col_now;
	public float ID;
	public float confidence=0.0f;
	Bounds stateBounds;
	void Start(){
		ID=Random.Range(0.0f,2000.0f);
		isSpilt=GetComponent<cakeslice.Outline> () == null;
		if (GetComponent<cakeslice.Outline> () != null)
			GetComponent<cakeslice.Outline> ().enabled = false;
		else {
			foreach(Transform child in transform)
			{
				child.gameObject.GetComponent<cakeslice.Outline> ().enabled = false;
			}
		}


		if (GetComponent<MeshFilter> () != null)
			stateBounds = GetComponent<MeshFilter> ().mesh.bounds;
		else
			stateBounds = GetComponent<BoxCollider> ().bounds;
		zooma = stateBounds.max.y;
	}
	void Update(){


		confidence=Mathf.PerlinNoise(ID/9.8567f+Time.time/100.0f, 0.0F);
		if (confidence < .5) { 
			col_now = Color.Lerp (Color.red, new Color(0.39f,0.35f,0.39f), confidence*2);
		} else {
			col_now = Color.Lerp (new Color(0.39f,0.35f,0.39f), Color.white, (confidence-0.5f)*2);
		}


		if (!isSpilt) { //A state, non disjoint union territory
			//Highlight if selected
			if (gameObject.transform.name == GameObject.Find ("Managers").GetComponent<GameManager> ().selectedstatename)
				GetComponent<cakeslice.Outline> ().enabled = true;
			else
				GetComponent<cakeslice.Outline> ().enabled = false;
			GetComponent<Renderer> ().material.color = col_now;




		} else {//is a disjointed union territory
			foreach (Transform child in transform) {
				if (gameObject.transform.name == GameObject.Find ("Managers").GetComponent<GameManager> ().selectedstatename) {
					child.gameObject.GetComponent<cakeslice.Outline> ().enabled = true;
				} else {
					child.gameObject.GetComponent<cakeslice.Outline> ().enabled = false;
				}
				child.gameObject.GetComponent<Renderer> ().material.color = col_now;

			}

		}




		//set timer on if mousepressed once
		if(countah != 0) {
			countah++;
		}
	}

//	void OnMouseDown(){
//		if (Input.GetTouch (0).tapCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).phase != TouchPhase.Moved && Input.GetTouch(0).deltaPosition.x<10f && Input.GetTouch(0).deltaPosition.y<100f) {
//			GameObject.Find ("Managers").GetComponent<GameManager> ().selectedstatename = name;
//		}

	void OnMouseDown(){
		countah=1;
	}
	void OnMouseUp(){
		Debug.Log ("Tap ends at : " + countah);
		if (countah <= 5) {
			GameObject.Find ("Managers").GetComponent<GameManager> ().selectedstatename = name;
		}
		countah = 0;
	}
	}

