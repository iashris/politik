using UnityEngine;
using System.Collections;

public class Pan : MonoBehaviour {
	public float speed;
	Vector3 initialpos;
	Vector3 destination;
	float smoothFactor=5f;
	void Start(){
		initialpos = GetComponent<CameraManager> ().initialpos;
		destination = initialpos;
		speed = 3.5f;
	}
	public float Remap (float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
	void Update() {

		if (transform.position != destination) {
			transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * smoothFactor);
			float zoomsize = Camera.main.orthographicSize;
			float allowance = Remap (zoomsize, Camera.main.GetComponent<CameraManager> ().zoom, 200f, 0, 950f);
			float ClampX = Mathf.Clamp (transform.position.x, initialpos.x - 1.2f*allowance, initialpos.x + 0.8f*allowance);
			float ClampY=Mathf.Clamp (transform.position.y, initialpos.y - allowance, initialpos.y + allowance);
			transform.position = new Vector3 (ClampX, ClampY, transform.position.z);
		}
			
		if (Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
			Vector3 t3=new Vector3(touchDeltaPosition.x*speed,touchDeltaPosition.y*speed,transform.position.z);
			destination = transform.position-t3;
			//Camera Position Constrains

		}
	}
	public void moveTo(Vector3 dest){
		destination = dest;
	}
}