using UnityEngine;
using System.Collections;

public class Pan : MonoBehaviour {
	public float speed = 0.1F;
	void Update() {
		if (Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}
	}
}