using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	public Vector3 initialpos,target;
	public float offset,zoom,targetzoom;
	// Use this for initialization
	void Start () {
		initialpos = transform.position;
		zoom = Camera.main.orthographicSize;
		offset = initialpos.z;
		target = GameObject.Find ("India_Complete").transform.position+new Vector3(100,100,0);
		targetzoom = zoom;
	}
	
	// Update is called once per frame
	void Update () {

	}

}
