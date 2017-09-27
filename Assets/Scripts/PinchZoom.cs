using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{     // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 2.2f;        // The rate of change of the orthographic size in orthographic mode.
	Camera camera;
	void Start(){
		camera = GetComponent<Camera> ();
	}
	public float Remap (float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
	void Update()
	{
		// If there are two touches on the device...
		if (Input.touchCount == 2) {
			// Store both touches.
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// If the camera is orthographic...
			if (camera.orthographic) {
				// ... change the orthographic size based on the change in distance between the touches.
				camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

				// Make sure the orthographic size never drops below zero.
				camera.orthographicSize = Mathf.Clamp (camera.orthographicSize, 200f,camera.GetComponent<CameraManager>().zoom);
				camera.transform.position -= new Vector3(Remap(camera.orthographicSize,200f,1000f,1.5f,0f),0,0);
			}
		} 
	}
}